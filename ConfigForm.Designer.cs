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
            this.lblLandscapeImg = new System.Windows.Forms.Label();
            this.lblPortraitImg = new System.Windows.Forms.Label();
            this.lblMinimizeInfo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblOpenfileInfo = new System.Windows.Forms.Label();
            this.comboChooseLanguage = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
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
            this.lblLandscapeImgTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLandscapeImgTitle.Location = new System.Drawing.Point(12, 59);
            this.lblLandscapeImgTitle.Name = "lblLandscapeImgTitle";
            this.lblLandscapeImgTitle.Size = new System.Drawing.Size(146, 21);
            this.lblLandscapeImgTitle.TabIndex = 2;
            this.lblLandscapeImgTitle.Text = "Landscape image:";
            // 
            // btnChooseLandscapeImg
            // 
            this.btnChooseLandscapeImg.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChooseLandscapeImg.Location = new System.Drawing.Point(417, 54);
            this.btnChooseLandscapeImg.Name = "btnChooseLandscapeImg";
            this.btnChooseLandscapeImg.Size = new System.Drawing.Size(88, 30);
            this.btnChooseLandscapeImg.TabIndex = 3;
            this.btnChooseLandscapeImg.Text = "Choose";
            this.btnChooseLandscapeImg.UseVisualStyleBackColor = true;
            this.btnChooseLandscapeImg.Click += new System.EventHandler(this.btnChooseLandscapeImg_Click);
            // 
            // btnChosePortraitImg
            // 
            this.btnChosePortraitImg.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChosePortraitImg.Location = new System.Drawing.Point(417, 90);
            this.btnChosePortraitImg.Name = "btnChosePortraitImg";
            this.btnChosePortraitImg.Size = new System.Drawing.Size(88, 30);
            this.btnChosePortraitImg.TabIndex = 5;
            this.btnChosePortraitImg.Text = "Choose";
            this.btnChosePortraitImg.UseVisualStyleBackColor = true;
            this.btnChosePortraitImg.Click += new System.EventHandler(this.btnChosePortraitImg_Click);
            // 
            // lblPortraitImgTitle
            // 
            this.lblPortraitImgTitle.AutoSize = true;
            this.lblPortraitImgTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPortraitImgTitle.Location = new System.Drawing.Point(12, 95);
            this.lblPortraitImgTitle.Name = "lblPortraitImgTitle";
            this.lblPortraitImgTitle.Size = new System.Drawing.Size(123, 21);
            this.lblPortraitImgTitle.TabIndex = 4;
            this.lblPortraitImgTitle.Text = "Portrait image:";
            // 
            // lblLandscapeImg
            // 
            this.lblLandscapeImg.AutoSize = true;
            this.lblLandscapeImg.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLandscapeImg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblLandscapeImg.Location = new System.Drawing.Point(164, 59);
            this.lblLandscapeImg.Name = "lblLandscapeImg";
            this.lblLandscapeImg.Size = new System.Drawing.Size(67, 22);
            this.lblLandscapeImg.TabIndex = 6;
            this.lblLandscapeImg.Text = "not set";
            this.lblLandscapeImg.Click += new System.EventHandler(this.lblLandscapeImg_Click);
            // 
            // lblPortraitImg
            // 
            this.lblPortraitImg.AutoSize = true;
            this.lblPortraitImg.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPortraitImg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPortraitImg.Location = new System.Drawing.Point(164, 95);
            this.lblPortraitImg.Name = "lblPortraitImg";
            this.lblPortraitImg.Size = new System.Drawing.Size(67, 22);
            this.lblPortraitImg.TabIndex = 7;
            this.lblPortraitImg.Text = "not set";
            this.lblPortraitImg.Click += new System.EventHandler(this.lblPortraitImg_Click);
            // 
            // lblMinimizeInfo
            // 
            this.lblMinimizeInfo.AutoSize = true;
            this.lblMinimizeInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.lblMinimizeInfo.Location = new System.Drawing.Point(13, 158);
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
            this.lblOpenfileInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.lblOpenfileInfo.Location = new System.Drawing.Point(13, 132);
            this.lblOpenfileInfo.Name = "lblOpenfileInfo";
            this.lblOpenfileInfo.Size = new System.Drawing.Size(193, 17);
            this.lblOpenfileInfo.TabIndex = 10;
            this.lblOpenfileInfo.Text = "Click on the filename to open it.";
            // 
            // comboChooseLanguage
            // 
            this.comboChooseLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChooseLanguage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboChooseLanguage.FormattingEnabled = true;
            this.comboChooseLanguage.Location = new System.Drawing.Point(392, 155);
            this.comboChooseLanguage.Name = "comboChooseLanguage";
            this.comboChooseLanguage.Size = new System.Drawing.Size(113, 25);
            this.comboChooseLanguage.TabIndex = 11;
            this.comboChooseLanguage.SelectedIndexChanged += new System.EventHandler(this.comboChooseLanguage_SelectedIndexChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 184);
            this.Controls.Add(this.comboChooseLanguage);
            this.Controls.Add(this.lblOpenfileInfo);
            this.Controls.Add(this.lblMinimizeInfo);
            this.Controls.Add(this.lblPortraitImg);
            this.Controls.Add(this.lblLandscapeImg);
            this.Controls.Add(this.btnChosePortraitImg);
            this.Controls.Add(this.lblPortraitImgTitle);
            this.Controls.Add(this.btnChooseLandscapeImg);
            this.Controls.Add(this.lblLandscapeImgTitle);
            this.Controls.Add(this.lblDesktopOri);
            this.Controls.Add(this.lblDesktopOriTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ConfigForm_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblLandscapeImg;
        private System.Windows.Forms.Label lblPortraitImg;
        private System.Windows.Forms.Label lblMinimizeInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuShowConfigWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Label lblOpenfileInfo;
        private System.Windows.Forms.ComboBox comboChooseLanguage;
    }
}

