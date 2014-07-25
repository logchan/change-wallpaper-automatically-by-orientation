/* ConfigFormEventHandlers.cs
 * The event handlers of the main winform of this application
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MultiLang;
using Microsoft.Win32;
using System.Drawing;

namespace DesktopWallpaperAutoSwitch
{
    public partial class ConfigForm : Form
    {

        /***** EVENT HANDELERS *****/

        /// <summary>
        /// Timer1 ticks every second. It checks if the desktop orientation has changed.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DesktopOrientation currentOrientation = GetDesktopOrientation(conf.reverse);
            if (currentOrientation != lastOrientation)
            {
                SetDesktopOriString();
                lastOrientation = currentOrientation;
                SetNotifyIcon();
                if (!SetDesktopWallpaper(currentOrientation))
                {
                    this.notifyIcon1.ShowBalloonTip(2000, "Desktop Wallpaper Auto Switch".t(lang), "Failed setting your wallpaper.".t(lang), ToolTipIcon.Error);
                }
            }
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (MessageBox.Show("Are you sure that you want to close it?".t(lang), "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                this.notifyIcon1.Visible = false;
            }
            else
            {
                e.Cancel = true;
            }
            
        }

        private void menuShowConfigWindow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Minimize window into notification area
        /// </summary>
        private void ConfigForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            menuShowConfigWindow_Click(sender, e);
        }

        private void btnChooseLandscapeImg_Click(object sender, EventArgs e)
        {
            AskforImage(DesktopOrientation.Landscape);
        }

        private void btnChosePortraitImg_Click(object sender, EventArgs e)
        {
            AskforImage(DesktopOrientation.Portrait);
        }

        /// <summary>
        /// Change the language when a different one is selected, save config, and restart application.
        /// </summary>
        private void comboChooseLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formInitialized) return;
            if (lang.Language == comboChooseLanguage.SelectedItem.ToString()) return;
            languages.ForEach(l =>
            {
                if (l.Language == comboChooseLanguage.SelectedItem.ToString())
                {
                    lang = l;
                    conf.language = lang.Language;
                    SaveConfig();
                    MessageBox.Show("Application will now restart for changes to take effect.".t(lang), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
            });
        }

        private void chkRunWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (!formInitialized) return;
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (chkRunWithWindows.Checked)
                {
                    key.SetValue("co.logu.DWAS", Application.ExecutablePath);
                }
                else
                {
                    key.DeleteValue("co.logu.DWAS", false);
                }
                MessageBox.Show("Operation succeeded.".t(lang), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                // hmm, yummy
            }
        }

        private void ConfigForm_Shown(object sender, EventArgs e)
        {
            if (!this.shouldAutoHide) this.WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Handle drag-and-move */

        private Point mPoint = new Point();

        private void lblBgBorder_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
            this.Opacity = 0.7;
        }

        private void lblBgBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void lblBgBorder_MouseUp(object sender, MouseEventArgs e)
        {
            this.Opacity = 1.0;
        }

        private void btnHideWnd_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picboxLandscape_Click(object sender, EventArgs e)
        {
            if (conf.imgLandscape != "" && File.Exists(conf.imgLandscape))
                System.Diagnostics.Process.Start(conf.imgLandscape);
            else
            {
                HandleImageNotExist(DesktopOrientation.Landscape);
                AskforImage(DesktopOrientation.Landscape);
            }
        }

        private void picboxPortrait_Click(object sender, EventArgs e)
        {
            if (conf.imgPortrait != "" && File.Exists(conf.imgPortrait))
                System.Diagnostics.Process.Start(conf.imgPortrait);
            else
            {
                HandleImageNotExist(DesktopOrientation.Portrait);
                AskforImage(DesktopOrientation.Portrait);
            }
        }

        private void btnOrientationWrong_Click(object sender, EventArgs e)
        {
            conf.reverse = !conf.reverse;
            SaveConfig();
        }

        private void lnkHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.logu.co/dwas/");
        }

        private void lnkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/logchan/change-wallpaper-automatically-by-orientation/");
        }

        private void lnkThanks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/logchan/change-wallpaper-automatically-by-orientation/wiki/Special-Thanks");
        }

        private void btnPicposLandscape_Click(object sender, EventArgs e)
        {
            HandlePicposButtonClick(DesktopOrientation.Landscape);
        }

        private void btnPicposPortrait_Click(object sender, EventArgs e)
        {
            HandlePicposButtonClick(DesktopOrientation.Portrait);
        }

    }
}
