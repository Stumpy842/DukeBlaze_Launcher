using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using DragDukeLauncher.Extensions;
using System.Diagnostics;

namespace DragDukeLauncher
{
    // Bulk import map files as presets into a new folder under Maps
    // Steve - 02/20/2025 21:18:46
    public partial class ImportMapsWindow : Form
    {
        // Default folder name to add
        private const string DefaultFolder = "Imported Maps";
        // Text file as Embedded resource
        private const string ImportInstructionsFilename = "ImportInstructions.txt";
        // File extension for map files
        private const string mapExt = ".map";
        private static string title = MainWindow.MyTitle;

        private TreeView _presetTree;
        private Settings.PC _preventFolderCollisions;
        private Settings.PC _preventPresetCollisions;
        private List<string> Files = [];
        public ImportMapsWindow(TreeView presetTree, Settings.PC preventFolderCollisions, Settings.PC preventPresetCollisions)
        {
            InitializeComponent();
            _presetTree = presetTree;
            _preventFolderCollisions = preventFolderCollisions;
            _preventPresetCollisions = preventPresetCollisions;
        }

        private void ImportMapsWindow_Load(object sender, EventArgs e)
        {
            lbInstruct.Text = "";
            tbFolderName.Text = DefaultFolder;
            lbxFiles.AllowDrop = true;
            EnableDisableButtons();
            cbClearList.Checked = Settings.CurrentSettings.optClearAfterImport;
            cbImportSummary.Checked = Settings.CurrentSettings.optImportSummary;
            string text;
            if (Tools.GetTextFromResourceFile(ImportInstructionsFilename, out text))
                lbInstruct.Text = text.Replace("|title|", title);
            else
                Tools.TimedMessage(text, title, this);
        }

        private void EnableDisableButtons()
        {
            btImport.Enabled = lbxFiles.Items.Count > 0;
            btRemoveFiles.Enabled = lbxFiles.SelectedItems.Count > 0;
        }

        private void RemoveFiles()
        {
            for (int i = lbxFiles.SelectedIndices.Count - 1; i >= 0; i--)
                Files.RemoveAt(lbxFiles.SelectedIndices[i]);
            RefreshListBox();
        }

        private void btRemoveFiles_Click(object sender, EventArgs e)
        {
            RemoveFiles();
        }

        private void btAddFiles_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileBrowser = new()
            {
                Filter = "Map files (*.map)|*.map",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = Tools.GetPathWithAppDomain(""),
                Multiselect = true,
                AddExtension = true
            };

            if (fileBrowser.ShowDialog(this) == DialogResult.OK)
            {
                if (fileBrowser.FileNames.Length > 0)
                {
                    foreach (string file in fileBrowser.FileNames)
                        if (Path.GetExtension(file) == mapExt)
                            Files.Add(Tools.GetRelativePath(file));
                    RefreshListBox();
                }
            }
            lbxFiles.Focus();
        }

        private void RefreshListBox(bool saveSelection = false)
        {
            int oldSelectedIndex = lbxFiles.SelectedIndex;
            lbxFiles.BeginUpdate();
            lbxFiles.Items.Clear();
            for (int i = 0; i < Files.Count; i++)
                lbxFiles.Items.Add(Path.GetFileName(Files[i]));
            lbxFiles.EndUpdate();
            if (saveSelection && oldSelectedIndex < Files.Count) lbxFiles.SelectedIndex = oldSelectedIndex;
            EnableDisableButtons();
        }

