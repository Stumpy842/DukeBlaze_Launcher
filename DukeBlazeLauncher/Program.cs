using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

[assembly: SupportedOSPlatform("windows")]
namespace DukeBlazeLauncher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetDefaultFont(new Font(new FontFamily("Microsoft Sans Serif"), 8f));
            Application.Run(new MainWindow());
        }
    }
}
