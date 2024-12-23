using DragDukeLauncher.Extensions;
using System;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    public partial class SettingsWindow : Form
    {

        public SettingsWindow()
        {
            InitializeComponent();
            Settings.Init(this);
            Settings.Load();
        }

        private void ExeBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            fileBrowser.Filter = "eduke 32 exe (*.exe)|*.exe";
            fileBrowser.FilterIndex = 1;
            fileBrowser.RestoreDirectory = true;

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = Tools.GetRelativePath(fileBrowser.FileName);
                ExePathTextBox.Text = path;
            }
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Save();
            this.Close();
        }

    }
}
