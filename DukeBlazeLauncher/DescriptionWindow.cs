using DragDukeLauncher.Extensions;
using System;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    public partial class DescriptionWindow : Form
    {

        private MainWindow _mainWindow = null;
        private int selectedNodeId = -1;

        public DescriptionWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            selectedNodeId = int.Parse(_mainWindow.PresetTree.SelectedNode.Tag.ToString());

            if (selectedNodeId != -1)
            {
                PresetDescriptionTextBox.Text = DescriptionManager.GetDescriptionByNodeId(selectedNodeId);
            }

        }

        private void SavePresetButton_Click(object sender, EventArgs e)
        {
                  
            if (selectedNodeId != -1)
            {
                DescriptionManager.SaveDescriptionByNodeId(int.Parse(_mainWindow.PresetTree.SelectedNode.Tag.ToString()), PresetDescriptionTextBox.Text, _mainWindow.PresetTree.SelectedNode.Text.Contains(Tools.FolderIcon));
            }
            _mainWindow.RefreshButtonDescription();
            PresetsManager.Save();
            _mainWindow.RecoverLastSelectedNode();
            this.Close();
        }
    }
}
