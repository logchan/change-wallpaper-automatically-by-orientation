namespace DesktopWallpaperAutoSwitch
{
    partial class ConfigForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuShowConfigWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDesktopOriTitle = new System.Windows.Forms.Label();
            this.lblDesktopOri = new System.Windows.Forms.Label();
            this.lblLandscapeImgTitle = new System.Windows.Forms.Label();
            this.btnChooseLandscapeImg = new System.Windows.Forms.Button();
            this.btnChosePortraitImg = new System.Windows.Forms.Button();
            this.lblPortraitImgTitle = new System.Windows.Forms.Label();
            this.lblMinimizeInfo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblOpenfileInfo = new System.Windows.Forms.Label();
            this.comboChooseLanguage = new System.Windows.Forms.ComboBox();
            this.chkRunWithWindows = new System.Windows.Forms.CheckBox();
            this.btnPicposLandscape = new System.Windows.Forms.Button();
            this.btnPicposPortrait = new System.Windows.Forms.Button();
            this.btnOrientationWrong = new System.Windows.Forms.Button();
            this.btnHideWnd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblBgBorder = new System.Windows.Forms.Label();
            this.picboxLandscape = new System.Windows.Forms.PictureBox();
            this.picboxPortrait = new System.Windows.Forms.PictureBox();
            this.lblVersionTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkHomepage = new System.Windows.Forms.LinkLabel();
            this.lnkGithub = new System.Windows.Forms.LinkLabel();
            this.lnkThanks = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLandscape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPortrait)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "Backgound Auto Switch";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowConfigWindow,
            this.toolStripSeparator1,
            this.menuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 54);
            // 
            // menuShowConfigWindow
            // 
            this.menuShowConfigWindow.Name = "menuShowConfigWindow";
            this.menuShowConfigWindow.Size = new System.Drawing.Size(189, 22);
            this.menuShowConfigWindow.Text = "Show Config Window";
            this.menuShowConfigWindow.Click += new System.EventHandler(this.menuShowConfigWindow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(189, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // lblDesktopOriTitle
            // 
            this.lblDesktopOriTitle.AutoSize = true;
            this.lblDesktopOriTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesktopOriTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDesktopOriTitle.Location = new System.Drawing.Point(12, 9);
            this.lblDesktopOriTitle.Name = "lblDesktopOriTitle";
            this.lblDesktopOriTitle.Size = new System.Drawing.Size(169, 21);
            this.lblDesktopOriTitle.TabIndex = 0;
            this.lblDesktopOriTitle.Text = "Desktop Orientation:";
            // 
            // lblDesktopOri
            // 
            this.lblDesktopOri.AutoSize = true;
            this.lblDesktopOri.BackColor = System.Drawing.Color.Transparent;
            this.lblDesktopOri.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDesktopOri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblDesktopOri.Location = new System.Drawing.Point(187, 9);
            this.lblDesktopOri.Name = "lblDesktopOri";
            this.lblDesktopOri.Size = new System.Drawing.Size(94, 22);
            this.lblDesktopOri.TabIndex = 1;
            this.lblDesktopOri.Text = "Landscape";
            // 
            // lblLandscapeImgTitle
            // 
            this.lblLandscapeImgTitle.AutoSize = true;
            this.lblLandscapeImgTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLandscapeImgTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLandscapeImgTitle.Location = new System.Drawing.Point(11, 50);
            this.lblLandscapeImgTitle.Name = "lblLandscapeImgTitle";
            this.lblLandscapeImgTitle.Size = new System.Drawing.Size(143, 21);
            this.lblLandscapeImgTitle.TabIndex = 2;
            this.lblLandscapeImgTitle.Text = "Landscape Image";
            // 
            // btnChooseLandscapeImg
            // 
            this.btnChooseLandscapeImg.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChooseLandscapeImg.Location = new System.Drawing.Point(15, 281);
            this.btnChooseLandscapeImg.Name = "btnChooseLandscapeImg";
            this.btnChooseLandscapeImg.Size = new System.Drawing.Size(117, 88);
            this.btnChooseLandscapeImg.TabIndex = 3;
            this.btnChooseLandscapeImg.Text = "Choose";
            this.btnChooseLandscapeImg.UseVisualStyleBackColor = true;
            this.btnChooseLandscapeImg.Click += new System.EventHandler(this.btnChooseLandscapeImg_Click);
            // 
            // btnChosePortraitImg
            // 
            this.btnChosePortraitImg.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChosePortraitImg.Location = new System.Drawing.Point(221, 281);
            this.btnChosePortraitImg.Name = "btnChosePortraitImg";
            this.btnChosePortraitImg.Size = new System.Drawing.Size(117, 88);
            this.btnChosePortraitImg.TabIndex = 5;
            this.btnChosePortraitImg.Text = "Choose";
            this.btnChosePortraitImg.UseVisualStyleBackColor = true;
            this.btnChosePortraitImg.Click += new System.EventHandler(this.btnChosePortraitImg_Click);
            // 
            // lblPortraitImgTitle
            // 
            this.lblPortraitImgTitle.AutoSize = true;
            this.lblPortraitImgTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPortraitImgTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPortraitImgTitle.Location = new System.Drawing.Point(217, 50);
            this.lblPortraitImgTitle.Name = "lblPortraitImgTitle";
            this.lblPortraitImgTitle.Size = new System.Drawing.Size(120, 21);
            this.lblPortraitImgTitle.TabIndex = 4;
            this.lblPortraitImgTitle.Text = "Portrait Image";
            // 
            // lblMinimizeInfo
            // 
            this.lblMinimizeInfo.AutoSize = true;
            this.lblMinimizeInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimizeInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.lblMinimizeInfo.Location = new System.Drawing.Point(15, 393);
            this.lblMinimizeInfo.Name = "lblMinimizeInfo";
            this.lblMinimizeInfo.Size = new System.Drawing.Size(273, 17);
            this.lblMinimizeInfo.TabIndex = 8;
            this.lblMinimizeInfo.Text = "This window will minimize to notification area.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图片文件|*.jpg;*.png;*.jpeg;*.bmp";
            // 
            // lblOpenfileInfo
            // 
            this.lblOpenfileInfo.AutoSize = true;
            this.lblOpenfileInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblOpenfileInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.lblOpenfileInfo.Location = new System.Drawing.Point(15, 372);
            this.lblOpenfileInfo.Name = "lblOpenfileInfo";
            this.lblOpenfileInfo.Size = new System.Drawing.Size(184, 17);
            this.lblOpenfileInfo.TabIndex = 10;
            this.lblOpenfileInfo.Text = "Click on the picture to open it.";
            // 
            // comboChooseLanguage
            // 
            this.comboChooseLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChooseLanguage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.comboChooseLanguage.FormattingEnabled = true;
            this.comboChooseLanguage.ItemHeight = 17;
            this.comboChooseLanguage.Location = new System.Drawing.Point(294, 382);
            this.comboChooseLanguage.Name = "comboChooseLanguage";
            this.comboChooseLanguage.Size = new System.Drawing.Size(127, 25);
            this.comboChooseLanguage.TabIndex = 11;
            this.comboChooseLanguage.SelectedIndexChanged += new System.EventHandler(this.comboChooseLanguage_SelectedIndexChanged);
            // 
            // chkRunWithWindows
            // 
            this.chkRunWithWindows.Location = new System.Drawing.Point(440, 383);
            this.chkRunWithWindows.Name = "chkRunWithWindows";
            this.chkRunWithWindows.Size = new System.Drawing.Size(171, 25);
            this.chkRunWithWindows.TabIndex = 12;
            this.chkRunWithWindows.Text = "Run when windows starts";
            this.chkRunWithWindows.UseVisualStyleBackColor = true;
            this.chkRunWithWindows.CheckedChanged += new System.EventHandler(this.chkRunWithWindows_CheckedChanged);
            // 
            // btnPicposLandscape
            // 
            this.btnPicposLandscape.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPicposLandscape.Location = new System.Drawing.Point(138, 281);
            this.btnPicposLandscape.Name = "btnPicposLandscape";
            this.btnPicposLandscape.Size = new System.Drawing.Size(77, 88);
            this.btnPicposLandscape.TabIndex = 13;
            this.btnPicposLandscape.Text = "Fill";
            this.btnPicposLandscape.UseVisualStyleBackColor = true;
            this.btnPicposLandscape.Click += new System.EventHandler(this.btnPicposLandscape_Click);
            // 
            // btnPicposPortrait
            // 
            this.btnPicposPortrait.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPicposPortrait.Location = new System.Drawing.Point(344, 281);
            this.btnPicposPortrait.Name = "btnPicposPortrait";
            this.btnPicposPortrait.Size = new System.Drawing.Size(77, 88);
            this.btnPicposPortrait.TabIndex = 14;
            this.btnPicposPortrait.Text = "Fill";
            this.btnPicposPortrait.UseVisualStyleBackColor = true;
            this.btnPicposPortrait.Click += new System.EventHandler(this.btnPicposPortrait_Click);
            // 
            // btnOrientationWrong
            // 
            this.btnOrientationWrong.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btnOrientationWrong.Location = new System.Drawing.Point(287, 6);
            this.btnOrientationWrong.Name = "btnOrientationWrong";
            this.btnOrientationWrong.Size = new System.Drawing.Size(134, 26);
            this.btnOrientationWrong.TabIndex = 15;
            this.btnOrientationWrong.Text = "Fix Reversed";
            this.btnOrientationWrong.UseVisualStyleBackColor = true;
            this.btnOrientationWrong.Click += new System.EventHandler(this.btnOrientationWrong_Click);
            // 
            // btnHideWnd
            // 
            this.btnHideWnd.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F);
            this.btnHideWnd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnHideWnd.Location = new System.Drawing.Point(440, 74);
            this.btnHideWnd.Name = "btnHideWnd";
            this.btnHideWnd.Size = new System.Drawing.Size(227, 122);
            this.btnHideWnd.TabIndex = 16;
            this.btnHideWnd.Text = "Hide this window";
            this.btnHideWnd.UseVisualStyleBackColor = true;
            this.btnHideWnd.Click += new System.EventHandler(this.btnHideWnd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(440, 202);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(227, 73);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblBgBorder
            // 
            this.lblBgBorder.BackColor = System.Drawing.Color.Transparent;
            this.lblBgBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBgBorder.Image = global::DesktopWallpaperAutoSwitch.Properties.Resources.span_48p_png;
            this.lblBgBorder.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblBgBorder.Location = new System.Drawing.Point(12, 6);
            this.lblBgBorder.Name = "lblBgBorder";
            this.lblBgBorder.Size = new System.Drawing.Size(39, 37);
            this.lblBgBorder.TabIndex = 19;
            this.lblBgBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblBgBorder_MouseDown);
            this.lblBgBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblBgBorder_MouseMove);
            this.lblBgBorder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBgBorder_MouseUp);
            // 
            // picboxLandscape
            // 
            this.picboxLandscape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picboxLandscape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxLandscape.Location = new System.Drawing.Point(15, 75);
            this.picboxLandscape.Name = "picboxLandscape";
            this.picboxLandscape.Size = new System.Drawing.Size(200, 200);
            this.picboxLandscape.TabIndex = 20;
            this.picboxLandscape.TabStop = false;
            this.picboxLandscape.Click += new System.EventHandler(this.picboxLandscape_Click);
            // 
            // picboxPortrait
            // 
            this.picboxPortrait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picboxPortrait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxPortrait.Location = new System.Drawing.Point(221, 74);
            this.picboxPortrait.Name = "picboxPortrait";
            this.picboxPortrait.Size = new System.Drawing.Size(200, 200);
            this.picboxPortrait.TabIndex = 21;
            this.picboxPortrait.TabStop = false;
            this.picboxPortrait.Click += new System.EventHandler(this.picboxPortrait_Click);
            // 
            // lblVersionTitle
            // 
            this.lblVersionTitle.AutoSize = true;
            this.lblVersionTitle.Location = new System.Drawing.Point(439, 281);
            this.lblVersionTitle.Name = "lblVersionTitle";
            this.lblVersionTitle.Size = new System.Drawing.Size(77, 12);
            this.lblVersionTitle.TabIndex = 22;
            this.lblVersionTitle.Text = "DWAS version";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(533, 281);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 14);
            this.lblVersion.TabIndex = 23;
            this.lblVersion.Text = "0.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "by logchan";
            // 
            // lnkHomepage
            // 
            this.lnkHomepage.AutoSize = true;
            this.lnkHomepage.Location = new System.Drawing.Point(438, 309);
            this.lnkHomepage.Name = "lnkHomepage";
            this.lnkHomepage.Size = new System.Drawing.Size(173, 12);
            this.lnkHomepage.TabIndex = 25;
            this.lnkHomepage.TabStop = true;
            this.lnkHomepage.Text = "Homepage (check for updates)";
            this.lnkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHomepage_LinkClicked);
            // 
            // lnkGithub
            // 
            this.lnkGithub.AutoSize = true;
            this.lnkGithub.Location = new System.Drawing.Point(438, 333);
            this.lnkGithub.Name = "lnkGithub";
            this.lnkGithub.Size = new System.Drawing.Size(125, 12);
            this.lnkGithub.TabIndex = 26;
            this.lnkGithub.TabStop = true;
            this.lnkGithub.Text = "Github (source code)";
            this.lnkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGithub_LinkClicked);
            // 
            // lnkThanks
            // 
            this.lnkThanks.AutoSize = true;
            this.lnkThanks.Location = new System.Drawing.Point(439, 357);
            this.lnkThanks.Name = "lnkThanks";
            this.lnkThanks.Size = new System.Drawing.Size(89, 12);
            this.lnkThanks.TabIndex = 28;
            this.lnkThanks.TabStop = true;
            this.lnkThanks.Text = "Special Thanks";
            this.lnkThanks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThanks_LinkClicked);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(679, 420);
            this.Controls.Add(this.lnkThanks);
            this.Controls.Add(this.lnkGithub);
            this.Controls.Add(this.lnkHomepage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblVersionTitle);
            this.Controls.Add(this.picboxPortrait);
            this.Controls.Add(this.picboxLandscape);
            this.Controls.Add(this.lblBgBorder);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHideWnd);
            this.Controls.Add(this.btnOrientationWrong);
            this.Controls.Add(this.btnPicposPortrait);
            this.Controls.Add(this.btnPicposLandscape);
            this.Controls.Add(this.chkRunWithWindows);
            this.Controls.Add(this.comboChooseLanguage);
            this.Controls.Add(this.lblOpenfileInfo);
            this.Controls.Add(this.lblMinimizeInfo);
            this.Controls.Add(this.btnChosePortraitImg);
            this.Controls.Add(this.lblPortraitImgTitle);
            this.Controls.Add(this.btnChooseLandscapeImg);
            this.Controls.Add(this.lblLandscapeImgTitle);
            this.Controls.Add(this.lblDesktopOri);
            this.Controls.Add(this.lblDesktopOriTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Shown += new System.EventHandler(this.ConfigForm_Shown);
            this.SizeChanged += new System.EventHandler(this.ConfigForm_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxLandscape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPortrait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lblDesktopOriTitle;
        private System.Windows.Forms.Label lblDesktopOri;
        private System.Windows.Forms.Label lblLandscapeImgTitle;
        private System.Windows.Forms.Button btnChooseLandscapeImg;
        private System.Windows.Forms.Button btnChosePortraitImg;
        private System.Windows.Forms.Label lblPortraitImgTitle;
        private System.Windows.Forms.Label lblMinimizeInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuShowConfigWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Label lblOpenfileInfo;
        private System.Windows.Forms.ComboBox comboChooseLanguage;
        private System.Windows.Forms.CheckBox chkRunWithWindows;
        private System.Windows.Forms.Button btnPicposLandscape;
        private System.Windows.Forms.Button btnPicposPortrait;
        private System.Windows.Forms.Button btnOrientationWrong;
        private System.Windows.Forms.Button btnHideWnd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblBgBorder;
        private System.Windows.Forms.PictureBox picboxLandscape;
        private System.Windows.Forms.PictureBox picboxPortrait;
        private System.Windows.Forms.Label lblVersionTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkHomepage;
        private System.Windows.Forms.LinkLabel lnkGithub;
        private System.Windows.Forms.LinkLabel lnkThanks;
    }
}

