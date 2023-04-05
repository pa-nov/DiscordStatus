using System.Diagnostics;
using System.Text.Json;
using DiscordRPC;
using DiscordRPC.Message;
using Newtonsoft.Json.Linq;

namespace DiscordStatus
{
	public partial class MainWindow : Form
	{
		DiscordRpcClient client = new("-1");
		bool IsElapsed = true, IsPublic = true;
		string StringAppIDBox = "", StringStatusPartyMin = "", StringStatusPartyMax = "";
		string StringStatusHours = "", StringStatusMinutes = "", StringStatusSeconds = "";
		static readonly HttpClient httpClient = new();

		public MainWindow()
		{
			InitializeComponent();

			string[] args = Environment.GetCommandLineArgs();
			string path = Path.GetDirectoryName(args[0]) + "/AutoSave";
			if (args.Length > 1)
			{
				path = args[1];
			}
			SettingsLoad(path);
		}

		private void StatusStart_Click(object sender, EventArgs e) { StatusStartVoid(); }
		private void StatusStop_Click(object sender, EventArgs e) { StatusStopVoid(); }
		private void StatusUpdate_Click(object sender, EventArgs e) { StatusUpdateVoid(); }
		private void ImageKeysUpdate_Click(object sender, EventArgs e) { ImageKeysUpdateVoid(); }
		private void TimerUpdate_Tick(object sender, EventArgs e) { TickVoid(); }

