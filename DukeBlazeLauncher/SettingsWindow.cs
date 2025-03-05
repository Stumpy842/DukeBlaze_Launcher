using DragDukeLauncher.Extensions;
using System;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    public partial class SettingsWindow : Form
    {
        public Color CurrentColor { get; private set; } = Settings.CurrentSettings.CurrentColor;
        public int[] myCustomColors { get; private set; } = Settings.CurrentSettings.myCustomColors;
        private ColorDialog cd;

        // Set Show to false if we just need an instance to access properties like button text etc.
        // Steve - 01/28/2025 21:24:56
        public SettingsWindow(bool Show = true, int Tab = 0)
        {
            InitializeComponent();
            if (Show)
            {
                Settings.Init(this);
                Settings.Load();
                lbColor.Visible = cbUseColor.Checked;
                lbColor.BackColor = CurrentColor;
                btPickColor.Enabled = cbUseColor.Checked;
                NotepadPathEnable();
                if ((Tab > 0) && (Tab < tabControl1.TabCount)) tabControl1.SelectTab(Tab);
            }
        }

        private void ExeBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new()
            {
                Filter = "eduke32.exe (*.exe)|*.exe",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = Tools.GetPathWithAppDomain("")
            };

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = Tools.GetRelativePath(fileBrowser.FileName);
                ExePathTextBox.Text = path;
            }
        }

        private void SaveIt()
        {
            Settings.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            SaveIt();
        }

        private void SettingsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SaveIt();
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void CancelSettingsButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void NotepadPathEnable()
        {
            lbUseNotepad.Enabled = cbUseNotepad.Checked;
            tbNotepadPath.Enabled = cbUseNotepad.Checked;
            btNotepadPath.Enabled = cbUseNotepad.Checked;
        }

        private void cbUseColor_CheckedChanged(object sender, EventArgs e)
        {
            btPickColor.Enabled = cbUseColor.Checked;
            lbColor.Visible = cbUseColor.Checked;
            cbUseColor.Text = cbUseColor.Checked ? "Yes" : "No";
        }

        private void btPickColor_Click(object sender, EventArgs e)
        {
            cd = new()
            {
                Color = CurrentColor,
                AnyColor = true,
                CustomColors = myCustomColors
            };

            if (cd.ShowDialog(this) == DialogResult.OK)
            {
                CurrentColor = cd.Color;
                lbColor.BackColor = CurrentColor;
                myCustomColors = cd.CustomColors;
            }
        }

        private void btDefaultCustomColors_Click(object sender, EventArgs e)
        {
            Settings.CurrentSettings.myCustomColors = Settings.DefaultCustomColors;
            myCustomColors = Settings.CurrentSettings.myCustomColors;
        }

        private void cbUseNotepad_CheckedChanged(object sender, EventArgs e)
        {
            NotepadPathEnable();
        }

        private void btNotepadPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new()
            {
                Filter = "(*.exe)|*.exe",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = Environment.ExpandEnvironmentVariables("%ProgramW6432%")
            };

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = Tools.GetRelativePath(fileBrowser.FileName);
                tbNotepadPath.Text = path;
            }
        }

        private void btTextEditorHelp_Click(object sender, EventArgs e)
        {
            using (new CenterWinDialog(this))
                MessageBox.Show("Choose your favorite text editor, such as Notepad++ to" +
                    $"\nview the configuration files. The default is {Settings.DefaultEditorPath}.",
                    $"{MainWindow.MyTitle} - Text Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
