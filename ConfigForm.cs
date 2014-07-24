/* ConfigForm.cs
 * The main winform of this application
 * Event handlers put in ConfigFormEventHandlers.cs
 * 
 * If you obtain this file by chance, you should check https://github.com/logchan for more information and possible updates
 * 
 * first version by logchan, 7/24/2014
 */
/*
The MIT License

Copyright (C) 2014 logchan

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using MultiLang;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace DesktopWallpaperAutoSwitch
{
    /// <summary>
    /// Two desktop orientations to detect
    /// </summary>
    public enum DesktopOrientation
    {
        Landscape,
        Portrait
    }

    /// <summary>
    /// Wrap the config of this application
    /// </summary>
    public struct MyConfig
    {
        public string imgLandscape;
        public string imgPortrait;
        public string language;
    }

    public partial class ConfigForm : Form
    {
        /***** FIELDS *****/

        /// <summary>
        /// The language in use
        /// </summary>
        MultiLangEngine lang = new MultiLangEngine();

        /// <summary>
        /// All available languages
        /// </summary>
        List<MultiLangEngine> languages = new List<MultiLangEngine>();

        /// <summary>
        /// Preserve the last checked orientation for change detection
        /// </summary>
        DesktopOrientation lastOrientation = DesktopOrientation.Landscape;

        /// <summary>
        /// The config in use
        /// </summary>
        MyConfig conf = new MyConfig();

        /// <summary>
        /// Preserved form state to prevent some strange things
        /// </summary>
        bool formInitialized = false;

        /// <summary>
        /// Whether the window should hide automatically
        /// </summary>
        bool shouldAutoHide = false;

        /***** CONSTRUCTOR *****/

        public ConfigForm()
        {
            InitializeComponent();
            this.btnChooseLandscapeImg.BringToFront();
            this.btnChosePortraitImg.BringToFront();
            this.Icon = Properties.Resources.appicon;

            /* Load Configuration */
            ReadConfig();
            ProcessConfig();
            SetAutorunState();

            /* Load and Set Languages*/
            LoadLanguages();
            ProcessComboBoxAfterLoadingLanguages();
            SetUIStrings();

            /* Init orientation state */
            lastOrientation = GetDesktopOrientation();
            SetNotifyIcon();

            /* Set flag */
            formInitialized = true;

        }

        /***** WINDOWS API *****/

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction,
                                                int uParam,
                                                string lpvParam,
                                                int fuWinIni);

        /***** METHODS *****/

        /// <summary>
        /// Load language files
        /// </summary>
        private void LoadLanguages()
        {
            /* Check if language dir exists
             * 1. If it does, scan it
             * 2. If it doesn't, create it and write built-in xmls
             */ 
            string langPath = Application.StartupPath + @"\lang\";
            if (Directory.Exists(langPath))
            {
                // 1
                languages = MultiLangEngine.ScanDirectory(langPath);
            }
            else
            {
                // 2
                try
                {
                    Directory.CreateDirectory(langPath);
                    WriteDefaultLanguageFiles(langPath);
                    languages = MultiLangEngine.ScanDirectory(langPath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Fatal Error: Could neigher find nor create language folder. Using built-in strings.\n严重错误：打开及创建语言文件均失败。将使用内置字符串。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            /* See if any language available
             * 1. If not, try to write built-in xmls
             */
            if (languages.Count < 1)
            {
                // 1
                try
                {
                    WriteDefaultLanguageFiles(langPath);
                    languages = MultiLangEngine.ScanDirectory(langPath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Fatal Error: Could neigher find nor create language folder. Using built-in strings.\n严重错误：创建语言文件失败。将使用内置字符串。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            /* Determine the UI language
             * 1. Add all languages to combo box
             * 2. Try to use language in config file
             * 3. Try to use system language, and write config
             * 4. Use languages[0], and write config
             */
            if (languages.Count < 1) return;
            else
            {

                // 1
                MultiLangEngine theLang = null;
                languages.ForEach(l =>
                {
                    this.comboChooseLanguage.Items.Add(l.Language);
                    if (string.Compare(l.Language, conf.language) == 0) theLang = l;
                });
                if (theLang != null)
                {
                    // 2
                    lang = theLang;
                    return;
                }
                else
                {
                    // 3
                    string sysLang = System.Globalization.CultureInfo.CurrentUICulture.Name;
                    languages.ForEach(l =>
                    {
                        if (l.Language.ToLower().Contains(sysLang.ToLower()))
                            theLang = l;
                    });
                    if (theLang != null) lang = theLang;
                    else
                    {
                        // 4
                        lang = languages[0];
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// Process the language selection ComboBox after loading languages
        /// </summary>
        private void ProcessComboBoxAfterLoadingLanguages()
        {
            if (comboChooseLanguage.Items.Count < 2) comboChooseLanguage.Enabled = false;
            if (comboChooseLanguage.Items.Count == 1) comboChooseLanguage.SelectedIndex = 0;
            else
            {
                comboChooseLanguage.SelectedIndex = 0;
                for (int i = 0; i < comboChooseLanguage.Items.Count; ++i)
                {
                    if (comboChooseLanguage.Items[i].ToString() == lang.Language)
                        comboChooseLanguage.SelectedIndex = i;
                }
            }
        }

        /// <summary>
        /// Write default language files
        /// </summary>
        /// <param name="path">path to write</param>
        private void WriteDefaultLanguageFiles(string path)
        {
            using (FileStream fs = new FileStream(path + "dwas_zh-CN.xml", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
                sw.Write(Properties.Resources.dwas_zh_CN);
            using (FileStream fs = new FileStream(path + "dwas_en-US.xml", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
                sw.Write(Properties.Resources.dwas_en_US);
        }

        /// <summary>
        /// Process the config after reading
        /// </summary>
        private void ProcessConfig()
        {
            /* For two images loaded:
             * 1. Check if they exist
             * 2. Check their extensions
             * If illegal, set them to empty string
             */
            string[] validExts = new string[] { ".jpg", ".png", ".jpeg", ".bmp" };
            bool firstSuccess = false;
            bool secondSuccess = false;
            if (conf.imgLandscape != "" && File.Exists(conf.imgLandscape))
            {
                FileInfo fi = new FileInfo(conf.imgLandscape);
                foreach (string ext in validExts)
                    if (string.Compare(fi.Extension, ext, ignoreCase: true) == 0)
                    {
                        this.lblLandscapeImg.Text = fi.Name;
                        firstSuccess = true;
                        break;
                    }
                if (!firstSuccess) HandleImageNotExist(DesktopOrientation.Landscape);
            }
            else
            {
                HandleImageNotExist(DesktopOrientation.Landscape);
            }
            if (conf.imgPortrait != "" && System.IO.File.Exists(conf.imgPortrait))
            {
                FileInfo fi = new FileInfo(conf.imgPortrait);
                foreach (string ext in validExts)
                    if (string.Compare(fi.Extension, ext, ignoreCase: true) == 0)
                    {
                        this.lblPortraitImg.Text = fi.Name;
                        secondSuccess = true;
                        break;
                    }
                if (!secondSuccess) HandleImageNotExist(DesktopOrientation.Portrait);
            }
            else
            {
                HandleImageNotExist(DesktopOrientation.Portrait);
            }
            SaveConfig();

            /* Hide window if both images available
             */
            if (firstSuccess && secondSuccess) shouldAutoHide = true;
        }

        /// <summary>
        /// Process the config when the image does not exist
        /// </summary>
        /// <param name="orientation">the orientation of the image that does not exist</param>
        private void HandleImageNotExist(DesktopOrientation orientation)
        {
            switch(orientation)
            {
                case DesktopOrientation.Landscape:
                    conf.imgLandscape = "";
                    this.lblLandscapeImg.Text = "not set".t(lang);
                    break;
                case DesktopOrientation.Portrait:
                    conf.imgPortrait = "";
                    this.lblPortraitImg.Text = "not set".t(lang);
                    break;
            }
        }

        /// <summary>
        /// Ask the user to choose an image
        /// </summary>
        /// <param name="orientation">the orientation of the image to be asked</param>
        private void AskforImage(DesktopOrientation orientation)
        {
            this.openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            this.openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = this.openFileDialog1.FileName;
                if (File.Exists(path))
                {
                    switch (orientation)
                    {
                        case DesktopOrientation.Landscape:
                            conf.imgLandscape = path;
                            this.lblLandscapeImg.Text = new FileInfo(path).Name;
                            break;
                        case DesktopOrientation.Portrait:
                            conf.imgPortrait = path;
                            this.lblPortraitImg.Text = new FileInfo(path).Name;
                            break;
                    }
                    SaveConfig();
                }
            }
        }

        /// <summary>
        /// Read configuration file
        /// </summary>
        private void ReadConfig()
        {
            //load configuration
            if (ConfigurationManager.AppSettings.Count < 1)
            {
                //new configuration
                SaveConfig();
            }
            else
            {
                //get configuration
                conf.imgLandscape = (String)ConfigurationManager.AppSettings.GetValues("landscape").GetValue(0);
                conf.imgPortrait = (String)ConfigurationManager.AppSettings.GetValues("portrait").GetValue(0);
                conf.language = (String)ConfigurationManager.AppSettings.GetValues("language").GetValue(0);
            }
        }

        /// <summary>
        /// Save config to file
        /// </summary>
        private void SaveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Clear();
            config.AppSettings.Settings.Add("landscape", conf.imgLandscape);
            config.AppSettings.Settings.Add("portrait", conf.imgPortrait);
            config.AppSettings.Settings.Add("language", conf.language);
            config.Save();
        }

        /// <summary>
        /// Set UI strings according to language.
        /// Warning: Do NOT use this to update language.
        /// </summary>
        private void SetUIStrings()
        {
            this.Text = "Desktop Wallpaper Auto Switch".t(lang);
            foreach (Control c in this.Controls)
            {
                c.Text = c.Text.t(lang);
            }
            foreach (ToolStripItem m in this.contextMenuStrip1.Items)
            {
                m.Text = m.Text.t(lang);
            }
            SetDesktopOriString();
        }

        /// <summary>
        /// Set the orientation information accordingly
        /// </summary>
        private void SetDesktopOriString()
        {
            if (GetDesktopOrientation() == DesktopOrientation.Landscape)
            {
                this.lblDesktopOri.Text = "Landscape".t(lang);
                this.lblDesktopOri.ForeColor = Color.FromArgb(0, 192, 0);
            }
            else
            { 
                this.lblDesktopOri.Text = "Portrait".t(lang);
                this.lblDesktopOri.ForeColor = Color.FromArgb(192, 0, 0);
            }  
        }

        /// <summary>
        /// Get the desktop orientation
        /// </summary>
        /// <returns>current orientation</returns>
        private DesktopOrientation GetDesktopOrientation()
        {
            ScreenOrientation so = SystemInformation.ScreenOrientation;
            if (so == ScreenOrientation.Angle0 || so == ScreenOrientation.Angle180)
            {
                return DesktopOrientation.Landscape;
            }
            else
            {
                return DesktopOrientation.Portrait;
            }
        }

        /// <summary>
        /// Set the wallpaper
        /// </summary>
        /// <param name="orientation">the orientation of the wallpaper</param>
        /// <returns>true if success, false otherwise</returns>
        private bool SetDesktopWallpaper(DesktopOrientation orientation)
        {
            string path = "";
            switch(orientation)
            {
                case DesktopOrientation.Landscape:
                    path = conf.imgLandscape;
                    break;
                case DesktopOrientation.Portrait:
                    path = conf.imgPortrait;
                    break;
            }

            if (File.Exists(path))
            {
                int result = SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                if (result != 0) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Set the tip of notify icon accordingly
        /// </summary>
        private void SetNotifyIcon()
        {
            this.notifyIcon1.Text = "Desktop Orientation:".t(lang) + " ";
            if (lastOrientation == DesktopOrientation.Landscape)
            {
                this.notifyIcon1.Icon = Properties.Resources.landscape;
                this.notifyIcon1.Text += "Landscape".t(lang);
            }
            else
            {
                this.notifyIcon1.Icon = Properties.Resources.portrait;
                this.notifyIcon1.Text += "Portrait".t(lang);
            }
        }

        /// <summary>
        /// Set the autorun checkbox
        /// </summary>
        private void SetAutorunState()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                object v = key.GetValue("co.logu.DWAS", null);
                if (v != null)
                {
                    string s = (string)v;
                    if (string.Compare(s, Application.ExecutablePath) == 0) this.chkRunWithWindows.Checked = true;
                }
            }
            catch (Exception)
            {
                // hmm, yummy
            }
        }

    }
}
