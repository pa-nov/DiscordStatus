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
            this.components = new System.ComponentModel.Container();
            this.AppIDBox = new System.Windows.Forms.TextBox();
            this.StatusStart = new System.Windows.Forms.Button();
            this.StatusDetails = new System.Windows.Forms.TextBox();
            this.StatusState = new System.Windows.Forms.TextBox();
            this.StatusPartyMin = new System.Windows.Forms.TextBox();
            this.PartyOfText = new System.Windows.Forms.Label();
            this.StatusPartyMax = new System.Windows.Forms.TextBox();
            this.TimerUpdate = new System.Windows.Forms.Timer(this.components);
            this.StatusUpdate = new System.Windows.Forms.Button();
            this.StatusElapsed = new System.Windows.Forms.Button();
            this.StatusRemaining = new System.Windows.Forms.Button();
            this.StatusHours = new System.Windows.Forms.TextBox();
            this.StatusMinutes = new System.Windows.Forms.TextBox();
            this.StatusSeconds = new System.Windows.Forms.TextBox();
            this.StatusLargeText = new System.Windows.Forms.TextBox();
            this.StatusSmallText = new System.Windows.Forms.TextBox();
            this.StatusButton1Text = new System.Windows.Forms.TextBox();
            this.StatusButton1Url = new System.Windows.Forms.TextBox();
            this.StatusButton2Text = new System.Windows.Forms.TextBox();
            this.StatusButton2Url = new System.Windows.Forms.TextBox();
            this.StatusStop = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpenGitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusPartyID = new System.Windows.Forms.TextBox();
            this.StatusPartyMatch = new System.Windows.Forms.TextBox();
            this.StatusPartyJoin = new System.Windows.Forms.TextBox();
            this.StatusPartySpectate = new System.Windows.Forms.TextBox();
            this.StatusPartyPrivacyText = new System.Windows.Forms.Label();
            this.StatusPartyPrivacyPublic = new System.Windows.Forms.Button();
            this.StatusPartyPrivacyPrivate = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotifyOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusCustomTime = new System.Windows.Forms.DateTimePicker();
            this.StatusIsCustomTime = new System.Windows.Forms.CheckBox();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.ImageKeysState = new System.Windows.Forms.ToolStripStatusLabel();
            this.ApplicationState = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLargeKey = new System.Windows.Forms.ComboBox();
            this.StatusSmallKey = new System.Windows.Forms.ComboBox();
            this.ImageKeysUpdate = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.NotifyMenu.SuspendLayout();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppIDBox
            // 
            this.AppIDBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.AppIDBox.ForeColor = System.Drawing.Color.White;
            this.AppIDBox.Location = new System.Drawing.Point(16, 40);
            this.AppIDBox.MaxLength = 19;
            this.AppIDBox.Name = "AppIDBox";
            this.AppIDBox.PlaceholderText = "ID Приложения";
            this.AppIDBox.Size = new System.Drawing.Size(234, 32);
            this.AppIDBox.TabIndex = 1;
            this.AppIDBox.TextChanged += new System.EventHandler(this.AppIDBox_TextChanged);
            // 
            // StatusStart
            // 
            this.StatusStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StatusStart.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusStart.ForeColor = System.Drawing.Color.Black;
            this.StatusStart.Location = new System.Drawing.Point(258, 40);
            this.StatusStart.Name = "StatusStart";
            this.StatusStart.Size = new System.Drawing.Size(135, 32);
            this.StatusStart.TabIndex = 2;
            this.StatusStart.Text = "Запустить";
            this.StatusStart.UseVisualStyleBackColor = true;
            this.StatusStart.Click += new System.EventHandler(this.StatusStart_Click);
            // 
            // StatusDetails
            // 
            this.StatusDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusDetails.ForeColor = System.Drawing.Color.White;
            this.StatusDetails.Location = new System.Drawing.Point(16, 88);
            this.StatusDetails.MaxLength = 64;
            this.StatusDetails.Name = "StatusDetails";
            this.StatusDetails.PlaceholderText = "Детали";
            this.StatusDetails.Size = new System.Drawing.Size(512, 32);
            this.StatusDetails.TabIndex = 4;
            // 
            // StatusState
            // 
            this.StatusState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusState.ForeColor = System.Drawing.Color.White;
            this.StatusState.Location = new System.Drawing.Point(16, 128);
            this.StatusState.MaxLength = 64;
            this.StatusState.Name = "StatusState";
            this.StatusState.PlaceholderText = "Состояние";
            this.StatusState.Size = new System.Drawing.Size(360, 32);
            this.StatusState.TabIndex = 5;
            // 
            // StatusPartyMin
            // 
            this.StatusPartyMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusPartyMin.ForeColor = System.Drawing.Color.White;
            this.StatusPartyMin.Location = new System.Drawing.Point(384, 128);
            this.StatusPartyMin.MaxLength = 10;
            this.StatusPartyMin.Name = "StatusPartyMin";
            this.StatusPartyMin.PlaceholderText = "мин";
            this.StatusPartyMin.Size = new System.Drawing.Size(56, 32);
            this.StatusPartyMin.TabIndex = 6;
            this.StatusPartyMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusPartyMin.TextChanged += new System.EventHandler(this.StatusPartyMin_TextChanged);
            // 
            // PartyOfText
            // 
            this.PartyOfText.AutoSize = true;
            this.PartyOfText.ForeColor = System.Drawing.Color.White;
            this.PartyOfText.Location = new System.Drawing.Point(439, 132);
            this.PartyOfText.Name = "PartyOfText";
            this.PartyOfText.Size = new System.Drawing.Size(34, 25);
            this.PartyOfText.TabIndex = 0;
            this.PartyOfText.Text = "из";
            this.PartyOfText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusPartyMax
            // 
            this.StatusPartyMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusPartyMax.ForeColor = System.Drawing.Color.White;
            this.StatusPartyMax.Location = new System.Drawing.Point(472, 128);
            this.StatusPartyMax.MaxLength = 10;
            this.StatusPartyMax.Name = "StatusPartyMax";
            this.StatusPartyMax.PlaceholderText = "макс";
            this.StatusPartyMax.Size = new System.Drawing.Size(56, 32);
            this.StatusPartyMax.TabIndex = 7;
            this.StatusPartyMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusPartyMax.TextChanged += new System.EventHandler(this.StatusPartyMax_TextChanged);
            // 
            // TimerUpdate
            // 
            this.TimerUpdate.Enabled = true;
            this.TimerUpdate.Tick += new System.EventHandler(this.TimerUpdate_Tick);
            // 
            // StatusUpdate
            // 
            this.StatusUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StatusUpdate.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusUpdate.ForeColor = System.Drawing.Color.Black;
            this.StatusUpdate.Location = new System.Drawing.Point(336, 568);
            this.StatusUpdate.Name = "StatusUpdate";
            this.StatusUpdate.Size = new System.Drawing.Size(192, 48);
            this.StatusUpdate.TabIndex = 30;
            this.StatusUpdate.Text = "Обновить";
            this.StatusUpdate.UseVisualStyleBackColor = true;
            this.StatusUpdate.Click += new System.EventHandler(this.StatusUpdate_Click);
            // 
            // StatusElapsed
            // 
            this.StatusElapsed.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusElapsed.ForeColor = System.Drawing.Color.Black;
            this.StatusElapsed.Location = new System.Drawing.Point(16, 176);
            this.StatusElapsed.Name = "StatusElapsed";
            this.StatusElapsed.Size = new System.Drawing.Size(117, 32);
            this.StatusElapsed.TabIndex = 8;
            this.StatusElapsed.Text = "Прошло";
            this.StatusElapsed.UseVisualStyleBackColor = true;
            this.StatusElapsed.Click += new System.EventHandler(this.StatusElapsed_Click);
            // 
            // StatusRemaining
            // 
            this.StatusRemaining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusRemaining.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusRemaining.ForeColor = System.Drawing.Color.White;
            this.StatusRemaining.Location = new System.Drawing.Point(133, 176);
            this.StatusRemaining.Name = "StatusRemaining";
            this.StatusRemaining.Size = new System.Drawing.Size(117, 32);
            this.StatusRemaining.TabIndex = 9;
            this.StatusRemaining.Text = "Осталось";
            this.StatusRemaining.UseVisualStyleBackColor = false;
            this.StatusRemaining.Click += new System.EventHandler(this.StatusRemaining_Click);
            // 
            // StatusHours
            // 
            this.StatusHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusHours.ForeColor = System.Drawing.Color.White;
            this.StatusHours.Location = new System.Drawing.Point(258, 176);
            this.StatusHours.MaxLength = 5;
            this.StatusHours.Name = "StatusHours";
            this.StatusHours.PlaceholderText = "Часы";
            this.StatusHours.Size = new System.Drawing.Size(90, 32);
            this.StatusHours.TabIndex = 11;
            this.StatusHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusHours.TextChanged += new System.EventHandler(this.StatusHours_TextChanged);
            // 
            // StatusMinutes
            // 
            this.StatusMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusMinutes.ForeColor = System.Drawing.Color.White;
            this.StatusMinutes.Location = new System.Drawing.Point(348, 176);
            this.StatusMinutes.MaxLength = 5;
            this.StatusMinutes.Name = "StatusMinutes";
            this.StatusMinutes.PlaceholderText = "Мин.";
            this.StatusMinutes.Size = new System.Drawing.Size(90, 32);
            this.StatusMinutes.TabIndex = 12;
            this.StatusMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusMinutes.TextChanged += new System.EventHandler(this.StatusMinutes_TextChanged);
            // 
            // StatusSeconds
            // 
            this.StatusSeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusSeconds.ForeColor = System.Drawing.Color.White;
            this.StatusSeconds.Location = new System.Drawing.Point(438, 176);
            this.StatusSeconds.MaxLength = 5;
            this.StatusSeconds.Name = "StatusSeconds";
            this.StatusSeconds.PlaceholderText = "Сек.";
            this.StatusSeconds.Size = new System.Drawing.Size(90, 32);
            this.StatusSeconds.TabIndex = 13;
            this.StatusSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusSeconds.TextChanged += new System.EventHandler(this.StatusSeconds_TextChanged);
            // 
            // StatusLargeText
            // 
            this.StatusLargeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusLargeText.ForeColor = System.Drawing.Color.White;
            this.StatusLargeText.Location = new System.Drawing.Point(258, 264);
            this.StatusLargeText.MaxLength = 64;
            this.StatusLargeText.Name = "StatusLargeText";
            this.StatusLargeText.PlaceholderText = "Текст большого изображения";
            this.StatusLargeText.Size = new System.Drawing.Size(270, 32);
            this.StatusLargeText.TabIndex = 16;
            // 
            // StatusSmallText
            // 
            this.StatusSmallText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusSmallText.ForeColor = System.Drawing.Color.White;
            this.StatusSmallText.Location = new System.Drawing.Point(258, 304);
            this.StatusSmallText.MaxLength = 64;
            this.StatusSmallText.Name = "StatusSmallText";
            this.StatusSmallText.PlaceholderText = "Текст малого изображения";
            this.StatusSmallText.Size = new System.Drawing.Size(270, 32);
            this.StatusSmallText.TabIndex = 18;
            // 
            // StatusButton1Text
            // 
            this.StatusButton1Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusButton1Text.ForeColor = System.Drawing.Color.White;
            this.StatusButton1Text.Location = new System.Drawing.Point(16, 352);
            this.StatusButton1Text.MaxLength = 16;
            this.StatusButton1Text.Name = "StatusButton1Text";
            this.StatusButton1Text.PlaceholderText = "Название";
            this.StatusButton1Text.Size = new System.Drawing.Size(128, 32);
            this.StatusButton1Text.TabIndex = 19;
            // 
            // StatusButton1Url
            // 
            this.StatusButton1Url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusButton1Url.ForeColor = System.Drawing.Color.White;
            this.StatusButton1Url.Location = new System.Drawing.Point(144, 352);
            this.StatusButton1Url.MaxLength = 256;
            this.StatusButton1Url.Name = "StatusButton1Url";
            this.StatusButton1Url.PlaceholderText = "Ссылка первой кнопки";
            this.StatusButton1Url.Size = new System.Drawing.Size(384, 32);
            this.StatusButton1Url.TabIndex = 20;
            // 
            // StatusButton2Text
            // 
            this.StatusButton2Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusButton2Text.ForeColor = System.Drawing.Color.White;
            this.StatusButton2Text.Location = new System.Drawing.Point(16, 392);
            this.StatusButton2Text.MaxLength = 16;
            this.StatusButton2Text.Name = "StatusButton2Text";
            this.StatusButton2Text.PlaceholderText = "Название";
            this.StatusButton2Text.Size = new System.Drawing.Size(128, 32);
            this.StatusButton2Text.TabIndex = 21;
            // 
            // StatusButton2Url
            // 
            this.StatusButton2Url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusButton2Url.ForeColor = System.Drawing.Color.White;
            this.StatusButton2Url.Location = new System.Drawing.Point(144, 392);
            this.StatusButton2Url.MaxLength = 256;
            this.StatusButton2Url.Name = "StatusButton2Url";
            this.StatusButton2Url.PlaceholderText = "Ссылка второй кнопки";
            this.StatusButton2Url.Size = new System.Drawing.Size(384, 32);
            this.StatusButton2Url.TabIndex = 22;
            // 
            // StatusStop
            // 
            this.StatusStop.Enabled = false;
            this.StatusStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StatusStop.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusStop.ForeColor = System.Drawing.Color.Black;
            this.StatusStop.Location = new System.Drawing.Point(393, 40);
            this.StatusStop.Name = "StatusStop";
            this.StatusStop.Size = new System.Drawing.Size(135, 32);
            this.StatusStop.TabIndex = 3;
            this.StatusStop.Text = "Остановить";
            this.StatusStop.UseVisualStyleBackColor = true;
            this.StatusStop.Click += new System.EventHandler(this.StatusStop_Click);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.Menu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuLoad, this.MenuSave, this.MenuClear, this.MenuOpenGitHub, this.MenuExit });
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(544, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Меню";
            // 
            // MenuLoad
            // 
            this.MenuLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuLoad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MenuLoad.ForeColor = System.Drawing.Color.White;
            this.MenuLoad.Name = "MenuLoad";
            this.MenuLoad.Size = new System.Drawing.Size(68, 20);
            this.MenuLoad.Text = "Открыть";
            this.MenuLoad.Click += new System.EventHandler(this.MenuLoad_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.MenuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MenuSave.ForeColor = System.Drawing.Color.White;
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(81, 20);
            this.MenuSave.Text = "Сохранить";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuClear
            // 
            this.MenuClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuClear.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MenuClear.ForeColor = System.Drawing.Color.White;
            this.MenuClear.Name = "MenuClear";
            this.MenuClear.Size = new System.Drawing.Size(73, 20);
            this.MenuClear.Text = "Очистить";
            this.MenuClear.Click += new System.EventHandler(this.MenuClear_Click);
            // 
            // MenuOpenGitHub
            // 
            this.MenuOpenGitHub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuOpenGitHub.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MenuOpenGitHub.ForeColor = System.Drawing.Color.White;
            this.MenuOpenGitHub.Name = "MenuOpenGitHub";
            this.MenuOpenGitHub.Size = new System.Drawing.Size(66, 20);
            this.MenuOpenGitHub.Text = "Помощь";
            this.MenuOpenGitHub.Click += new System.EventHandler(this.MenuOpenGitHub_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MenuExit.ForeColor = System.Drawing.Color.White;
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(56, 20);
            this.MenuExit.Text = "Выйти";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // StatusPartyID
            // 
            this.StatusPartyID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusPartyID.ForeColor = System.Drawing.Color.White;
            this.StatusPartyID.Location = new System.Drawing.Point(16, 440);
            this.StatusPartyID.MaxLength = 64;
            this.StatusPartyID.Name = "StatusPartyID";
            this.StatusPartyID.PlaceholderText = "ID Группы";
            this.StatusPartyID.Size = new System.Drawing.Size(252, 32);
            this.StatusPartyID.TabIndex = 23;
            // 
            // StatusPartyMatch
            // 
            this.StatusPartyMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusPartyMatch.ForeColor = System.Drawing.Color.White;
            this.StatusPartyMatch.Location = new System.Drawing.Point(276, 440);
            this.StatusPartyMatch.MaxLength = 64;
            this.StatusPartyMatch.Name = "StatusPartyMatch";
            this.StatusPartyMatch.PlaceholderText = "Хэш матча";
            this.StatusPartyMatch.Size = new System.Drawing.Size(252, 32);
            this.StatusPartyMatch.TabIndex = 24;
            // 
            // StatusPartyJoin
            // 
            this.StatusPartyJoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusPartyJoin.ForeColor = System.Drawing.Color.White;
            this.StatusPartyJoin.Location = new System.Drawing.Point(16, 480);
            this.StatusPartyJoin.MaxLength = 64;
            this.StatusPartyJoin.Name = "StatusPartyJoin";
            this.StatusPartyJoin.PlaceholderText = "Хэш присоединения";
            this.StatusPartyJoin.Size = new System.Drawing.Size(252, 32);
            this.StatusPartyJoin.TabIndex = 25;
            // 
            // StatusPartySpectate
            // 
            this.StatusPartySpectate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusPartySpectate.ForeColor = System.Drawing.Color.White;
            this.StatusPartySpectate.Location = new System.Drawing.Point(276, 480);
            this.StatusPartySpectate.MaxLength = 64;
            this.StatusPartySpectate.Name = "StatusPartySpectate";
            this.StatusPartySpectate.PlaceholderText = "Хэш наблюдения";
            this.StatusPartySpectate.Size = new System.Drawing.Size(252, 32);
            this.StatusPartySpectate.TabIndex = 26;
            // 
            // StatusPartyPrivacyText
            // 
            this.StatusPartyPrivacyText.AutoSize = true;
            this.StatusPartyPrivacyText.ForeColor = System.Drawing.Color.White;
            this.StatusPartyPrivacyText.Location = new System.Drawing.Point(37, 524);
            this.StatusPartyPrivacyText.Name = "StatusPartyPrivacyText";
            this.StatusPartyPrivacyText.Size = new System.Drawing.Size(129, 25);
            this.StatusPartyPrivacyText.TabIndex = 0;
            this.StatusPartyPrivacyText.Text = "Вид группы";
            // 
            // StatusPartyPrivacyPublic
            // 
            this.StatusPartyPrivacyPublic.ForeColor = System.Drawing.Color.Black;
            this.StatusPartyPrivacyPublic.Location = new System.Drawing.Point(188, 520);
            this.StatusPartyPrivacyPublic.Name = "StatusPartyPrivacyPublic";
            this.StatusPartyPrivacyPublic.Size = new System.Drawing.Size(170, 32);
            this.StatusPartyPrivacyPublic.TabIndex = 27;
            this.StatusPartyPrivacyPublic.Text = "Открытая";
            this.StatusPartyPrivacyPublic.UseVisualStyleBackColor = true;
            this.StatusPartyPrivacyPublic.Click += new System.EventHandler(this.StatusPartyPrivacyPublic_Click);
            // 
            // StatusPartyPrivacyPrivate
            // 
            this.StatusPartyPrivacyPrivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusPartyPrivacyPrivate.ForeColor = System.Drawing.Color.White;
            this.StatusPartyPrivacyPrivate.Location = new System.Drawing.Point(358, 520);
            this.StatusPartyPrivacyPrivate.Name = "StatusPartyPrivacyPrivate";
            this.StatusPartyPrivacyPrivate.Size = new System.Drawing.Size(170, 32);
            this.StatusPartyPrivacyPrivate.TabIndex = 28;
            this.StatusPartyPrivacyPrivate.Text = "Закрытая";
            this.StatusPartyPrivacyPrivate.UseVisualStyleBackColor = false;
            this.StatusPartyPrivacyPrivate.Click += new System.EventHandler(this.StatusPartyPrivacyPrivate_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon.BalloonTipText = "Discord Status";
            this.NotifyIcon.BalloonTipTitle = "Программа была свёрнута в трей";
            this.NotifyIcon.ContextMenuStrip = this.NotifyMenu;
            this.NotifyIcon.Icon = Resources.AppIcon;
            this.NotifyIcon.Text = "Discord Status";
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.NotifyOpen, this.NotifyExit });
            this.NotifyMenu.Name = "NotifyMenu";
            this.NotifyMenu.ShowImageMargin = false;
            this.NotifyMenu.Size = new System.Drawing.Size(97, 48);
            // 
            // NotifyOpen
            // 
            this.NotifyOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NotifyOpen.ForeColor = System.Drawing.Color.White;
            this.NotifyOpen.Name = "NotifyOpen";
            this.NotifyOpen.Size = new System.Drawing.Size(96, 22);
            this.NotifyOpen.Text = "Открыть";
            this.NotifyOpen.Click += new System.EventHandler(this.NotifyOpen_Click);
            // 
            // NotifyExit
            // 
            this.NotifyExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NotifyExit.ForeColor = System.Drawing.Color.White;
            this.NotifyExit.Name = "NotifyExit";
            this.NotifyExit.Size = new System.Drawing.Size(96, 22);
            this.NotifyExit.Text = "Выйти";
            this.NotifyExit.Click += new System.EventHandler(this.NotifyExit_Click);
            // 
            // StatusCustomTime
            // 
            this.StatusCustomTime.CalendarFont = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusCustomTime.CustomFormat = " dd.MM.yyyy  HH:mm:ss";
            this.StatusCustomTime.Enabled = false;
            this.StatusCustomTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StatusCustomTime.Location = new System.Drawing.Point(258, 216);
            this.StatusCustomTime.MinDate = new System.DateTime(1969, 12, 31, 0, 0, 0, 0);
            this.StatusCustomTime.Name = "StatusCustomTime";
            this.StatusCustomTime.Size = new System.Drawing.Size(270, 32);
            this.StatusCustomTime.TabIndex = 14;
            this.StatusCustomTime.Value = new System.DateTime(2022, 12, 12, 12, 0, 0, 0);
            // 
            // StatusIsCustomTime
            // 
            this.StatusIsCustomTime.AutoSize = true;
            this.StatusIsCustomTime.ForeColor = System.Drawing.Color.White;
            this.StatusIsCustomTime.Location = new System.Drawing.Point(54, 218);
            this.StatusIsCustomTime.Name = "StatusIsCustomTime";
            this.StatusIsCustomTime.Size = new System.Drawing.Size(173, 29);
            this.StatusIsCustomTime.TabIndex = 10;
            this.StatusIsCustomTime.Text = "Точное время";
            this.StatusIsCustomTime.UseVisualStyleBackColor = true;
            this.StatusIsCustomTime.CheckedChanged += new System.EventHandler(this.StatusIsCustomTime_CheckedChanged);
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.Status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ImageKeysState, this.ApplicationState });
            this.Status.Location = new System.Drawing.Point(0, 632);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(544, 22);
            this.Status.SizingGrip = false;
            this.Status.TabIndex = 0;
            // 
            // ImageKeysState
            // 
            this.ImageKeysState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ImageKeysState.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ImageKeysState.Name = "ImageKeysState";
            this.ImageKeysState.Size = new System.Drawing.Size(448, 17);
            this.ImageKeysState.Spring = true;
            this.ImageKeysState.Text = "Ключи изображений устарели";
            this.ImageKeysState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ApplicationState
            // 
            this.ApplicationState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ApplicationState.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ApplicationState.Name = "ApplicationState";
            this.ApplicationState.Size = new System.Drawing.Size(81, 17);
            this.ApplicationState.Text = "Не запущено";
            this.ApplicationState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StatusLargeKey
            // 
            this.StatusLargeKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusLargeKey.DropDownHeight = 2;
            this.StatusLargeKey.ForeColor = System.Drawing.Color.White;
            this.StatusLargeKey.FormattingEnabled = true;
            this.StatusLargeKey.IntegralHeight = false;
            this.StatusLargeKey.Location = new System.Drawing.Point(16, 264);
            this.StatusLargeKey.MaxLength = 128;
            this.StatusLargeKey.Name = "StatusLargeKey";
            this.StatusLargeKey.Size = new System.Drawing.Size(242, 32);
            this.StatusLargeKey.TabIndex = 15;
            this.StatusLargeKey.Tag = "Empty";
            this.StatusLargeKey.Enter += new System.EventHandler(this.StatusLargeKey_Enter);
            this.StatusLargeKey.Leave += new System.EventHandler(this.StatusLargeKey_Leave);
            // 
            // StatusSmallKey
            // 
            this.StatusSmallKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.StatusSmallKey.DropDownHeight = 2;
            this.StatusSmallKey.ForeColor = System.Drawing.Color.White;
            this.StatusSmallKey.FormattingEnabled = true;
            this.StatusSmallKey.IntegralHeight = false;
            this.StatusSmallKey.Location = new System.Drawing.Point(16, 304);
            this.StatusSmallKey.MaxLength = 128;
            this.StatusSmallKey.Name = "StatusSmallKey";
            this.StatusSmallKey.Size = new System.Drawing.Size(242, 32);
            this.StatusSmallKey.TabIndex = 17;
            this.StatusSmallKey.Tag = "Empty";
            this.StatusSmallKey.Enter += new System.EventHandler(this.StatusSmallKey_Enter);
            this.StatusSmallKey.Leave += new System.EventHandler(this.StatusSmallKey_Leave);
            // 
            // ImageKeysUpdate
            // 
            this.ImageKeysUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ImageKeysUpdate.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ImageKeysUpdate.ForeColor = System.Drawing.Color.Black;
            this.ImageKeysUpdate.Location = new System.Drawing.Point(16, 568);
            this.ImageKeysUpdate.Name = "ImageKeysUpdate";
            this.ImageKeysUpdate.Size = new System.Drawing.Size(192, 48);
            this.ImageKeysUpdate.TabIndex = 29;
            this.ImageKeysUpdate.Text = "Обновить ключи изображений";
            this.ImageKeysUpdate.UseVisualStyleBackColor = true;
            this.ImageKeysUpdate.Click += new System.EventHandler(this.ImageKeysUpdate_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(544, 654);
            this.Controls.Add(this.ImageKeysUpdate);
            this.Controls.Add(this.StatusSmallKey);
            this.Controls.Add(this.StatusLargeKey);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.StatusIsCustomTime);
            this.Controls.Add(this.StatusCustomTime);
            this.Controls.Add(this.StatusPartyPrivacyPrivate);
            this.Controls.Add(this.StatusPartyPrivacyPublic);
            this.Controls.Add(this.StatusPartyPrivacyText);
            this.Controls.Add(this.StatusPartySpectate);
            this.Controls.Add(this.StatusPartyJoin);
            this.Controls.Add(this.StatusPartyMatch);
            this.Controls.Add(this.StatusPartyID);
            this.Controls.Add(this.StatusStop);
            this.Controls.Add(this.StatusButton2Url);
            this.Controls.Add(this.StatusButton2Text);
            this.Controls.Add(this.StatusButton1Url);
            this.Controls.Add(this.StatusButton1Text);
            this.Controls.Add(this.StatusSmallText);
            this.Controls.Add(this.StatusLargeText);
            this.Controls.Add(this.StatusSeconds);
            this.Controls.Add(this.StatusMinutes);
            this.Controls.Add(this.StatusHours);
            this.Controls.Add(this.StatusRemaining);
            this.Controls.Add(this.StatusElapsed);
            this.Controls.Add(this.StatusUpdate);
            this.Controls.Add(this.StatusPartyMax);
            this.Controls.Add(this.StatusPartyMin);
            this.Controls.Add(this.StatusState);
            this.Controls.Add(this.StatusDetails);
            this.Controls.Add(this.StatusStart);
            this.Controls.Add(this.AppIDBox);
            this.Controls.Add(this.PartyOfText);
            this.Controls.Add(this.Menu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = Resources.AppIcon;
            this.MainMenuStrip = this.Menu;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Discord Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.NotifyMenu.ResumeLayout(false);
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
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