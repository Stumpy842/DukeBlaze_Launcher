using DragDukeLauncher.Extensions;
using System;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    internal partial class DescriptionWindow : Form
    {

        private MainWindow _mainWindow = null;
        private int selectedNodeId = -1;

        internal DescriptionWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            selectedNodeId = (int)_mainWindow.PresetTree.SelectedNode.Tag;

            if (selectedNodeId != -1)
            {
                PresetDescriptionTextBox.Text = DescriptionManager.GetDescriptionByNodeId(selectedNodeId);
            }

        }

        private void SavePresetButton_Click(object sender, EventArgs e)
        {

            if (selectedNodeId != -1)
            {
                DescriptionManager.SaveDescriptionByNodeId((int)_mainWindow.PresetTree.SelectedNode.Tag,
                    PresetDescriptionTextBox.Text, _mainWindow.PresetTree.SelectedNode.Text.StartsWith(Tools.FolderIcon));
            }
            _mainWindow.RefreshButtonDescription();
            PresetsManager.Save();
            _mainWindow.RecoverLastSelectedNode();
            this.Close();
        }

        private void DescriptionWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void CancelPresetButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
