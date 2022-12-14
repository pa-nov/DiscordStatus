using System.Diagnostics;
using System.Text.Json;
using DiscordRPC;
using Newtonsoft.Json.Linq;

namespace DiscordStatus
{
	public partial class MainWindow : Form
	{
		DiscordRpcClient client;
		bool IsElapsed = true, IsPublic = true;
		static readonly HttpClient httpClient = new HttpClient();

		public MainWindow()
		{
			InitializeComponent();
			try
			{
				SettingsLoad("AutoSave");
			}
			catch { }
		}

		private void StatusStart_Click(object sender, EventArgs e) { StatusStartVoid(); }
		private void StatusStop_Click(object sender, EventArgs e) { StatusStopVoid(); }
		private void StatusUpdate_Click(object sender, EventArgs e) { StatusUpdateVoid(); }
		private void AppIDBox_TextChanged(object sender, EventArgs e) { ImageKeysState.Text = "Ключи изображений устарели"; }
		private void ImageKeysUpdate_Click(object sender, EventArgs e) { ImageKeysUpdateVoid(); }
		private void TimerUpdate_Tick(object sender, EventArgs e) { TickVoid(); }

		private void StatusElapsed_Click(object sender, EventArgs e) { SetIsElapsed(true); }
		private void StatusRemaining_Click(object sender, EventArgs e) { SetIsElapsed(false); }
		private void StatusPartyPrivacyPublic_Click(object sender, EventArgs e) { SetIsPublic(true); }
		private void StatusPartyPrivacyPrivate_Click(object sender, EventArgs e) { SetIsPublic(false); }
		private void StatusCustomTimeEnabled_CheckedChanged(object sender, EventArgs e) { SetCustomTimeEnabled(StatusCustomTimeEnabled.Checked); }

		private void MainWindow_SizeChanged(object sender, EventArgs e) { ApplicationHide(); }
		private void NotifyIcon_MouseClick(object sender, MouseEventArgs e) { ApplicationShow(); }

