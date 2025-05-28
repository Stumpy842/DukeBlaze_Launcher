using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DukeBlazeLauncher
{
    public partial class AboutWindow : Form
    {
        private const string PageLink = @"https://github.com/dragxnd/DukeBlaze_Launcher";
        private const string ForkLink = @"https://github.com/Stumpy842/DukeBlaze_Launcher";

        public AboutWindow()
        {
            InitializeComponent();
            VersionLabel.Text = $"Version: {Application.ProductVersion.Split('+')[0]}";
            //Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            //VersionLabel.Text = $"Version: {ver.Major}.{ver.Minor}.{ver.Build}";
            Text = $"About {MainWindow.MyTitle}";
        }

        private void GitHubPage_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            string link = lbl.Name == "GitHubPageLink" ? PageLink : ForkLink;
            try
            {
                using Process p = Process.Start(new ProcessStartInfo(link) { UseShellExecute = true })!;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"***{ex}");
                using (new CenterWinDialog(this))
                MessageBox.Show($@"Cannot open page {link}" + $"\n{ex}", MainWindow.MyTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AboutWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Escape)) this.Close();
        }
    }
}
