using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    public partial class AboutWindow : Form
    {

        private const string PageLink = @"https://github.com/dragxnd/DukeBlaze_Launcher";

        public AboutWindow()
        {
            InitializeComponent();
            VersionLabel.Text = $"Version: {Application.ProductVersion}";
        }

        private void GitHubPage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(PageLink);
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
