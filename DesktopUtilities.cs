/* DesktopUtilities.cs
 * Utilities for desktop wallpaper etc.
 * 
 * If you obtain this file by chance, you should check https://github.com/logchan for more information and possible updates
 * 
 * first version by logchan, 7/25/2014
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace DesktopWallpaperAutoSwitch
{
    public static class DesktopUtilities
    {
        /***** WINDOWS API *****/

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction,
                                                int uParam,
                                                string lpvParam,
                                                int fuWinIni);

        public static bool SetWallpaper(string path)
        {
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
    }
}
