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
    /// Three picture positions to set
    /// </summary>
    public enum PicPos
    {
        Fill = 10,
        Fit = 6,
        Stretch = 2
    }

    /// <summary>
    /// Wrap the config of this application
    /// </summary>
    public struct MyConfig
    {
        public string imgLandscape;
        public string imgPortrait;
        public string language;
        public bool reverse;
        public PicPos posLandscape;
        public PicPos posPortrait;
        public int ver;
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

        /// <summary>
        /// How often should the timer ticks
        /// </summary>
        private int timerInterval = 500;

        /***** CONSTRUCTOR *****/

        public ConfigForm()
        {
            InitializeComponent();

            /* Form layout */
            this.btnChooseLandscapeImg.BringToFront();
            this.btnChosePortraitImg.BringToFront();
            this.Icon = Properties.Resources.span_48p;
            this.lblBgBorder.SendToBack();
            this.lblBgBorder.Top = this.lblBgBorder.Left = 0;
            this.lblBgBorder.Width = this.Width;
            this.lblBgBorder.Height = this.Height;
            GetAndSetVersion();

            /* Load Configuration */
            ReadConfig();
            ProcessConfig();
            SetAutorunState();

            /* Load and Set Languages*/
            LoadLanguages();
            ProcessComboBoxAfterLoadingLanguages();
            SetUIStrings();

            /* Init orientation state */
            lastOrientation = GetDesktopOrientation(conf.reverse);
            SetNotifyIcon();

            /* Set flag */
            this.timer1.Interval = timerInterval;
            this.timer1.Enabled = true;
            formInitialized = true;

        }

        /***** METHODS *****/

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
            /*
             * Update for old versions
             */
            if(conf.ver != GetCurrentVer()) ProcessOldVersions();

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
                        SetImgPicBgAndText(DesktopOrientation.Landscape);
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
                        SetImgPicBgAndText(DesktopOrientation.Portrait);
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

            /* 
             * Hide window if both images available, and set current background
             */
            if (firstSuccess && secondSuccess)
            {
                shouldAutoHide = true;
                SetDesktopWallpaper(GetDesktopOrientation(conf.reverse));
            }

            /* 
             * Set picture position button state
             */
            this.btnPicposLandscape.Text = conf.posLandscape.ToString();
            this.btnPicposPortrait.Text = conf.posPortrait.ToString();
        }

        /// <summary>
        /// When updated from a old version, do patches accordingly
        /// </summary>
        private void ProcessOldVersions()
        {
            if (conf.ver < 110)
            {
                // remove langpath for pre-1.1.0 version
                string langpath = Application.StartupPath + @"\lang\";
                try
                {
                    if (Directory.Exists(langpath))
                    {
                        Directory.Delete(langpath, true);
                    }
                }
                catch (Exception)
                {
                    // skip
                }
            }

            conf.ver = GetCurrentVer();
            SaveConfig();
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
                    SetImgPicBgAndText(DesktopOrientation.Landscape);
                    break;
                case DesktopOrientation.Portrait:
                    conf.imgPortrait = "";
                    SetImgPicBgAndText(DesktopOrientation.Portrait);
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
                            SetImgPicBgAndText(DesktopOrientation.Landscape);
                            break;
                        case DesktopOrientation.Portrait:
                            conf.imgPortrait = path;
                            SetImgPicBgAndText(DesktopOrientation.Portrait);
                            break;
                    }
                    SaveConfig();
                    if (orientation == lastOrientation) SetDesktopWallpaper(orientation);
                }
            }
        }

        /// <summary>
        /// Set the picbox of images of specified orientation
        /// </summary>
        /// <param name="orientation">the orientation of image</param>
        private void SetImgPicBgAndText(DesktopOrientation orientation)
        {
            switch(orientation)
            {
                case DesktopOrientation.Landscape:
                    SetImgContainerBg(this.picboxLandscape, conf.imgLandscape);
                    break;
                case DesktopOrientation.Portrait:
                    SetImgContainerBg(this.picboxPortrait, conf.imgPortrait);
                    break;
            }
        }

        /// <summary>
        /// Set the background of picbox
        /// </summary>
        /// <param name="picbox">the picbox to set</param>
        /// <param name="path">path of image</param>
        private void SetImgContainerBg(PictureBox picbox, string path)
        {
            try
            {
                if (path != "")
                {
                    picbox.BackgroundImage = Image.FromFile(path);
                }
                else
                {
                    picbox.BackgroundImage = null;
                }
            }
            catch (Exception)
            {
                // swallow
            }
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
            if (GetDesktopOrientation(conf.reverse) == DesktopOrientation.Landscape)
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
        private DesktopOrientation GetDesktopOrientation(bool reverse)
        {
            ScreenOrientation so = SystemInformation.ScreenOrientation;
            if (so == ScreenOrientation.Angle0 || so == ScreenOrientation.Angle180)
            {
                return (!reverse) ? DesktopOrientation.Landscape : DesktopOrientation.Portrait;
            }
            else
            {
                return (!reverse) ? DesktopOrientation.Portrait : DesktopOrientation.Landscape;
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
                    SetDesktopPicPos(conf.posLandscape);
                    path = conf.imgLandscape;
                    break;
                case DesktopOrientation.Portrait:
                    SetDesktopPicPos(conf.posPortrait);
                    path = conf.imgPortrait;
                    break;
            }
            return DesktopUtilities.SetWallpaper(path);
        }

        /// <summary>
        /// Set the picture position of Windows (by setting registry)
        /// </summary>
        /// <param name="p">target picture position</param>
        private void SetDesktopPicPos(PicPos p)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser;
                reg = reg.OpenSubKey("Control Panel\\desktop", true);
                reg.SetValue("WallpaperStyle", ((int)p).ToString());
                reg.Close();
            }
            catch (Exception)
            {

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

        /// <summary>
        /// Get and set version to the label
        /// </summary>
        private void GetAndSetVersion()
        {
            System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.ExecutablePath);
            this.lblVersion.Text = String.Format("{0}.{1}.{2}", ver.FileMajorPart, ver.FileMinorPart, ver.FileBuildPart);
        }

        /// <summary>
        /// Change picture position setting of a image (in a routine)
        /// </summary>
        /// <param name="orientation"></param>
        private void HandlePicposButtonClick(DesktopOrientation orientation)
        {
            int state = 0;
            PicPos[] poss = Enum.GetValues(typeof(PicPos)).Cast<PicPos>().ToArray<PicPos>();
            switch(orientation)
            {
                case DesktopOrientation.Landscape:
                    state = FindElementIndex<PicPos>(poss, conf.posLandscape, (a, b) => a == b);
                    state = (state + 1) % poss.Length;
                    conf.posLandscape = poss[state];
                    this.btnPicposLandscape.Text = conf.posLandscape.ToString().t(lang);
                    break;
                case DesktopOrientation.Portrait:
                    state = FindElementIndex<PicPos>(poss, conf.posPortrait, (a, b) => a == b);
                    state = (state + 1) % poss.Length;
                    conf.posPortrait = poss[state];
                    this.btnPicposPortrait.Text = conf.posPortrait.ToString().t(lang);
                    break;
            }

            SaveConfig();
            // set wallpaper to update immediately
            if (orientation == lastOrientation)
            {
                SetDesktopWallpaper(orientation);
            }
        }

        /// <summary>
        /// Find the index of an element in an array
        /// </summary>
        /// <typeparam name="T">The type of array and element</typeparam>
        /// <param name="array">the array to find in</param>
        /// <param name="element">the element to find</param>
        /// <param name="comparator">determines what it means to be equal</param>
        /// <returns>index if found, -1 if not found</returns>
        private int FindElementIndex<T>(T[] array, T element, Func<T, T, bool> comparator)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (comparator(array[i], element)) return i;
            }
            return -1;
        }

        /// <summary>
        /// Get the current version in integer
        /// </summary>
        /// <returns>Version a.b.c -> 100a + 10b + c</returns>
        private int GetCurrentVer()
        {
            System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.ExecutablePath);
            return (ver.FileMajorPart * 100 + ver.FileMinorPart * 10 + ver.FileBuildPart * 1);
        }

    }
}
