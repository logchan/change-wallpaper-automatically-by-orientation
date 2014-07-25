/* ConfigFormConfigManagement.cs
 * The methods that handle the reading and writing of config file
 * 
 * If you obtain this file by chance, you should check https://github.com/logchan for more information and possible updates
 * 
 * first version by logchan, 7/25/2014
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
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopWallpaperAutoSwitch
{
    public partial class ConfigForm : Form
    {

        /// <summary>
        /// Read configuration file
        /// </summary>
        private void ReadConfig()
        {
            // get configuration with default values
            // images and language
            conf.imgLandscape = ReadOneSettingSafe("landscape", "");
            conf.imgPortrait = ReadOneSettingSafe("portrait", "");
            conf.language = ReadOneSettingSafe("language", "");
            // reverse
            string revstr = "";
            revstr = ReadOneSettingSafe("reverse", null);
            if (revstr != null && revstr == true.ToString())
            {
                conf.reverse = true;
            }
            else
            {
                conf.reverse = false;
            }
            // picture position
            string posl = "";
            string posp = "";
            posl = ReadOneSettingSafe("posLandscape", "Fill");
            posp = ReadOneSettingSafe("posPortrait", "Fill");
            conf.posLandscape = PicPos.Fill;
            conf.posPortrait = PicPos.Fill;
            foreach (string pos in Enum.GetNames(typeof(PicPos)))
            {
                if (string.Compare(posl, pos, ignoreCase: true) == 0) Enum.TryParse<PicPos>(pos, true, out conf.posLandscape);
                if (string.Compare(posp, pos, ignoreCase: true) == 0) Enum.TryParse<PicPos>(pos, true, out conf.posPortrait);
            }
            // last version
            string rver = ReadOneSettingSafe("ver", "100");
            int.TryParse(rver, out conf.ver);

            SaveConfig();
        }

        /// <summary>
        /// Read the config and get one key value in a safe way (prevent null ref)
        /// </summary>
        /// <param name="key">the key of the config</param>
        /// <param name="defaultValue">value when failed to get (e.g. key doesn't exist)</param>
        /// <returns>the value of config if key found, or the default value otherwise</returns>
        private string ReadOneSettingSafe(string key, string defaultValue)
        {
            try
            {
                string[] ret = ConfigurationManager.AppSettings.GetValues(key);
                if (ret != null && ret.Length > 0)
                {
                    return ret[0];
                }
                else
                {
                    return defaultValue;
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Save config to file
        /// </summary>
        private void SaveConfig()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Clear();
                // maybe one day I will use reflection to make this better
                config.AppSettings.Settings.Add("landscape", conf.imgLandscape);
                config.AppSettings.Settings.Add("portrait", conf.imgPortrait);
                config.AppSettings.Settings.Add("language", conf.language);
                config.AppSettings.Settings.Add("reverse", conf.reverse.ToString());
                config.AppSettings.Settings.Add("posLandscape", conf.posLandscape.ToString());
                config.AppSettings.Settings.Add("posPortrait", conf.posPortrait.ToString());
                config.AppSettings.Settings.Add("ver", conf.ver.ToString());
                config.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Fatal error: failed writing config file. Permission needed?\n严重错误：写入设置文件失败。请检查权限。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
