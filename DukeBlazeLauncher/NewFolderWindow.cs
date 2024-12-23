using DragDukeLauncher.Extensions;
using System;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    public partial class NewFolderWindow : Form
    {

        private TreeView _presetTree = null;
        private bool _edit = false;

        private const string EditFolderTitle = "Edit folder";
        private const string NewFolderTitle = "New folder";


        public NewFolderWindow(TreeView presetTree, bool edit = false)
        {
            _edit = edit;
            InitializeComponent();
            _presetTree = presetTree;
            
            if (_edit)
            {
                NewFolderNameTextBox.Text = _presetTree.SelectedNode.Text.Replace($"{Tools.FolderIcon} ", "");
                this.Text = EditFolderTitle;
            }
            else
            {
                this.Text = NewFolderTitle;
            }
        }

        private void CreateFolderButton_Click(object sender, EventArgs e)
        {
            if(_edit)
            {
                _presetTree.SelectedNode.Text = $"{Tools.FolderIcon} {NewFolderNameTextBox.Text}";
            }
            else
            {
                var node = _presetTree.SelectedNode.Nodes.Add($"{Tools.FolderIcon} {NewFolderNameTextBox.Text}");
                node.Tag = PresetsManager.GetNewId().ToString();
            }
            PresetsManager.Save();
            this.Close();
        }
    }
}