		private void Client_OnError(object sender, ErrorMessage e)
		{
			MessageBox.Show(e.Message, "Ошибка (" + e.Code + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		private void Client_OnReady(object sender, ReadyMessage e)
		{
			ApplicationState.Text = "Запущено приложение: " + client.ApplicationID;
		}
		private void Client_OnPresenceUpdate(object sender, PresenceMessage e)
		{
			this.Text = "Discord Status - " + (e.Name);
		}
		
		// Цифровые поля
		private void AppIDBox_TextChanged(object sender, EventArgs e)
		{
			TextToNumber((TextBox)sender, StringAppIDBox);
			if (AppIDBox.Text != StringAppIDBox)
			{
				ImageKeysState.Text = "Ключи изображений устарели";
			}
			StringAppIDBox = ((TextBox)sender).Text;
		}
		private void StatusPartyMin_TextChanged(object sender, EventArgs e) { StringStatusPartyMin = TextToInt((TextBox)sender, StringStatusPartyMin); }
		private void StatusPartyMax_TextChanged(object sender, EventArgs e) { StringStatusPartyMax = TextToInt((TextBox)sender, StringStatusPartyMax); }
		private void StatusHours_TextChanged(object sender, EventArgs e) { StringStatusHours = TextToInt((TextBox)sender, StringStatusHours); }
		private void StatusMinutes_TextChanged(object sender, EventArgs e) { StringStatusMinutes = TextToInt((TextBox)sender, StringStatusMinutes); }
		private void StatusSeconds_TextChanged(object sender, EventArgs e) { StringStatusSeconds = TextToInt((TextBox)sender, StringStatusSeconds); }

		// Placeholder у полей для ввода ключей изображений
		private void StatusLargeKey_Enter(object sender, EventArgs e) { PlaceholderEnter((ComboBox)sender); }
		private void StatusLargeKey_Leave(object sender, EventArgs e) { PlaceholderLeave((ComboBox)sender, "Ключ большого изображения"); }
		private void StatusSmallKey_Enter(object sender, EventArgs e) { PlaceholderEnter((ComboBox)sender); }
		private void StatusSmallKey_Leave(object sender, EventArgs e) { PlaceholderLeave((ComboBox)sender, "Ключ малого изображения"); }

		// Кнопки переключатели
		private void StatusElapsed_Click(object sender, EventArgs e) { SetIsElapsed(true); }
		private void StatusRemaining_Click(object sender, EventArgs e) { SetIsElapsed(false); }
		private void StatusPartyPrivacyPublic_Click(object sender, EventArgs e) { SetIsPublic(true); }
		private void StatusPartyPrivacyPrivate_Click(object sender, EventArgs e) { SetIsPublic(false); }
		private void StatusIsCustomTime_CheckedChanged(object sender, EventArgs e) { SetIsCustomTime(((CheckBox)sender).Checked); }

		// Кнопки меню
		private void MenuSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new()
			{
				Filter = "Файл конфигурации (*.json)|*.json"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				SettingsSave(saveFileDialog.FileName);
			}
		}
		private void MenuLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new()
			{
				Filter = "Файл конфигурации (*.json)|*.json"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				SettingsLoad(openFileDialog.FileName);
			}
		}
		private void MenuClear_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы уверенны?", "Очистка", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				SettingsLoad("");
			}
		}
		private void MenuOpenGitHub_Click(object sender, EventArgs e)
		{
			Process.Start(new ProcessStartInfo("https://github.com/pa-nov/Discord-Status/wiki") { UseShellExecute = true });
		}

		// Обработка закрытия программы
		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				this.Hide();
				NotifyIcon.Visible = true;
				NotifyIcon.ShowBalloonTip(0);
			}
			else
			{
				StatusStopVoid();
				string[] args = Environment.GetCommandLineArgs();
				SettingsSave(Path.GetDirectoryName(args[0]) + "/AutoSave");
			}
		}
		private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			NotifyIcon.Visible = false;
		}
		private void NotifyOpen_Click(object sender, EventArgs e)
		{
			this.Show();
			NotifyIcon.Visible = false;
		}
		private void NotifyExit_Click(object sender, EventArgs e) { Application.Exit(); }
		private void MenuExit_Click(object sender, EventArgs e) { Application.Exit(); }

		// Перетаскивание файлов в программу
		private void MainWindow_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
		private void MainWindow_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data != null)
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				SettingsLoad(files[0]);
			}
		}


		private void StatusStartVoid()
		{
			if (Int64.TryParse(AppIDBox.Text, out Int64 AppID))
			{
				if (client.IsInitialized)
				{
					StatusStopVoid();
				}
				StatusStart.Enabled = false;
				StatusStop.Enabled = true;
				client = new(AppID.ToString());
				client.RegisterUriScheme();
				client.Initialize();
				client.OnError += Client_OnError;
				client.OnReady += Client_OnReady;
				client.OnPresenceUpdate += Client_OnPresenceUpdate;
				ApplicationState.Text = "Запуск приложения: " + client.ApplicationID;
			}
			else
			{
				MessageBox.Show("ID Приложения указан неверно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}
		private void StatusStopVoid()
		{
			StatusStart.Enabled = true;
			StatusStop.Enabled = false;
			client.Dispose();
			this.Text = "Discord Status";
			ApplicationState.Text = "Не запущено";
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

			RichPresence activity = new();

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
					if (PartyMin > PartyMax)
					{
						StatusPartyMin.Text = PartyMax.ToString();
						PartyMin = PartyMax;
					}
					if (String.IsNullOrWhiteSpace(StatusPartyID.Text))
					{
						StatusPartyID.Text = "NULL";
					}
					activity.Party = new()
					{
						Size = PartyMin,
						Max = PartyMax
					};
				}
				else
				{
					MessageBox.Show("Количество игроков должно быть целым положительным числом", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			if (StatusIsCustomTime.Checked)
			{
				if (((DateTimeOffset)StatusCustomTime.Value).ToUnixTimeMilliseconds() < 1)
				{
					StatusCustomTime.Value = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(1).ToLocalTime();
				}

				ulong CustomTime = (ulong)((DateTimeOffset)StatusCustomTime.Value).ToUnixTimeMilliseconds();

				if (IsElapsed)
				{
					activity.Timestamps = new()
					{
						StartUnixMilliseconds = CustomTime
					};
				}
				else
				{
					activity.Timestamps = new()
					{
						EndUnixMilliseconds = CustomTime
					};
				}
			}
			else
			{
				if (NotEmpty(StatusHours) || NotEmpty(StatusMinutes) || NotEmpty(StatusSeconds))
				{
					bool IsHours = Int64.TryParse(StatusHours.Text, out long Hours);
					bool IsMinutes = Int64.TryParse(StatusMinutes.Text, out long Minutes);
					bool IsSeconds = Int64.TryParse(StatusSeconds.Text, out long Seconds);
					if (IsHours || IsMinutes || IsSeconds)
					{
						Int64 Time = ((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds();
						Int64 NewTime = Seconds + Minutes * 60 + Hours * 3600;

						if (IsElapsed)
						{
							activity.Timestamps = new()
							{
								StartUnixMilliseconds = (ulong)(Time - NewTime * 1000)
							};
						}
						else
						{
							activity.Timestamps = new()
							{
								EndUnixMilliseconds = (ulong)(Time + NewTime * 1000)
							};
						}
					}
					else
					{
						MessageBox.Show("Время (Часы, Минуты, Секунды) должны быть числами", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
			}


			if (!String.IsNullOrWhiteSpace(StatusLargeKey.Text) && String.IsNullOrEmpty(StatusLargeKey.Tag.ToString()))
			{
				activity.Assets ??= new();
				activity.Assets.LargeImageKey = StatusLargeKey.Text;
			}
			if (NotEmpty(StatusLargeText))
			{
				activity.Assets ??= new();
				activity.Assets.LargeImageText = StatusLargeText.Text;
			}
			if (!String.IsNullOrWhiteSpace(StatusSmallKey.Text) && String.IsNullOrEmpty(StatusSmallKey.Tag.ToString()))
			{
				activity.Assets ??= new();
				activity.Assets.SmallImageKey = StatusSmallKey.Text;
			}
			if (NotEmpty(StatusSmallText))
			{
				activity.Assets ??= new();
				activity.Assets.SmallImageText = StatusSmallText.Text;
			}


			DiscordRPC.Button? button1 = null;
			if (NotEmpty(StatusButton1Text) && NotEmpty(StatusButton1Url))
			{
				if (Uri.TryCreate(StatusButton1Url.Text, UriKind.Absolute, out Uri? newUri))
				{
					StatusButton1Url.Text = newUri.ToString();
					button1 = new()
					{
						Label = StatusButton1Text.Text,
						Url = StatusButton1Url.Text,
					};
				}
				else
				{
					MessageBox.Show("'" + StatusButton1Url.Text + "' не является ссылкой", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			DiscordRPC.Button? button2 = null;
			if (NotEmpty(StatusButton2Text) && NotEmpty(StatusButton2Url))
			{
				if (Uri.TryCreate(StatusButton2Url.Text, UriKind.Absolute, out Uri? newUri))
				{
					StatusButton2Url.Text = newUri.ToString();
					button2 = new()
					{
						Label = StatusButton2Text.Text,
						Url = StatusButton2Url.Text,
					};
				}
				else
				{
					MessageBox.Show("'" + StatusButton2Url.Text + "' не является ссылкой", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			if (button1 != null && button2 != null)
			{
				activity.Buttons = new[] { button1, button2 };
			}
			else
			{
				if (button1 != null)
				{
					activity.Buttons = new[] { button1 };
				}
				if (button2 != null)
				{
					activity.Buttons = new[] { button2 };
				}
			}

			if (NotEmpty(StatusPartyMatch) || NotEmpty(StatusPartyJoin) || NotEmpty(StatusPartySpectate))
			{
				if (button1 != null || button2 != null)
				{
					MessageBox.Show("При использовании кнопок нельзя использовать приглашения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				if (String.IsNullOrWhiteSpace(StatusPartyID.Text))
				{
					StatusPartyID.Text = "NULL";
				}
			}
			if (NotEmpty(StatusPartyMatch))
			{
				activity.Secrets ??= new();
				activity.Secrets.MatchSecret = StatusPartyMatch.Text;
			}
			if (NotEmpty(StatusPartyJoin))
			{
				activity.Secrets ??= new();
				activity.Secrets.JoinSecret = StatusPartyJoin.Text;
			}
			if (NotEmpty(StatusPartySpectate))
			{
				activity.Secrets ??= new();
				activity.Secrets.SpectateSecret = StatusPartySpectate.Text;
			}
			if (NotEmpty(StatusPartyID))
			{
				activity.Party ??= new();
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

			client.SetPresence(activity);

			string[] args = Environment.GetCommandLineArgs();
			SettingsSave(Path.GetDirectoryName(args[0]) + "/AutoSave");
		}
		private void TickVoid()
		{
			if (client.IsInitialized)
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
		private void SetIsCustomTime(bool NewValue)
		{
			StatusCustomTime.Enabled = NewValue;
			StatusHours.Enabled = !NewValue;
			StatusMinutes.Enabled = !NewValue;
			StatusSeconds.Enabled = !NewValue;
		}
		private async void ImageKeysUpdateVoid()
		{
			StatusLargeKey.Items.Clear();
			StatusLargeKey.DropDownHeight = 2;
			StatusSmallKey.Items.Clear();
			StatusSmallKey.DropDownHeight = 2;
			ImageKeysState.Text = "Загрузка ключей изображений";

			try
			{
				string assetsURL = "https://discordapp.com/api/oauth2/applications/" + AppIDBox.Text + "/assets";
				HttpResponseMessage message = await httpClient.GetAsync(assetsURL);
				message.EnsureSuccessStatusCode();
				JArray assets = JArray.Parse(await message.Content.ReadAsStringAsync());

				if (assets.Count > 0)
				{
					for (int i = 0; i < assets.Count; i++)
					{
						var assetName = assets[i]["name"];
						StatusLargeKey.Items.Add(assetName);
						StatusSmallKey.Items.Add(assetName);
					}

					if (assets.Count < 12)
					{
						StatusLargeKey.DropDownHeight = 2 + 24 * assets.Count;
						StatusSmallKey.DropDownHeight = 2 + 24 * assets.Count;
					}
					else
					{
						StatusLargeKey.DropDownHeight = 2 + 24 * 12;
						StatusSmallKey.DropDownHeight = 2 + 24 * 12;
					}

					ImageKeysState.Text = "Ключи изображений загружены";
				}
				else
				{
					ImageKeysState.Text = "У приложения отсутствуют изображения";
				}
			}
			catch (HttpRequestException error)
			{
				ImageKeysState.Text = "Ошибка загрузки ключей (" + error.StatusCode + ")";
			}
		}


		private void SettingsSave(string path)
		{
			StatusSettings settings = new()
			{
				IsElapsed = IsElapsed,
				IsPublic = IsPublic,
				CustomTimeEnabled = StatusIsCustomTime.Checked,
				CustomTime = ((DateTimeOffset)StatusCustomTime.Value).ToUnixTimeMilliseconds(),
				AppID = AppIDBox.Text,
				Details = StatusDetails.Text,
				State = StatusState.Text,
				PartyMin = StatusPartyMin.Text,
				PartyMax = StatusPartyMax.Text,
				Hours = StatusHours.Text,
				Minutes = StatusMinutes.Text,
				Seconds = StatusSeconds.Text,
				LargeText = StatusLargeText.Text,
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
			if (String.IsNullOrEmpty(StatusLargeKey.Tag.ToString()))
			{
				settings.LargeKey = StatusLargeKey.Text;
			}
			if (String.IsNullOrEmpty(StatusSmallKey.Tag.ToString()))
			{
				settings.SmallKey = StatusSmallKey.Text;
			}
			File.WriteAllText(path, JsonSerializer.Serialize(settings));
		}
		private void SettingsLoad(string path)
		{
			StatusSettings settings = new();
			if (path != "")
			{
				if (File.Exists(path))
				{
					settings = JsonSerializer.Deserialize<StatusSettings>(File.ReadAllText(path))!;
				}
			}
			else
			{
				if (client.IsInitialized)
				{
					StatusStopVoid();
				}
			}
			SetIsElapsed(settings.IsElapsed);
			SetIsPublic(settings.IsPublic);
			StatusIsCustomTime.Checked = settings.CustomTimeEnabled;
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
			ImageKeysUpdateVoid();
			PlaceholderLeave(StatusLargeKey, "Ключ большого изображения");
			PlaceholderLeave(StatusSmallKey, "Ключ малого изображения");
		}


		private static bool NotEmpty(TextBox textBox)
		{
			textBox.Text = textBox.Text.Trim();
			return !String.IsNullOrWhiteSpace(textBox.Text);
		}
		private static void TextToNumber(TextBox textBox, string oldText)
		{
			string newText = textBox.Text;
			if (String.IsNullOrEmpty(newText))
			{
				return;
			}
			if (Int64.TryParse(newText, out Int64 newInt) && newInt > 0)
			{
				if (newText == newInt.ToString())
				{
					return;
				}
				if (newText.Trim() == newInt.ToString())
				{
					oldText = newText.Trim();
				}
			}
			System.Media.SystemSounds.Exclamation.Play();
			int oldSelectionStart = textBox.SelectionStart;
			textBox.Text = oldText;
			int newSelectionStart = oldSelectionStart - (newText.Length - oldText.Length);
			if (newSelectionStart > 0)
			{
				textBox.SelectionStart = newSelectionStart;
			}
			else
			{
				textBox.SelectionStart = oldText.Length;
			}
		}
		private static string TextToInt(TextBox textBox, string oldText)
		{
			string newText = textBox.Text;
			if (String.IsNullOrEmpty(newText))
			{
				return textBox.Text;
			}
			if (Int32.TryParse(newText, out Int32 newInt) && newInt > 0)
			{
				if (newText == newInt.ToString())
				{
					return textBox.Text;
				}
				if (newText.Trim() == newInt.ToString())
				{
					oldText = newText.Trim();
				}
			}
			if (Int64.TryParse(newText, out Int64 newInt64) && newInt64 > 0)
			{
				if (newInt64 > Int32.MaxValue)
				{
					oldText = Int32.MaxValue.ToString();
				}
			}
			System.Media.SystemSounds.Exclamation.Play();
			int oldSelectionStart = textBox.SelectionStart;
			textBox.Text = oldText;
			int newSelectionStart = oldSelectionStart - (newText.Length - oldText.Length);
			if (newSelectionStart > 0)
			{
				textBox.SelectionStart = newSelectionStart;
			}
			else
			{
				textBox.SelectionStart = oldText.Length;
			}
			return textBox.Text;
		}

		private static void PlaceholderEnter(ComboBox comboBox)
		{
			if (comboBox.Tag != null && comboBox.Tag.ToString() == "Empty")
			{
				comboBox.ForeColor = Color.White;
				comboBox.Text = "";
				comboBox.Tag = "";
			}
		}
		private static void PlaceholderLeave(ComboBox comboBox, string placeholder)
		{
			if (String.IsNullOrEmpty(comboBox.Text))
			{
				comboBox.ForeColor = SystemColors.GrayText;
				comboBox.Text = placeholder;
				comboBox.Tag = "Empty";
			}
			else
			{
				comboBox.ForeColor = Color.White;
				comboBox.Tag = "";
			}
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