		private void MenuSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Файл настроек (*.json)|*.json";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				SettingsSave(saveFileDialog.FileName);
			}
		}
		private void MenuLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Файл настроек (*.json)|*.json";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				SettingsLoad(openFileDialog.FileName);
			}
		}
		private void MenuClear_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы уверенны?", "Очистка", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				SettingsLoad("");
			}
		}
		private void MenuOpenGitHub_Click(object sender, EventArgs e)
		{
			Process.Start(new ProcessStartInfo("https://github.com/pa-nov/Discord-Status") { UseShellExecute = true });
		}



		private void StatusStartVoid()
		{
			if (Int64.TryParse(AppIDBox.Text, out Int64 AppID))
			{
				StatusStopVoid();
				client = new DiscordRpcClient(AppID.ToString());
				client.RegisterUriScheme();
				client.Initialize();
				ApplicationState.Text = "Запущено приложение: " + client.ApplicationID;
			}
			else
			{
				MessageBox.Show("ID Приложения указан неверно", "Ошибка");
				return;
			}
		}
		private void StatusStopVoid()
		{
			if (client != null)
			{
				client.Dispose();
				ApplicationState.Text = "Не запущено";
				StatusLargeKey.Items.Clear();
				StatusSmallKey.Items.Clear();
			}
		}
		private void StatusUpdateVoid()
		{
			if (client == null || !client.IsInitialized || client.ApplicationID != AppIDBox.Text)
			{
				StatusStartVoid();
			}
			if (client == null || !client.IsInitialized)
			{
				return;
			}

			RichPresence activity = new RichPresence();

			if (NotEmpty(StatusDetails))
			{
				activity.Details = StatusDetails.Text;
			}
			if (NotEmpty(StatusState))
			{
				activity.State = StatusState.Text;
			}
			if (NotEmpty(StatusPartyMin) && NotEmpty(StatusPartyMax))
			{
				if (Int32.TryParse(StatusPartyMin.Text, out Int32 PartyMin) && PartyMin > 0 &&
					Int32.TryParse(StatusPartyMax.Text, out Int32 PartyMax) && PartyMax > 0)
				{
					if (String.IsNullOrWhiteSpace(StatusPartyID.Text))
					{
						StatusPartyID.Text = "NULL";
					}
					activity.Party = new Party();
					activity.Party.Size = PartyMin;
					activity.Party.Max = PartyMax;
				}
				else
				{
					MessageBox.Show("Количество игроков должно быть целым положительным числом", "Ошибка");
					return;
				}
			}

			if (StatusCustomTimeEnabled.Checked)
			{
				activity.Timestamps = new Timestamps();

				if (((DateTimeOffset)StatusCustomTime.Value).ToUnixTimeMilliseconds() < 1)
				{
					StatusCustomTime.Value = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(1).ToLocalTime();
				}

				ulong CustomTime = (ulong)((DateTimeOffset)StatusCustomTime.Value).ToUnixTimeMilliseconds();

				if (IsElapsed)
				{
					activity.Timestamps.StartUnixMilliseconds = CustomTime;
				}
				else
				{
					activity.Timestamps.EndUnixMilliseconds = CustomTime;
				}
			}
			else
			{
				if (NotEmpty(StatusHours) || NotEmpty(StatusMinutes) || NotEmpty(StatusSeconds))
				{
					Int64 Hours = 0, Minutes = 0, Seconds = 0;
					bool IsHours = Int64.TryParse(StatusHours.Text, out Hours);
					bool IsMinutes = Int64.TryParse(StatusMinutes.Text, out Minutes);
					bool IsSeconds = Int64.TryParse(StatusSeconds.Text, out Seconds);
					if (IsHours || IsMinutes || IsSeconds)
					{
						activity.Timestamps = new Timestamps();

						Int64 Time = ((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds();
						Int64 NewTime = Seconds + Minutes * 60 + Hours * 3600;

						if (IsElapsed)
						{
							activity.Timestamps.StartUnixMilliseconds = (ulong)(Time - NewTime * 1000);
						}
						else
						{
							activity.Timestamps.EndUnixMilliseconds = (ulong)(Time + NewTime * 1000);
						}
					}
					else
					{
						MessageBox.Show("Время (Часы, Минуты, Секунды) должны быть числами", "Ошибка");
						return;
					}
				}
			}


			if (!String.IsNullOrWhiteSpace(StatusLargeKey.Text))
			{
				if (activity.Assets == null)
				{
					activity.Assets = new Assets();
				}
				activity.Assets.LargeImageKey = StatusLargeKey.Text;
			}
			if (NotEmpty(StatusLargeText))
			{
				if (activity.Assets == null)
				{
					activity.Assets = new Assets();
				}
				activity.Assets.LargeImageText = StatusLargeText.Text;
			}
			if (!String.IsNullOrWhiteSpace(StatusSmallKey.Text))
			{
				if (activity.Assets == null)
				{
					activity.Assets = new Assets();
				}
				activity.Assets.SmallImageKey = StatusSmallKey.Text;
			}
			if (NotEmpty(StatusSmallText))
			{
				if (activity.Assets == null)
				{
					activity.Assets = new Assets();
				}
				activity.Assets.SmallImageText = StatusSmallText.Text;
			}


			DiscordRPC.Button button1 = null;
			if (NotEmpty(StatusButton1Text) && NotEmpty(StatusButton1Url))
			{
				if (Uri.IsWellFormedUriString(StatusButton1Url.Text, UriKind.Absolute))
				{
					button1 = new DiscordRPC.Button()
					{
						Label = StatusButton1Text.Text,
						Url = StatusButton1Url.Text,
					};
				}
				else
				{
					MessageBox.Show('"' + StatusButton1Url.Text + "' не является ссылкой", "Ошибка");
					return;
				}
			}
			DiscordRPC.Button button2 = null;
			if (NotEmpty(StatusButton2Text) && NotEmpty(StatusButton2Url))
			{
				if (Uri.IsWellFormedUriString(StatusButton2Url.Text, UriKind.Absolute))
				{
					button2 = new DiscordRPC.Button()
					{
						Label = StatusButton2Text.Text,
						Url = StatusButton2Url.Text,
					};
				}
				else
				{
					MessageBox.Show("'" + StatusButton2Url.Text + "' не является ссылкой", "Ошибка");
					return;
				}
			}

			DiscordRPC.Button[] buttons = null;
			if (button1 != null && button2 != null)
			{
				buttons = new DiscordRPC.Button[] { button1, button2 };
			}
			else
			{
				if (button1 != null)
				{
					buttons = new DiscordRPC.Button[] { button1 };
				}
				if (button2 != null)
				{
					buttons = new DiscordRPC.Button[] { button2 };
				}
			}
			if (buttons != null)
			{
				activity.Buttons = buttons;
			}


			if (NotEmpty(StatusPartyID))
			{
				if (activity.Party == null)
				{
					activity.Party = new Party();
				}
				activity.Party.ID = StatusPartyID.Text;

				if (IsPublic)
				{
					activity.Party.Privacy = Party.PrivacySetting.Public;
				}
				else
				{
					activity.Party.Privacy = Party.PrivacySetting.Private;
				}
			}
			if (NotEmpty(StatusPartyMatch))
			{
				if (buttons != null)
				{
					MessageBox.Show("При использовании кнопок нельзя использовать приглашения", "Ошибка");
					return;
				}

				if (activity.Secrets == null)
				{
					activity.Secrets = new Secrets();
				}
				activity.Secrets.MatchSecret = StatusPartyMatch.Text;
			}
			if (NotEmpty(StatusPartyJoin))
			{
				if (buttons != null)
				{
					MessageBox.Show("При использовании кнопок нельзя использовать приглашения", "Ошибка");
					return;
				}

				if (activity.Secrets == null)
				{
					activity.Secrets = new Secrets();
				}
				activity.Secrets.JoinSecret = StatusPartyJoin.Text;
			}
			if (NotEmpty(StatusPartySpectate))
			{
				if (buttons != null)
				{
					MessageBox.Show("При использовании кнопок нельзя использовать приглашения", "Ошибка");
					return;
				}

				if (activity.Secrets == null)
				{
					activity.Secrets = new Secrets();
				}
				activity.Secrets.SpectateSecret = StatusPartySpectate.Text;
			}

			client.SetPresence(activity);
			SettingsSave("AutoSave");
		}
		private void TickVoid()
		{
			if (client != null)
			{
				client.Invoke();
			}
		}

		private void SetIsElapsed(bool NewValue)
		{
			IsElapsed = NewValue;
			if (NewValue)
			{
				StatusElapsed.BackColor = Color.White;
				StatusElapsed.ForeColor = Color.Black;
				StatusRemaining.BackColor = Color.FromArgb(255, 64, 68, 75);
				StatusRemaining.ForeColor = Color.White;
			}
			else
			{
				StatusElapsed.BackColor = Color.FromArgb(255, 64, 68, 75);
				StatusElapsed.ForeColor = Color.White;
				StatusRemaining.BackColor = Color.White;
				StatusRemaining.ForeColor = Color.Black;
			}
		}
		private void SetIsPublic(bool NewValue)
		{
			IsPublic = NewValue;
			if (NewValue)
			{
				StatusPartyPrivacyPublic.BackColor = Color.White;
				StatusPartyPrivacyPublic.ForeColor = Color.Black;
				StatusPartyPrivacyPrivate.BackColor = Color.FromArgb(255, 64, 68, 75);
				StatusPartyPrivacyPrivate.ForeColor = Color.White;
			}
			else
			{
				StatusPartyPrivacyPublic.BackColor = Color.FromArgb(255, 64, 68, 75);
				StatusPartyPrivacyPublic.ForeColor = Color.White;
				StatusPartyPrivacyPrivate.BackColor = Color.White;
				StatusPartyPrivacyPrivate.ForeColor = Color.Black;
			}
		}
		private void SetCustomTimeEnabled(bool NewValue)
		{
			StatusCustomTime.Enabled = NewValue;
			StatusHours.Enabled = !NewValue;
			StatusMinutes.Enabled = !NewValue;
			StatusSeconds.Enabled = !NewValue;
		}
		private async void ImageKeysUpdateVoid()
		{
			StatusLargeKey.Items.Clear();
			StatusSmallKey.Items.Clear();
			ImageKeysState.Text = "Загрузка ключей изображений";

			try
			{
				string assetsURL = "https://discordapp.com/api/oauth2/applications/" + AppIDBox.Text + "/assets";
				HttpResponseMessage message = await httpClient.GetAsync(assetsURL);
				message.EnsureSuccessStatusCode();
				JArray assetsArray = JArray.Parse(await message.Content.ReadAsStringAsync());

				for (int i = 0; i < assetsArray.Count; i++)
				{
					StatusLargeKey.Items.Add(assetsArray[i]["name"]);
					StatusSmallKey.Items.Add(assetsArray[i]["name"]);
				}

				ImageKeysState.Text = "Ключи изображений загружены";
			}
			catch
			{
				ImageKeysState.Text = "Приложение не найдено";
			}
		}

		private void ApplicationHide()
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.Hide();
				NotifyIcon.Visible = true;
				NotifyIcon.ShowBalloonTip(0);
			}
		}
		private void ApplicationShow()
		{
			this.Show();
			NotifyIcon.Visible = false;
			this.WindowState = FormWindowState.Normal;
		}


		private void SettingsSave(string path)
		{
			StatusSettings settings = new StatusSettings
			{
				IsElapsed = IsElapsed,
				IsPublic = IsPublic,
				CustomTimeEnabled = StatusCustomTimeEnabled.Checked,
				CustomTime = ((DateTimeOffset)StatusCustomTime.Value).ToUnixTimeMilliseconds(),
				AppID = AppIDBox.Text,
				Details = StatusDetails.Text,
				State = StatusState.Text,
				PartyMin = StatusPartyMin.Text,
				PartyMax = StatusPartyMax.Text,
				Hours = StatusHours.Text,
				Minutes = StatusMinutes.Text,
				Seconds = StatusSeconds.Text,
				LargeKey = StatusLargeKey.Text,
				LargeText = StatusLargeText.Text,
				SmallKey = StatusSmallKey.Text,
				SmallText = StatusSmallText.Text,
				Button1Text = StatusButton1Text.Text,
				Button1Url = StatusButton1Url.Text,
				Button2Text = StatusButton2Text.Text,
				Button2Url = StatusButton2Url.Text,
				PartyID = StatusPartyID.Text,
				PartyMatch = StatusPartyMatch.Text,
				PartyJoin = StatusPartyJoin.Text,
				PartySpectate = StatusPartySpectate.Text,
			};
			File.WriteAllText(path, JsonSerializer.Serialize(settings));
		}
		private void SettingsLoad(string path)
		{
			StatusSettings settings = new StatusSettings();
			if (path != "")
			{
				settings = JsonSerializer.Deserialize<StatusSettings>(File.ReadAllText(path))!;
			}
			SetIsElapsed(settings.IsElapsed);
			SetIsPublic(settings.IsPublic);
			StatusCustomTimeEnabled.Checked = settings.CustomTimeEnabled;
			StatusCustomTime.Value = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(settings.CustomTime).ToLocalTime();
			AppIDBox.Text = settings.AppID;
			StatusDetails.Text = settings.Details;
			StatusState.Text = settings.State;
			StatusPartyMin.Text = settings.PartyMin;
			StatusPartyMax.Text = settings.PartyMax;
			StatusHours.Text = settings.Hours;
			StatusMinutes.Text = settings.Minutes;
			StatusSeconds.Text = settings.Seconds;
			StatusLargeKey.Text = settings.LargeKey;
			StatusLargeText.Text = settings.LargeText;
			StatusSmallKey.Text = settings.SmallKey;
			StatusSmallText.Text = settings.SmallText;
			StatusButton1Text.Text = settings.Button1Text;
			StatusButton1Url.Text = settings.Button1Url;
			StatusButton2Text.Text = settings.Button2Text;
			StatusButton2Url.Text = settings.Button2Url;
			StatusPartyID.Text = settings.PartyID;
			StatusPartyMatch.Text = settings.PartyMatch;
			StatusPartyJoin.Text = settings.PartyJoin;
			StatusPartySpectate.Text = settings.PartySpectate;
		}

		private bool NotEmpty(TextBox textBox)
		{
			return !String.IsNullOrWhiteSpace(textBox.Text);
		}
	}

	public class StatusSettings
	{
		public bool IsElapsed { get; set; } = true;
		public bool IsPublic { get; set; } = true;
		public bool CustomTimeEnabled { get; set; } = false;
		public Int64 CustomTime { get; set; } = 1;
		public string AppID { get; set; } = "";
		public string Details { get; set; } = "";
		public string State { get; set; } = "";
		public string PartyMin { get; set; } = "";
		public string PartyMax { get; set; } = "";
		public string Hours { get; set; } = "";
		public string Minutes { get; set; } = "";
		public string Seconds { get; set; } = "";
		public string LargeKey { get; set; } = "";
		public string LargeText { get; set; } = "";
		public string SmallKey { get; set; } = "";
		public string SmallText { get; set; } = "";
		public string Button1Text { get; set; } = "";
		public string Button1Url { get; set; } = "";
		public string Button2Text { get; set; } = "";
		public string Button2Url { get; set; } = "";
		public string PartyID { get; set; } = "";
		public string PartyMatch { get; set; } = "";
		public string PartyJoin { get; set; } = "";
		public string PartySpectate { get; set; } = "";
	}
}