        private void lbxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void lbxFiles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                {
                    e.SuppressKeyPress = true;
                    RemoveFiles();
                    break;
                }
                case Keys.A:
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        e.SuppressKeyPress = true;
                        lbxFiles.BeginUpdate();
                        for (int i = 0; i < lbxFiles.Items.Count; i++)
                            lbxFiles.SelectedIndices.Add(i);
                        lbxFiles.EndUpdate();
                    }
                    break;
                }
            }
        }

        private void lbxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == mapExt)
                    Files.Add(Tools.GetRelativePath(file));
            }
            RefreshListBox(true);
            EnableDisableButtons();
        }

        private void lbxFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        TreeNode lastSelectedNode { get; set; }

        private void btImport_Click(object sender, EventArgs e)
        {
            void SaveLSN()
            {
                lastSelectedNode = _presetTree.SelectedNode;
            }

            void RestoreLSN()
            {
                _presetTree.SelectedNode = lastSelectedNode;
            }

             static bool FindNode(string NodeName, TreeNodeCollection Nodes, out TreeNode Node)
            {
                bool found = false;
                Node = null;
                foreach (var node in TreeViewTools.Collect(Nodes))
                {
                    if (node.Text.StartsWith(Tools.FolderIcon) && node.Text[3..] == NodeName)
                    {
                        Node = node;
                        found = true;
                    }
                    if (found) break; 
                }
                return found;
            }

            // Method starts here
            if (Files.Count == 0)
            {
                // Shouldn't happen since Import button is disabled when Listbox is empty, but let's check anyway
                Tools.TimedMessage("No map files to import", Text, this);
                return;
            }

            try
            {
                // This should always succeed
                _presetTree.SelectedNode = _presetTree.Nodes[2]; // Maps folder
            }
            catch (Exception)
            {
                using (new CenterWinDialog(this))
                MessageBox.Show("Cannot find Maps folder, quitting.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SaveSettings();
                Close();
                return;
            }

            string folder = tbFolderName.Text;
            if (folder == "") folder = DefaultFolder;
            // Find the node with the given name under Maps if it exists
            if (FindNode(folder, _presetTree.SelectedNode.Nodes, out TreeNode foundnode))
            {
                _presetTree.SelectedNode = foundnode;
                //Debug.WriteLine($"***Found node {foundnode.Text}");
            }
            else
            {
                // Add new folder node under Maps
                using NewFolderWindow nfw = new(_presetTree, _preventFolderCollisions, false, false);
                // EditAddNode returns with the new node as the selected node in _presetTree
                folder = nfw.EditAddNode(folder);
                //Debug.WriteLine($"***Created new node {_presetTree.SelectedNode.Text}");
            }

            SaveLSN();
            // Add individual presets
            string pName;
            lbxFiles.BeginUpdate();
            foreach (string file in Files)
            {
                RestoreLSN();
                pName = Path.GetFileNameWithoutExtension(file);
                if (_preventPresetCollisions == Settings.PC.Folder)
                { pName = Tools.NewName(pName, _presetTree.SelectedNode.Nodes); }
                else if (_preventPresetCollisions == Settings.PC.Global)
                { pName = Tools.NewName(pName, _presetTree.Nodes); }
                PresetsManager.IsPresetSelected = true;
                var newNode = _presetTree.SelectedNode.Nodes.Add(pName);
                newNode.Tag = PresetsManager.GetNewId();
                _presetTree.SelectedNode = newNode;
                ListFiles.Files.Clear();
                ListFiles.AddFile(file);
                PresetsManager.AddCurrentPresetSettings();
                DescriptionManager.SaveLastDescription((int)newNode.Tag);
                PresetsManager.Save();
            }
            RestoreLSN();
            int filecount = Files.Count;
            if (cbClearList.Checked)
            {
                Files.Clear();
                lbxFiles.Items.Clear();
            }
            lbxFiles.EndUpdate();
            EnableDisableButtons();
            if (cbImportSummary.Checked)
                using (new CenterWinDialog(this))
                { MessageBox.Show($"Imported {filecount} maps to {folder}", $"{title} - Summary"); }
        }

        private void btDone_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void SaveSettings()
        {
            Settings.CurrentSettings.optClearAfterImport = cbClearList.Checked;
            Settings.CurrentSettings.optImportSummary = cbImportSummary.Checked;
            Settings.Save(false);
        }
    }
}
