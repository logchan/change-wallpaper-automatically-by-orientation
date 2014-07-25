/* ConfigFormLanguageLoading.cs
 * The language loading logic of this application
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MultiLang;
using System.Xml;
using System.IO;

namespace DesktopWallpaperAutoSwitch
{
    public partial class ConfigForm : Form
    {
        /// <summary>
        /// Load language files
        /// </summary>
        private void LoadLanguages()
        {
            /* Check if language dir exists
             * 1. If it does, scan it
             * 2. If it doesn't, skip it
             */
            string langPath = Application.StartupPath + @"\lang\";
            if (Directory.Exists(langPath))
            {
                // 1
                languages = MultiLangEngine.ScanDirectory(langPath);
            }

            /* 
             * Load built-in language files
             */
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(Properties.Resources.dwas_en_US);
                languages.Add(new MultiLangEngine(xmldoc));
                xmldoc.LoadXml(Properties.Resources.dwas_zh_CN);
                languages.Add(new MultiLangEngine(xmldoc));
            }
            catch (Exception)
            {
                // skip
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
                    SaveConfig();
                    return;
                }
            }
        }

    }
}
