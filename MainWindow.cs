using System.Diagnostics;
using System.Text.Json;
using DiscordRPC;

namespace DiscordStatus
{
	public partial class MainWindow : Form
	{
		DiscordRpcClient client;
		bool IsElapsed = true, IsPublic = true;
		Int64 CurrentAppID = 0;

		public MainWindow() { InitializeComponent(); }

		private void StatusStart_Click(object sender, EventArgs e)
		{
			if (Int64.TryParse(AppIDBox.Text, out Int64 AppID))
			{
				if (client != null) { client.Dispose(); }
				client = new DiscordRpcClient(AppID.ToString());
				client.RegisterUriScheme();
				client.Initialize();
				CurrentAppID = AppID;
			} else { MessageBox.Show("ID Приложения указан неверно", "Ошибка"); return; }
		}

		private void StatusStop_Click(object sender, EventArgs e) { if (client != null) { client.Dispose(); } }

		private void StatusUpdate_Click(object sender, EventArgs e)
		{
			if (Int64.TryParse(AppIDBox.Text, out Int64 AppID) && CurrentAppID != AppID) { StatusStart_Click(null, null); }
			if (client == null || !client.IsInitialized) { StatusStart_Click(null, null); }
			if (client == null || !client.IsInitialized) { return; }
			
			RichPresence activity = new RichPresence();

			if (StatusDetails.Text != "") { activity.Details = StatusDetails.Text; }
			if (StatusState.Text != "") { activity.State = StatusState.Text; }
			if (StatusPartyMin.Text != "" && StatusPartyMax.Text != "")
			{
				if (Int32.TryParse(StatusPartyMin.Text, out Int32 PartyMin) && PartyMin > 0 &&
					Int32.TryParse(StatusPartyMax.Text, out Int32 PartyMax) && PartyMax > 0)
				{
					activity.Party = new Party();
					activity.Party.Size = PartyMin;
					activity.Party.Max = PartyMax;
				}
				else
				{ MessageBox.Show("Количество игроков должно быть целым положительным числом", "Ошибка"); return; }
			}
			if (StatusHours.Text != "" || StatusMinutes.Text != "" || StatusSeconds.Text != "")
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
					{ activity.Timestamps.StartUnixMilliseconds = (ulong)(Time - NewTime * 1000); }
					else
					{ activity.Timestamps.EndUnixMilliseconds = (ulong)(Time + NewTime * 1000); }
				}
				else
				{ MessageBox.Show("Время (Часы, Минуты, Секунды) должны быть числами", "Ошибка"); return; }
			}

			if (StatusLargeKey.Text != "")
			{
				if (activity.Assets == null) { activity.Assets = new Assets(); }
				activity.Assets.LargeImageKey = StatusLargeKey.Text;
			}
			if (StatusLargeText.Text != "")
			{
				if (activity.Assets == null) { activity.Assets = new Assets(); }
				activity.Assets.LargeImageText = StatusLargeText.Text;
			}
			if (StatusSmallKey.Text != "")
			{
				if (activity.Assets == null) { activity.Assets = new Assets(); }
				activity.Assets.SmallImageKey = StatusSmallKey.Text;
			}
			if (StatusSmallText.Text != "")
			{
				if (activity.Assets == null) { activity.Assets = new Assets(); }
				activity.Assets.SmallImageText = StatusSmallText.Text;
			}

			DiscordRPC.Button button1 = null;
			if (StatusButton1Text.Text != "" && StatusButton1Url.Text != "")
			{
				if (Uri.IsWellFormedUriString(StatusButton1Url.Text, UriKind.Absolute))
				{
					button1 = new DiscordRPC.Button()
					{
						Label = StatusButton1Text.Text,
						Url = StatusButton1Url.Text,
					};
				}
				else { MessageBox.Show('"' + StatusButton1Url.Text + "' не является ссылкой", "Ошибка"); return; }
			}
			DiscordRPC.Button button2 = null;
			if (StatusButton2Text.Text != "" && StatusButton2Url.Text != "")
			{
				if (Uri.IsWellFormedUriString(StatusButton2Url.Text, UriKind.Absolute))
				{
					button2 = new DiscordRPC.Button()
					{
						Label = StatusButton2Text.Text,
						Url = StatusButton2Url.Text,
					};
				} else { MessageBox.Show("'" + StatusButton2Url.Text + "' не является ссылкой", "Ошибка"); return; }
			}
			DiscordRPC.Button[] buttons = null;
			if (button1 != null && button2 != null)
			{
				buttons = new DiscordRPC.Button[] { button1, button2 };
			}
			else
			{
				if (button1 != null) { buttons = new DiscordRPC.Button[] { button1 }; }
				if (button2 != null) { buttons = new DiscordRPC.Button[] { button2 }; }
			}
			if (buttons != null) { activity.Buttons = buttons; }

