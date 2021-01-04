using System;
using System.Windows.Forms;

using Renishaw.Calibration.Laser.Service;
using Renishaw.Calibration.WeatherStationService.Service;

namespace CamCtl
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var xcHost = new LocalXCHost())
            {
                xcHost.Open();
                LocalXLHost xlHost = null;
                try
                {
                    xlHost = new LocalXLHost();
                    xlHost.Open();
                    Application.Run(new MainForm());
                }
                finally
                {
                    if (xlHost != null)
                    {
                        xlHost.Dispose();
                    }
                }
            }
        }
    }
}
