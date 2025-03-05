using DragDukeLauncher.Extensions;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    public partial class NewFolderWindow : Form
    {

        private TreeView _presetTree;
        private bool _edit;
        private string _oldName;
        private Settings.PC _preventFolderCollisions;

        private const string EditFolderTitle = "Edit folder";
        private const string NewFolderTitle = "New folder";
        // Added names for button text
        private const string EditFolderText = "&Save";
        private const string NewFolderText = "&Create";

        public NewFolderWindow(TreeView presetTree, Settings.PC preventFolderCollisions, bool edit = false, bool show = true)
        {
            InitializeComponent();
            _edit = edit;
            _presetTree = presetTree;
            _preventFolderCollisions = preventFolderCollisions;
            if (show)
            {
                CreateFolderButton.Enabled = false;
                if (_edit)
                {
                    _oldName = _presetTree.SelectedNode.Text[3..];
                    NewFolderNameTextBox.Text = _oldName;
                    this.Text = EditFolderTitle;
                    CreateFolderButton.Text = EditFolderText;
                }
                else
                {
                    this.Text = NewFolderTitle;
                    CreateFolderButton.Text = NewFolderText;
                }
            } 
        }

        public string EditAddNode(string nName = "")
        {
            string pName = nName.Length > 0 ? nName : NewFolderNameTextBox.Text;
            if (_edit && (pName == _oldName))
            {
                Close();
                return pName;
            }
            if (_preventFolderCollisions == Settings.PC.Folder)
            {
                pName = Tools.NewName(pName, _presetTree.SelectedNode.Nodes, 1, true);
            }
            else if (_preventFolderCollisions == Settings.PC.Global)
            {
                pName = Tools.NewName(pName, _presetTree.Nodes, 1, true);
            }
            if (_edit)
            {
                _presetTree.SelectedNode.Text = $"{Tools.FolderIcon} {pName}";
            }
            else
            {
                var node = _presetTree.SelectedNode.Nodes.Add($"{Tools.FolderIcon} {pName}");
                node.Tag = PresetsManager.GetNewId();
                if (node.Parent is not null)
                {
                    node.Parent.Expand();
                    _presetTree.SelectedNode = node;
                }
            }
            PresetsManager.Save();
            return pName;
        }

        private void CreateFolderButton_Click(object sender, EventArgs e)
        {
            EditAddNode();
            Close();
        }

        private void NewFolderWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void CancelFolderButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewFolderNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CreateFolderButton.Enabled = NewFolderNameTextBox.Text.Length > 0;
        }
    }
}
