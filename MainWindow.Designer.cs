using DiscordStatus.Properties;

namespace DiscordStatus
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            AppIDBox = new TextBox();
            StatusStart = new Button();
            StatusDetails = new TextBox();
            StatusState = new TextBox();
            StatusPartyMin = new TextBox();
            PartyOfText = new Label();
            StatusPartyMax = new TextBox();
            TimerUpdate = new System.Windows.Forms.Timer(components);
            StatusUpdate = new Button();
            StatusElapsed = new Button();
            StatusRemaining = new Button();
            StatusHours = new TextBox();
            StatusMinutes = new TextBox();
            StatusSeconds = new TextBox();
            StatusLargeText = new TextBox();
            StatusSmallText = new TextBox();
            StatusButton1Text = new TextBox();
            StatusButton1Url = new TextBox();
            StatusButton2Text = new TextBox();
            StatusButton2Url = new TextBox();
            StatusStop = new Button();
            Menu = new MenuStrip();
            MenuLoad = new ToolStripMenuItem();
            MenuSave = new ToolStripMenuItem();
            MenuClear = new ToolStripMenuItem();
            MenuOpenGitHub = new ToolStripMenuItem();
            MenuExit = new ToolStripMenuItem();
            StatusPartyID = new TextBox();
            StatusPartyMatch = new TextBox();
            StatusPartyJoin = new TextBox();
            StatusPartySpectate = new TextBox();
            StatusPartyPrivacyText = new Label();
            StatusPartyPrivacyPublic = new Button();
            StatusPartyPrivacyPrivate = new Button();
            NotifyIcon = new NotifyIcon(components);
            NotifyMenu = new ContextMenuStrip(components);
            NotifyOpen = new ToolStripMenuItem();
            NotifyExit = new ToolStripMenuItem();
            StatusCustomTime = new DateTimePicker();
            StatusIsCustomTime = new CheckBox();
            Status = new StatusStrip();
            ImageKeysState = new ToolStripStatusLabel();
            ApplicationState = new ToolStripStatusLabel();
            StatusLargeKey = new ComboBox();
            StatusSmallKey = new ComboBox();
            ImageKeysUpdate = new Button();
            Menu.SuspendLayout();
            NotifyMenu.SuspendLayout();
            Status.SuspendLayout();
            SuspendLayout();
            // 
            // AppIDBox
            // 
            AppIDBox.BackColor = Color.FromArgb(64, 68, 75);
            AppIDBox.ForeColor = Color.White;
            AppIDBox.Location = new Point(16, 40);
            AppIDBox.MaxLength = 19;
            AppIDBox.Name = "AppIDBox";
            AppIDBox.PlaceholderText = "ID Приложения";
            AppIDBox.Size = new Size(234, 32);
            AppIDBox.TabIndex = 1;
            AppIDBox.TextChanged += AppIDBox_TextChanged;
            // 
            // StatusStart
            // 
            StatusStart.FlatStyle = FlatStyle.System;
            StatusStart.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            StatusStart.ForeColor = Color.Black;
            StatusStart.Location = new Point(258, 40);
            StatusStart.Name = "StatusStart";
            StatusStart.Size = new Size(135, 32);
            StatusStart.TabIndex = 2;
            StatusStart.Text = "Запустить";
            StatusStart.UseVisualStyleBackColor = true;
            StatusStart.Click += (s, e) => { StatusStartVoid(); };
            // 
            // StatusDetails
            // 
            StatusDetails.BackColor = Color.FromArgb(64, 68, 75);
            StatusDetails.ForeColor = Color.White;
            StatusDetails.Location = new Point(16, 88);
            StatusDetails.MaxLength = 64;
            StatusDetails.Name = "StatusDetails";
            StatusDetails.PlaceholderText = "Детали";
            StatusDetails.Size = new Size(512, 32);
            StatusDetails.TabIndex = 4;
            // 
            // StatusState
            // 
            StatusState.BackColor = Color.FromArgb(64, 68, 75);
            StatusState.ForeColor = Color.White;
            StatusState.Location = new Point(16, 128);
            StatusState.MaxLength = 64;
            StatusState.Name = "StatusState";
            StatusState.PlaceholderText = "Состояние";
            StatusState.Size = new Size(360, 32);
            StatusState.TabIndex = 5;
            // 
            // StatusPartyMin
            // 
            StatusPartyMin.BackColor = Color.FromArgb(64, 68, 75);
            StatusPartyMin.ForeColor = Color.White;
            StatusPartyMin.Location = new Point(384, 128);
            StatusPartyMin.MaxLength = 10;
            StatusPartyMin.Name = "StatusPartyMin";
            StatusPartyMin.PlaceholderText = "мин";
            StatusPartyMin.Size = new Size(56, 32);
            StatusPartyMin.TabIndex = 6;
            StatusPartyMin.TextAlign = HorizontalAlignment.Center;
            StatusPartyMin.TextChanged += StatusPartyMin_TextChanged;
            // 
            // PartyOfText
            // 
            PartyOfText.AutoSize = true;
            PartyOfText.ForeColor = Color.White;
            PartyOfText.Location = new Point(439, 132);
            PartyOfText.Name = "PartyOfText";
            PartyOfText.Size = new Size(34, 25);
            PartyOfText.TabIndex = 0;
            PartyOfText.Text = "из";
            PartyOfText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatusPartyMax
            // 
            StatusPartyMax.BackColor = Color.FromArgb(64, 68, 75);
            StatusPartyMax.ForeColor = Color.White;
            StatusPartyMax.Location = new Point(472, 128);
            StatusPartyMax.MaxLength = 10;
            StatusPartyMax.Name = "StatusPartyMax";
            StatusPartyMax.PlaceholderText = "макс";
            StatusPartyMax.Size = new Size(56, 32);
            StatusPartyMax.TabIndex = 7;
            StatusPartyMax.TextAlign = HorizontalAlignment.Center;
            StatusPartyMax.TextChanged += StatusPartyMax_TextChanged;
            // 
            // TimerUpdate
            // 
            TimerUpdate.Enabled = true;
            TimerUpdate.Tick += (s, e) => { TickVoid(); };
            // 
            // StatusUpdate
            // 
            StatusUpdate.FlatStyle = FlatStyle.System;
            StatusUpdate.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            StatusUpdate.ForeColor = Color.Black;
            StatusUpdate.Location = new Point(336, 568);
            StatusUpdate.Name = "StatusUpdate";
            StatusUpdate.Size = new Size(192, 48);
            StatusUpdate.TabIndex = 30;
            StatusUpdate.Text = "Обновить";
            StatusUpdate.UseVisualStyleBackColor = true;
            StatusUpdate.Click += (s, e) => { StatusUpdateVoid(); };
            // 
            // StatusElapsed
            // 
            StatusElapsed.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
            StatusElapsed.ForeColor = Color.Black;
            StatusElapsed.Location = new Point(16, 176);
            StatusElapsed.Name = "StatusElapsed";
            StatusElapsed.Size = new Size(117, 32);
            StatusElapsed.TabIndex = 8;
            StatusElapsed.Text = "Прошло";
            StatusElapsed.UseVisualStyleBackColor = true;
            StatusElapsed.Click += (s, e) => { SetIsElapsed(true); };
            // 
            // StatusRemaining
            // 
            StatusRemaining.BackColor = Color.FromArgb(64, 68, 75);
            StatusRemaining.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
            StatusRemaining.ForeColor = Color.White;
            StatusRemaining.Location = new Point(133, 176);
            StatusRemaining.Name = "StatusRemaining";
            StatusRemaining.Size = new Size(117, 32);
            StatusRemaining.TabIndex = 9;
            StatusRemaining.Text = "Осталось";
            StatusRemaining.UseVisualStyleBackColor = false;
            StatusRemaining.Click += (s, e) => { SetIsElapsed(false); };
            // 
            // StatusHours
            // 
            StatusHours.BackColor = Color.FromArgb(64, 68, 75);
            StatusHours.ForeColor = Color.White;
            StatusHours.Location = new Point(258, 176);
            StatusHours.MaxLength = 5;
            StatusHours.Name = "StatusHours";
            StatusHours.PlaceholderText = "Часы";
            StatusHours.Size = new Size(90, 32);
            StatusHours.TabIndex = 11;
            StatusHours.TextAlign = HorizontalAlignment.Center;
            StatusHours.TextChanged += StatusHours_TextChanged;
            // 
            // StatusMinutes
            // 
            StatusMinutes.BackColor = Color.FromArgb(64, 68, 75);
            StatusMinutes.ForeColor = Color.White;
            StatusMinutes.Location = new Point(348, 176);
            StatusMinutes.MaxLength = 5;
            StatusMinutes.Name = "StatusMinutes";
            StatusMinutes.PlaceholderText = "Мин.";
            StatusMinutes.Size = new Size(90, 32);
            StatusMinutes.TabIndex = 12;
            StatusMinutes.TextAlign = HorizontalAlignment.Center;
            StatusMinutes.TextChanged += StatusMinutes_TextChanged;
            // 
            // StatusSeconds
            // 
            StatusSeconds.BackColor = Color.FromArgb(64, 68, 75);
            StatusSeconds.ForeColor = Color.White;
            StatusSeconds.Location = new Point(438, 176);
            StatusSeconds.MaxLength = 5;
            StatusSeconds.Name = "StatusSeconds";
            StatusSeconds.PlaceholderText = "Сек.";
            StatusSeconds.Size = new Size(90, 32);
            StatusSeconds.TabIndex = 13;
            StatusSeconds.TextAlign = HorizontalAlignment.Center;
            StatusSeconds.TextChanged += StatusSeconds_TextChanged;
            // 
            // StatusLargeText
            // 
            StatusLargeText.BackColor = Color.FromArgb(64, 68, 75);
            StatusLargeText.ForeColor = Color.White;
            StatusLargeText.Location = new Point(258, 264);
            StatusLargeText.MaxLength = 64;
            StatusLargeText.Name = "StatusLargeText";
            StatusLargeText.PlaceholderText = "Текст большого изображения";
            StatusLargeText.Size = new Size(270, 32);
            StatusLargeText.TabIndex = 16;
            // 
            // StatusSmallText
            // 
            StatusSmallText.BackColor = Color.FromArgb(64, 68, 75);
            StatusSmallText.ForeColor = Color.White;
            StatusSmallText.Location = new Point(258, 304);
            StatusSmallText.MaxLength = 64;
            StatusSmallText.Name = "StatusSmallText";
            StatusSmallText.PlaceholderText = "Текст малого изображения";
            StatusSmallText.Size = new Size(270, 32);
            StatusSmallText.TabIndex = 18;
            // 
            // StatusButton1Text
            // 
            StatusButton1Text.BackColor = Color.FromArgb(64, 68, 75);
            StatusButton1Text.ForeColor = Color.White;
            StatusButton1Text.Location = new Point(16, 352);
            StatusButton1Text.MaxLength = 16;
            StatusButton1Text.Name = "StatusButton1Text";
            StatusButton1Text.PlaceholderText = "Название";
            StatusButton1Text.Size = new Size(128, 32);
            StatusButton1Text.TabIndex = 19;
            // 
            // StatusButton1Url
            // 
            StatusButton1Url.BackColor = Color.FromArgb(64, 68, 75);
            StatusButton1Url.ForeColor = Color.White;
            StatusButton1Url.Location = new Point(144, 352);
            StatusButton1Url.MaxLength = 256;
            StatusButton1Url.Name = "StatusButton1Url";
            StatusButton1Url.PlaceholderText = "Ссылка первой кнопки";
            StatusButton1Url.Size = new Size(384, 32);
            StatusButton1Url.TabIndex = 20;
            // 
            // StatusButton2Text
            // 
            StatusButton2Text.BackColor = Color.FromArgb(64, 68, 75);
            StatusButton2Text.ForeColor = Color.White;
            StatusButton2Text.Location = new Point(16, 392);
            StatusButton2Text.MaxLength = 16;
            StatusButton2Text.Name = "StatusButton2Text";
            StatusButton2Text.PlaceholderText = "Название";
            StatusButton2Text.Size = new Size(128, 32);
            StatusButton2Text.TabIndex = 21;
            // 
            // StatusButton2Url
            // 
            StatusButton2Url.BackColor = Color.FromArgb(64, 68, 75);
            StatusButton2Url.ForeColor = Color.White;
            StatusButton2Url.Location = new Point(144, 392);
            StatusButton2Url.MaxLength = 256;
            StatusButton2Url.Name = "StatusButton2Url";
            StatusButton2Url.PlaceholderText = "Ссылка второй кнопки";
            StatusButton2Url.Size = new Size(384, 32);
            StatusButton2Url.TabIndex = 22;
            // 
            // StatusStop
            // 
            StatusStop.Enabled = false;
            StatusStop.FlatStyle = FlatStyle.System;
            StatusStop.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            StatusStop.ForeColor = Color.Black;
            StatusStop.Location = new Point(393, 40);
            StatusStop.Name = "StatusStop";
            StatusStop.Size = new Size(135, 32);
            StatusStop.TabIndex = 3;
            StatusStop.Text = "Остановить";
            StatusStop.UseVisualStyleBackColor = true;
            StatusStop.Click += (s, e) => { StatusStopVoid(); };
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(47, 49, 54);
            Menu.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Menu.Items.AddRange(new ToolStripItem[] { MenuLoad, MenuSave, MenuClear, MenuOpenGitHub, MenuExit });
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(544, 24);
            Menu.TabIndex = 0;
            Menu.Text = "Меню";
            // 
            // MenuLoad
            // 
            MenuLoad.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MenuLoad.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MenuLoad.ForeColor = Color.White;
            MenuLoad.Name = "MenuLoad";
            MenuLoad.Size = new Size(68, 20);
            MenuLoad.Text = "Открыть";
            MenuLoad.Click += MenuLoad_Click;
            // 
            // MenuSave
            // 
            MenuSave.BackColor = Color.FromArgb(47, 49, 54);
            MenuSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MenuSave.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MenuSave.ForeColor = Color.White;
            MenuSave.Name = "MenuSave";
            MenuSave.Size = new Size(81, 20);
            MenuSave.Text = "Сохранить";
            MenuSave.Click += MenuSave_Click;
            // 
            // MenuClear
            // 
            MenuClear.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MenuClear.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MenuClear.ForeColor = Color.White;
            MenuClear.Name = "MenuClear";
            MenuClear.Size = new Size(73, 20);
            MenuClear.Text = "Очистить";
            MenuClear.Click += MenuClear_Click;
            // 
            // MenuOpenGitHub
            // 
            MenuOpenGitHub.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MenuOpenGitHub.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MenuOpenGitHub.ForeColor = Color.White;
            MenuOpenGitHub.Name = "MenuOpenGitHub";
            MenuOpenGitHub.Size = new Size(66, 20);
            MenuOpenGitHub.Text = "Помощь";
            MenuOpenGitHub.Click += MenuOpenGitHub_Click;
            // 
            // MenuExit
            // 
            MenuExit.Alignment = ToolStripItemAlignment.Right;
            MenuExit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MenuExit.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MenuExit.ForeColor = Color.White;
            MenuExit.Name = "MenuExit";
            MenuExit.Size = new Size(56, 20);
            MenuExit.Text = "Выйти";
            MenuExit.Click += MenuExit_Click;
            // 
            // StatusPartyID
            // 
            StatusPartyID.BackColor = Color.FromArgb(64, 68, 75);
            StatusPartyID.ForeColor = Color.White;
            StatusPartyID.Location = new Point(16, 440);
            StatusPartyID.MaxLength = 64;
            StatusPartyID.Name = "StatusPartyID";
            StatusPartyID.PlaceholderText = "ID Группы";
            StatusPartyID.Size = new Size(252, 32);
            StatusPartyID.TabIndex = 23;
            // 
            // StatusPartyMatch
            // 
            StatusPartyMatch.BackColor = Color.FromArgb(64, 68, 75);
            StatusPartyMatch.ForeColor = Color.White;
            StatusPartyMatch.Location = new Point(276, 440);
            StatusPartyMatch.MaxLength = 64;
            StatusPartyMatch.Name = "StatusPartyMatch";
            StatusPartyMatch.PlaceholderText = "Хэш матча";
            StatusPartyMatch.Size = new Size(252, 32);
            StatusPartyMatch.TabIndex = 24;
            // 
            // StatusPartyJoin
            // 
            StatusPartyJoin.BackColor = Color.FromArgb(64, 68, 75);
            StatusPartyJoin.ForeColor = Color.White;
            StatusPartyJoin.Location = new Point(16, 480);
            StatusPartyJoin.MaxLength = 64;
            StatusPartyJoin.Name = "StatusPartyJoin";
            StatusPartyJoin.PlaceholderText = "Хэш присоединения";
            StatusPartyJoin.Size = new Size(252, 32);
            StatusPartyJoin.TabIndex = 25;
            // 
            // StatusPartySpectate
            // 
            StatusPartySpectate.BackColor = Color.FromArgb(64, 68, 75);
            StatusPartySpectate.ForeColor = Color.White;
            StatusPartySpectate.Location = new Point(276, 480);
            StatusPartySpectate.MaxLength = 64;
            StatusPartySpectate.Name = "StatusPartySpectate";
            StatusPartySpectate.PlaceholderText = "Хэш наблюдения";
            StatusPartySpectate.Size = new Size(252, 32);
            StatusPartySpectate.TabIndex = 26;
            // 
            // StatusPartyPrivacyText
            // 
            StatusPartyPrivacyText.AutoSize = true;
            StatusPartyPrivacyText.ForeColor = Color.White;
            StatusPartyPrivacyText.Location = new Point(37, 524);
            StatusPartyPrivacyText.Name = "StatusPartyPrivacyText";
            StatusPartyPrivacyText.Size = new Size(129, 25);
            StatusPartyPrivacyText.TabIndex = 0;
            StatusPartyPrivacyText.Text = "Вид группы";
            // 
            // StatusPartyPrivacyPublic
            // 
            StatusPartyPrivacyPublic.ForeColor = Color.Black;
            StatusPartyPrivacyPublic.Location = new Point(188, 520);
            StatusPartyPrivacyPublic.Name = "StatusPartyPrivacyPublic";
            StatusPartyPrivacyPublic.Size = new Size(170, 32);
            StatusPartyPrivacyPublic.TabIndex = 27;
            StatusPartyPrivacyPublic.Text = "Открытая";
            StatusPartyPrivacyPublic.UseVisualStyleBackColor = true;
            StatusPartyPrivacyPublic.Click += (s, e) => { SetIsPublic(true); };
            // 
            // StatusPartyPrivacyPrivate
            // 
            StatusPartyPrivacyPrivate.BackColor = Color.FromArgb(64, 68, 75);
            StatusPartyPrivacyPrivate.ForeColor = Color.White;
            StatusPartyPrivacyPrivate.Location = new Point(358, 520);
            StatusPartyPrivacyPrivate.Name = "StatusPartyPrivacyPrivate";
            StatusPartyPrivacyPrivate.Size = new Size(170, 32);
            StatusPartyPrivacyPrivate.TabIndex = 28;
            StatusPartyPrivacyPrivate.Text = "Закрытая";
            StatusPartyPrivacyPrivate.UseVisualStyleBackColor = false;
            StatusPartyPrivacyPrivate.Click += (s, e) => { SetIsPublic(false); };
            // 
            // NotifyIcon
            // 
            NotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            NotifyIcon.BalloonTipText = "Discord Status";
            NotifyIcon.BalloonTipTitle = "Программа была свёрнута в трей";
            NotifyIcon.ContextMenuStrip = NotifyMenu;
            NotifyIcon.Icon = Resources.AppIcon;
            NotifyIcon.Text = "Discord Status";
            NotifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            // 
            // NotifyMenu
            // 
            NotifyMenu.BackColor = Color.FromArgb(47, 49, 54);
            NotifyMenu.Items.AddRange(new ToolStripItem[] { NotifyOpen, NotifyExit });
            NotifyMenu.Name = "NotifyMenu";
            NotifyMenu.ShowImageMargin = false;
            NotifyMenu.Size = new Size(97, 48);
            // 
            // NotifyOpen
            // 
            NotifyOpen.DisplayStyle = ToolStripItemDisplayStyle.Text;
            NotifyOpen.ForeColor = Color.White;
            NotifyOpen.Name = "NotifyOpen";
            NotifyOpen.Size = new Size(96, 22);
            NotifyOpen.Text = "Открыть";
            NotifyOpen.Click += NotifyOpen_Click;
            // 
            // NotifyExit
            // 
            NotifyExit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            NotifyExit.ForeColor = Color.White;
            NotifyExit.Name = "NotifyExit";
            NotifyExit.Size = new Size(96, 22);
            NotifyExit.Text = "Выйти";
            NotifyExit.Click += NotifyExit_Click;
            // 
            // StatusCustomTime
            // 
            StatusCustomTime.CalendarFont = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            StatusCustomTime.CustomFormat = " dd.MM.yyyy  HH:mm:ss";
            StatusCustomTime.Enabled = false;
            StatusCustomTime.Format = DateTimePickerFormat.Custom;
            StatusCustomTime.Location = new Point(258, 216);
            StatusCustomTime.MinDate = new DateTime(1969, 12, 31, 0, 0, 0, 0);
            StatusCustomTime.Name = "StatusCustomTime";
            StatusCustomTime.Size = new Size(270, 32);
            StatusCustomTime.TabIndex = 14;
            StatusCustomTime.Value = new DateTime(2022, 12, 12, 12, 0, 0, 0);
            // 
            // StatusIsCustomTime
            // 
            StatusIsCustomTime.AutoSize = true;
            StatusIsCustomTime.ForeColor = Color.White;
            StatusIsCustomTime.Location = new Point(54, 218);
            StatusIsCustomTime.Name = "StatusIsCustomTime";
            StatusIsCustomTime.Size = new Size(173, 29);
            StatusIsCustomTime.TabIndex = 10;
            StatusIsCustomTime.Text = "Точное время";
            StatusIsCustomTime.UseVisualStyleBackColor = true;
            StatusIsCustomTime.CheckedChanged += (s, e) => { SetIsCustomTime(((CheckBox)s).Checked); };
            // 
            // Status
            // 
            Status.BackColor = Color.FromArgb(47, 49, 54);
            Status.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Status.Items.AddRange(new ToolStripItem[] { ImageKeysState, ApplicationState });
            Status.Location = new Point(0, 632);
            Status.Name = "Status";
            Status.Size = new Size(544, 22);
            Status.SizingGrip = false;
            Status.TabIndex = 0;
            // 
            // ImageKeysState
            // 
            ImageKeysState.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ImageKeysState.ForeColor = SystemColors.GrayText;
            ImageKeysState.Name = "ImageKeysState";
            ImageKeysState.Size = new Size(448, 17);
            ImageKeysState.Spring = true;
            ImageKeysState.Text = "Ключи изображений устарели";
            ImageKeysState.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ApplicationState
            // 
            ApplicationState.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ApplicationState.ForeColor = SystemColors.GrayText;
            ApplicationState.Name = "ApplicationState";
            ApplicationState.Size = new Size(81, 17);
            ApplicationState.Text = "Не запущено";
            ApplicationState.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StatusLargeKey
            // 
            StatusLargeKey.BackColor = Color.FromArgb(64, 68, 75);
            StatusLargeKey.DropDownHeight = 2;
            StatusLargeKey.ForeColor = Color.White;
            StatusLargeKey.FormattingEnabled = true;
            StatusLargeKey.IntegralHeight = false;
            StatusLargeKey.Location = new Point(16, 264);
            StatusLargeKey.MaxLength = 128;
            StatusLargeKey.Name = "StatusLargeKey";
            StatusLargeKey.Size = new Size(242, 32);
            StatusLargeKey.TabIndex = 15;
            StatusLargeKey.Tag = "Empty";
            StatusLargeKey.Enter += (s, e) => { PlaceholderEnter((ComboBox)s); };
            StatusLargeKey.Leave += (s, e) => { PlaceholderLeave((ComboBox)s, "Ключ большого изображения"); };
            // 
            // StatusSmallKey
            // 
            StatusSmallKey.BackColor = Color.FromArgb(64, 68, 75);
            StatusSmallKey.DropDownHeight = 2;
            StatusSmallKey.ForeColor = Color.White;
            StatusSmallKey.FormattingEnabled = true;
            StatusSmallKey.IntegralHeight = false;
            StatusSmallKey.Location = new Point(16, 304);
            StatusSmallKey.MaxLength = 128;
            StatusSmallKey.Name = "StatusSmallKey";
            StatusSmallKey.Size = new Size(242, 32);
            StatusSmallKey.TabIndex = 17;
            StatusSmallKey.Tag = "Empty";
            StatusSmallKey.Enter += (s, e) => { PlaceholderEnter((ComboBox)s); };
            StatusSmallKey.Leave += (s, e) => { PlaceholderLeave((ComboBox)s, "Ключ малого изображения"); };
            // 
            // ImageKeysUpdate
            // 
            ImageKeysUpdate.FlatStyle = FlatStyle.System;
            ImageKeysUpdate.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            ImageKeysUpdate.ForeColor = Color.Black;
            ImageKeysUpdate.Location = new Point(16, 568);
            ImageKeysUpdate.Name = "ImageKeysUpdate";
            ImageKeysUpdate.Size = new Size(192, 48);
            ImageKeysUpdate.TabIndex = 29;
            ImageKeysUpdate.Text = "Обновить ключи изображений";
            ImageKeysUpdate.UseVisualStyleBackColor = true;
            ImageKeysUpdate.Click += (s, e) => { ImageKeysUpdateVoid(); };
            // 
            // MainWindow
            // 
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(544, 654);
            Controls.Add(ImageKeysUpdate);
            Controls.Add(StatusSmallKey);
            Controls.Add(StatusLargeKey);
            Controls.Add(Status);
            Controls.Add(StatusIsCustomTime);
            Controls.Add(StatusCustomTime);
            Controls.Add(StatusPartyPrivacyPrivate);
            Controls.Add(StatusPartyPrivacyPublic);
            Controls.Add(StatusPartyPrivacyText);
            Controls.Add(StatusPartySpectate);
            Controls.Add(StatusPartyJoin);
            Controls.Add(StatusPartyMatch);
            Controls.Add(StatusPartyID);
            Controls.Add(StatusStop);
            Controls.Add(StatusButton2Url);
            Controls.Add(StatusButton2Text);
            Controls.Add(StatusButton1Url);
            Controls.Add(StatusButton1Text);
            Controls.Add(StatusSmallText);
            Controls.Add(StatusLargeText);
            Controls.Add(StatusSeconds);
            Controls.Add(StatusMinutes);
            Controls.Add(StatusHours);
            Controls.Add(StatusRemaining);
            Controls.Add(StatusElapsed);
            Controls.Add(StatusUpdate);
            Controls.Add(StatusPartyMax);
            Controls.Add(StatusPartyMin);
            Controls.Add(StatusState);
            Controls.Add(StatusDetails);
            Controls.Add(StatusStart);
            Controls.Add(AppIDBox);
            Controls.Add(PartyOfText);
            Controls.Add(Menu);
            DoubleBuffered = true;
            Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.AppIcon;
            MainMenuStrip = Menu;
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Discord Status";
            FormClosing += MainWindow_FormClosing;
            DragDrop += MainWindow_DragDrop;
            DragEnter += MainWindow_DragEnter;
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            NotifyMenu.ResumeLayout(false);
            Status.ResumeLayout(false);
            Status.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox AppIDBox;
        private Button StatusStart;
        private TextBox StatusDetails;
        private TextBox StatusState;
        private TextBox StatusPartyMin;
        private Label PartyOfText;
        private TextBox StatusPartyMax;
        private System.Windows.Forms.Timer TimerUpdate;
        private Button StatusUpdate;
        private Button StatusElapsed;
        private Button StatusRemaining;
        private TextBox StatusHours;
        private TextBox StatusMinutes;
        private TextBox StatusSeconds;
        private TextBox StatusLargeText;
        private TextBox StatusSmallText;
        private TextBox StatusButton1Text;
        private TextBox StatusButton1Url;
        private TextBox StatusButton2Text;
        private TextBox StatusButton2Url;
        private Button StatusStop;
        private MenuStrip Menu;
        private ToolStripMenuItem MenuSave;
        private ToolStripMenuItem MenuLoad;
        private TextBox StatusPartyID;
        private TextBox StatusPartyMatch;
        private TextBox StatusPartyJoin;
        private TextBox StatusPartySpectate;
        private Label StatusPartyPrivacyText;
        private Button StatusPartyPrivacyPublic;
        private Button StatusPartyPrivacyPrivate;
        private ToolStripMenuItem MenuOpenGitHub;
        private NotifyIcon NotifyIcon;
        private ToolStripMenuItem MenuClear;
        private DateTimePicker StatusCustomTime;
        private CheckBox StatusIsCustomTime;
        private StatusStrip Status;
        private ToolStripStatusLabel ApplicationState;
        private ToolStripStatusLabel ImageKeysState;
        private ComboBox StatusLargeKey;
        private ComboBox StatusSmallKey;
        private Button ImageKeysUpdate;
        private ToolStripMenuItem MenuExit;
        private ContextMenuStrip NotifyMenu;
        private ToolStripMenuItem NotifyOpen;
        private ToolStripMenuItem NotifyExit;
    }
}