/* Program.cs
 * The main init point of DWAS
 * 
 * If you obtain this file by chance, you should check https://github.com/logchan for more information and possible updates
 * 
 * first version by logchan, 7/24/2014
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DesktopWallpaperAutoSwitch
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flag;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out flag);
            if (!flag)
            {
                MessageBox.Show("DWAS is already running.\n桌面壁纸自动切换已在运行。");
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ConfigForm());
            }
        }
    }
}
