/* MultiLang.cs
 * Utilities for multiple languages support
 * The MLE allows you to load a language file (formatted XML) and do run-time translation.
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
using System.Xml;
using System.IO;

namespace MultiLang
{
    /// <summary>
    /// Allow you to load a language file (formatted XML) and do run-time translation.
    /// </summary>
    public class MultiLangEngine
    {
        private Dictionary<string, string> entries = new Dictionary<string, string>();
        private string lang;

        public string Language { get { return lang; } }

        /// <summary>
        /// Create a empty MLE
        /// </summary>
        public MultiLangEngine()
        {
            lang = "default";
        }

        /// <summary>
        /// Load language key/value pairs from a xml document, and use them to create a MLE
        /// </summary>
        /// <param name="xmlDoc">A xml document containing language infomation</param>
        /// <exception cref="Exception.ArgumentException"></exception>
        public MultiLangEngine(XmlDocument xmlDoc)
        {
            /*
             * Basically it reads and parses the xml document
             * However, over 2/3 of the following codes are used to handle abnormal situations
             * 
             * The world would be much better if ALL INPUTS ARE VALID
             */
            try
            {
                XmlNode root = xmlDoc.FirstChild;
                if (root.Value.Contains("version=")) root = root.NextSibling;
                if (string.Compare(root.Name, "multilang", ignoreCase: true) != 0) throw new Exception(String.Format("root is not multilang but {0}", root.Value));

                lang = root.Attributes["language"].Value;

                string oneKey, oneValue;
                foreach (XmlNode node in root.ChildNodes)
                {
                    bool success = false;
                    oneKey = oneValue = null;

                    if (node.HasChildNodes && string.Compare(node.Name, "entry", ignoreCase: true) == 0)
                    {
                        try
                        {
                            foreach (XmlNode subNode in node.ChildNodes)
                            {
                                if (string.Compare(subNode.Name, "key", ignoreCase: true) == 0) oneKey = subNode.InnerText;
                                else if (string.Compare(subNode.Name, "value", ignoreCase: true) == 0) oneValue = subNode.InnerText;
                            }
                            if (oneKey != null && oneValue != null) success = true;
                        }
                        catch (Exception)
                        {
                            success = false;
                        }
                    }

                    if (success && !entries.ContainsKey(oneKey)) entries.Add(oneKey, oneValue);
                }
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Invalid xml document provided.", ex);
            }
        }
        
        /// <summary>
        /// Scan a directory for language xml files.
        /// </summary>
        /// <param name="path">the directory to scan</param>
        /// <returns>a list of available MLEs</returns>
        public static List<MultiLangEngine> ScanDirectory(string path)
        {
            List<MultiLangEngine> list = new List<MultiLangEngine>();
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (string.Compare(fi.Extension, ".xml", ignoreCase: true) == 0)
                    {
                        MultiLangEngine newLang = null;
                        try
                        {
                            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                            using (FileStream fs = new FileStream(fi.FullName, System.IO.FileMode.Open))
                                using (StreamReader sr = new StreamReader(fs))
                                    xmldoc.LoadXml(sr.ReadToEnd());
                            newLang = new MultiLangEngine(xmldoc);
                        }
                        catch(Exception)
                        {
                            newLang = null;
                        }

                        if (newLang != null)
                            list.Add(newLang);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Get the translation of input if it is a key in the entries.
        /// </summary>
        /// <param name="input">the string to translate</param>
        /// <param name="args">the formatting arguments</param>
        /// <returns>the translation of input</returns>
        public string Translate(string input, params object[] args)
        {
            if (entries.ContainsKey(input))
            {
                return String.Format(entries[input], args);
            }
            else
            {
                return String.Format(input, args);
            }
        }
    }

    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method of String, provides a translation
        /// </summary>
        /// <param name="input">the string to translate</param>
        /// <param name="lang">the MultiLangEngine for translation</param>
        /// <returns>the translation of input</returns>
        public static string t(this string input, MultiLangEngine lang)
        {
            return lang.Translate(input);
        }
    }
}