			if (StatusPartyID.Text != "")
			{
				if (activity.Party == null) { activity.Party = new Party(); }
				activity.Party.ID = StatusPartyID.Text;
				if (IsPublic)
				{ activity.Party.Privacy = Party.PrivacySetting.Public; }
				else
				{ activity.Party.Privacy = Party.PrivacySetting.Private; }
			}
			if (StatusPartyMatch.Text != "")
			{
				if (activity.Secrets == null) { activity.Secrets = new Secrets(); }
				activity.Secrets.MatchSecret = StatusPartyMatch.Text;
			}
			if (StatusPartyJoin.Text != "")
			{
				if (buttons != null)
				{
					MessageBox.Show("При использовании кнопок нельзя использовать приглашения", "Ошибка"); return;
				}
				if (activity.Secrets == null) { activity.Secrets = new Secrets(); }
				activity.Secrets.JoinSecret = StatusPartyJoin.Text;
			}
			if (StatusPartySpectate.Text != "")
			{
				if (buttons != null)
				{
					MessageBox.Show("При использовании кнопок нельзя использовать приглашения", "Ошибка"); return;
				}
				if (activity.Secrets == null) { activity.Secrets = new Secrets(); }
				activity.Secrets.SpectateSecret = StatusPartySpectate.Text;
			}

			client.SetPresence(activity);
		}
		private void TimerUpdate_Tick(object sender, EventArgs e) { if (client != null) { client.Invoke(); } }

		private void StatusElapsed_Click(object sender, EventArgs e)
		{
			StatusElapsed.BackColor = Color.White;
			StatusElapsed.ForeColor = Color.FromArgb(255, 64, 68, 75);
			StatusRemaining.BackColor = Color.FromArgb(255, 64, 68, 75);
			StatusRemaining.ForeColor = Color.White;
			IsElapsed = true;
		}
		private void StatusRemaining_Click(object sender, EventArgs e)
		{
			StatusElapsed.BackColor = Color.FromArgb(255, 64, 68, 75);
			StatusElapsed.ForeColor = Color.White;
			StatusRemaining.BackColor = Color.White;
			StatusRemaining.ForeColor = Color.FromArgb(255, 64, 68, 75);
			IsElapsed = false;
		}

		private void StatusPartyPrivacyPublic_Click(object sender, EventArgs e)
		{
			StatusPartyPrivacyPublic.BackColor = Color.White;
			StatusPartyPrivacyPublic.ForeColor = Color.FromArgb(255, 64, 68, 75);
			StatusPartyPrivacyPrivate.BackColor = Color.FromArgb(255, 64, 68, 75);
			StatusPartyPrivacyPrivate.ForeColor = Color.White;
			IsPublic = true;
		}
		private void StatusPartyPrivacyPrivate_Click(object sender, EventArgs e)
		{
			StatusPartyPrivacyPublic.BackColor = Color.FromArgb(255, 64, 68, 75);
			StatusPartyPrivacyPublic.ForeColor = Color.White;
			StatusPartyPrivacyPrivate.BackColor = Color.White;
			StatusPartyPrivacyPrivate.ForeColor = Color.FromArgb(255, 64, 68, 75);
			IsPublic = false;
		}

		private void MenuSave_Click(object sender, EventArgs e)
		{
			StatusSettings settings = new StatusSettings
			{
				IsElapsed = IsElapsed,
				IsPublic = IsPublic,
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
			SaveFileDialog openFileDialog = new SaveFileDialog();
			openFileDialog.Filter = "Файл настроек (*.json)|*.json";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(openFileDialog.FileName, JsonSerializer.Serialize(settings));
			}
		}
		private void MenuLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Файл настроек (*.json)|*.json";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				StatusSettings settings = JsonSerializer.Deserialize<StatusSettings>(File.ReadAllText(openFileDialog.FileName))!;
				if (settings.IsElapsed) { StatusElapsed_Click(null, null); } else { StatusRemaining_Click(null, null); }
				if (settings.IsPublic) { StatusPartyPrivacyPublic_Click(null, null); } else { StatusPartyPrivacyPrivate_Click(null, null); }
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
		}

		private void MenuOpenGitHub_Click(object sender, EventArgs e)
		{ Process.Start(new ProcessStartInfo("https://github.com/pa-nov/Discord-Status") { UseShellExecute = true }); }
	}

	public class StatusSettings
	{
		public bool IsElapsed { get; set; } = true;
		public bool IsPublic { get; set; } = true;
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