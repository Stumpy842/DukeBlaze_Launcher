using DragDukeLauncher.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    public partial class MainWindow : Form
    {

        private const string DukeWikiCommandsLink = @"https://wiki.eduke32.com/wiki/Command_line_options";

        public MainWindow()
        {
            InitializeComponent();
            ListFiles.Init(ListBoxFiles, this);
            Run.Init(AdditionalCommandsTextBox);
            AdditionalParameters.Init(this);
        }

        TreeNode lastSelectedNode { get; set; } = null;

        private void Form1_Load(object sender, EventArgs e)
        {           
            ListBoxFiles.AllowDrop = true;
            //ListBoxFiles.SelectionMode = SelectionMode.MultiSimple;
            ListBoxFiles.DragDrop += listBoxFiles_DragDrop;
            ListBoxFiles.DragEnter += listBoxFiles_DragEnter;
            ListBoxFiles.SelectedIndexChanged += ListBoxFilesSelected;


            PresetTree.AllowDrop = true;
            PresetTree.NodeMouseClick += FolderSelect;
            PresetTree.ItemDrag += new ItemDragEventHandler(PresetTree_ItemDrag);
            PresetTree.DragEnter += new DragEventHandler(PresetTree_DragEnter);
            PresetTree.DragOver += new DragEventHandler(PresetTree_DragOver);
            PresetTree.DragDrop += new DragEventHandler(PresetTree_DragDrop);
            PresetTree.HideSelection = false;
            PresetTree.DrawMode = TreeViewDrawMode.OwnerDrawText;
            PresetTree.DrawNode += PresetTree_DrawNode;

            EditFolderButton.Hide();

            RespawnModeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            SetDefaultParameters();

            GroupAdditionalParamsSetActive(false);

            GameDirTextBox.TextChanged += GameDirTextBox_TextChanged;
            CfgPathTextBox.TextChanged += CfgPathTextBox_TextAlignChanged;
            CustomExeTextBox.TextChanged += CustomExeTextBox_TextChanged;

            PresetsManager.Init(PresetTree, this);
            PresetsManager.Load();

            PresetTree.SelectedNode = PresetTree.Nodes[0];
            lastSelectedNode = PresetTree.Nodes[0];
            RefreshButtonDescription();
        }

        private void CustomExeTextBox_TextChanged(object sender, EventArgs e)
        {
            Tools.WaitSomeTime(1, delegate
            {
                CustomExeTextBox.Text = Tools.GetRelativePath(CustomExeTextBox.Text);
            });
        }

        private void GameDirTextBox_TextChanged(object sender, EventArgs e)
        {
            Tools.WaitSomeTime(1, delegate
            {
                GameDirTextBox.Text = Tools.GetRelativePath(GameDirTextBox.Text);
            });
        }

        private void CfgPathTextBox_TextAlignChanged(object sender, EventArgs e)
        {
            Tools.WaitSomeTime(1, delegate
            {
                CfgPathTextBox.Text = Tools.GetRelativePath(CfgPathTextBox.Text);
            });
        }

        public void RecoverLastSelectedNode()
        {
            PresetTree.SelectedNode = lastSelectedNode;
        }

        public void SaveLastSelectedNode()
        {
            lastSelectedNode = PresetTree.SelectedNode;
        }


        public void SetDefaultParameters()
        {
            ListBoxFiles.Items.Clear();
            GroupAdditionalParamsSetActive(false);
            AdditionalParameters.SetDefaultParameters();
            AdditionalCommandsTextBox.Text = String.Empty;
            PresetNameTextBox.Text = String.Empty;
            CustomExeTextBox.Text = String.Empty;
        }


        private void ListBoxFilesSelected(object sender, EventArgs e)
        {
            if (ListBoxFiles.SelectedIndex == -1) return;

            string fileExtension = ListBoxFiles.Items[ListBoxFiles.SelectedIndex].ToString().Split('.').Last();
            DukeFileType fileType = FileTypesBase.GetFileType(fileExtension);

            if (fileType != null)
            {
                if (fileType.HasAdditionalParameters)
                {
                    GroupAdditionalParamsSetActive(true);
                }
                else
                {
                    GroupAdditionalParamsSetActive(false);
                }
            }
            else
            {
                GroupAdditionalParamsSetActive(false);
            }
        }


        private void GroupAdditionalParamsSetActive(bool active)
        {
            if (active)
            {
                GroupAdditionalParams.Show();
                GroupAdditionalParams.Text = ListBoxFiles.Items[ListBoxFiles.SelectedIndex].ToString();
                ReplaceMainCheckbox.Checked = ListFiles.IsSelectedFileAsMain();
            }
            else
            {
                GroupAdditionalParams.Hide();
            }
        }


        private void listBoxFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            RecoverLastSelectedNode();
        }


        private void listBoxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                ListFiles.AddFile(file);
            }
            ListFiles.Refresh(true);
            RecoverLastSelectedNode();
        }


        private void ReplaceMainCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ListFiles.SetSelectedFileAsMain(ReplaceMainCheckbox.Checked);
        }


        private void ButtonRemoveFile_Click(object sender, EventArgs e)
        {
            ListFiles.RemoveFile();
            ListFiles.Refresh();
            ListFiles.ClearSelection();
            GroupAdditionalParamsSetActive(false);
        }


        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            ListFiles.MoveUp();
            ListFiles.Refresh(true);
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            ListFiles.MoveDown();
            ListFiles.Refresh(true);
        }

        private void ArgsHelpButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(DukeWikiCommandsLink);
        }


        private void RunButton_Click(object sender, EventArgs e)
        {
            Run.RunGame();
        }


        private void GameDirBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection";

            if (Directory.Exists(GameDirTextBox.Text))
            {
                if(GameDirTextBox.Text.Contains(Tools.Slash))
                {
                    folderBrowser.InitialDirectory = GameDirTextBox.Text;
                }
                else
                {
                    var fullPath = Tools.GetPathWithAppDomain(GameDirTextBox.Text);
                    folderBrowser.InitialDirectory = fullPath;
                }
            }

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                GameDirTextBox.Text = Tools.GetRelativePath(folderPath);
                Console.WriteLine(folderPath);
            }
        }


        private void CfgPathBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog cfgBrowser = new OpenFileDialog();
            cfgBrowser.Filter = "cfg files (*.cfg)|*.cfg|All files (*.*)|*.*";
            cfgBrowser.FilterIndex = 1;
            cfgBrowser.RestoreDirectory = true;

            if (Directory.Exists(CfgPathTextBox.Text))
            {
                if (CfgPathTextBox.Text.Contains(Tools.Slash))
                {
                    cfgBrowser.InitialDirectory = CfgPathTextBox.Text;
                }
                else
                {
                    var fullPath = Tools.GetPathWithAppDomain(CfgPathTextBox.Text);
                    cfgBrowser.InitialDirectory = fullPath;
                }
            }

            if (cfgBrowser.ShowDialog() == DialogResult.OK)
            {
                string filePath = cfgBrowser.FileName;
                CfgPathTextBox.Text = Tools.GetRelativePath(filePath);
            }
        }

        private void SaveAsPresetButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(PresetNameTextBox.Text))
            {
                if (PresetTree.SelectedNode.Text.Contains(Tools.FolderIcon))
                {
                    // Add as new
                    PresetsManager.IsPresetSelected = true;
                    var newNode = PresetTree.SelectedNode.Nodes.Add($"{PresetNameTextBox.Text}");
                    newNode.Tag = PresetsManager.GetNewId().ToString();
                    PresetTree.SelectedNode = newNode;
                    SaveLastSelectedNode();
                    PresetsManager.AddCurrentPresetSettings();
                    DescriptionManager.SaveLastDescription(int.Parse(newNode.Tag.ToString()));
                    RefreshButtonDescription();
                }
                else
                {
                    // Edit current
                    PresetTree.SelectedNode.Text = $"{PresetNameTextBox.Text}";
                    PresetsManager.AddCurrentPresetSettings();
                }
                PresetsManager.Save();
            }
            else
            {
                MessageBox.Show("Preset name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EmptyButton_Click(object sender, EventArgs e)
        {
            SetDefaultParameters();
            ListFiles.Clear();
            PresetTree.SelectedNode = PresetTree.Nodes[0];
        }


        // PRESET TREE
        private void FolderSelect(object sender, TreeNodeMouseClickEventArgs e)
        {
            Tools.WaitSomeTime(1, delegate //lol
            {
                SelectItem();
            });
        }

        public void SelectItem()
        {
            if (PresetTree.SelectedNode == null) return;
            if (PresetTree.SelectedNode.Parent == null) EditFolderButton.Hide();
            ListFiles.Clear();
            ListBoxFiles.Items.Clear();
            if (PresetTree.SelectedNode.Text.Contains(Tools.FolderIcon))
            {
                PresetNameTextBox.Text = String.Empty;
                if (PresetTree.SelectedNode.Parent != null) EditFolderButton.Show();
                if (PresetsManager.IsPresetSelected)
                {
                    PresetsManager.IsPresetSelected = false;
                    SetDefaultParameters();
                }
            }
            else
            {
                SetDefaultParameters();
                PresetNameTextBox.Text = PresetTree.SelectedNode.Text;
                if (PresetTree.SelectedNode.Parent != null) EditFolderButton.Hide();
                PresetsManager.SetCurrentPresetSettings();
            }
            DescriptionManager.ClearLastDescription();
            RefreshButtonDescription();

            SaveLastSelectedNode();
        }

        public void RefreshButtonDescription()
        {
            if (PresetTree.SelectedNode != null)
            {
                if (DescriptionManager.IsDescriptionExist(int.Parse(PresetTree.SelectedNode.Tag.ToString())))
                {
                    DescriptionButton.Text = DescriptionManager.GetFolderNameByDescription(true);
                }
                else
                {
                    DescriptionButton.Text = DescriptionManager.GetFolderNameByDescription(false);
                }
            }
        }

        private void NewPresetFolderBtn_Click(object sender, EventArgs e)
        {
            if (PresetTree.SelectedNode.Text.Contains(Tools.FolderIcon))
            {
                NewFolderWindow newFolderWindow = new NewFolderWindow(PresetTree);
                newFolderWindow.ShowDialog(this);
            }
            else
            {
                // You can't create a folder in the preset
            }
        }


        private void PresetTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }


        private void PresetTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }


        private void PresetTree_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = PresetTree.PointToClient(new Point(e.X, e.Y));
            PresetTree.SelectedNode = PresetTree.GetNodeAt(targetPoint);
        }


        private void PresetTree_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = PresetTree.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = PresetTree.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (draggedNode == null)
            {
                RecoverLastSelectedNode();
                return;
            }

            if (draggedNode.Parent == null) return;


            try
            {
                if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
                {
                    if (e.Effect == DragDropEffects.Move)
                    {

                        if (!targetNode.Text.Contains(Tools.FolderIcon) && !draggedNode.Text.Contains(Tools.FolderIcon))
                        {
                            RecoverLastSelectedNode();
                            return;
                        }

                        if (!targetNode.Text.Contains(Tools.FolderIcon) && draggedNode.Text.Contains(Tools.FolderIcon))
                        {
                            RecoverLastSelectedNode();
                            return;
                        }

                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                    }

                    else if (e.Effect == DragDropEffects.Copy)
                    {
                        targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                    }

                    targetNode.Expand();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            return ContainsNode(node1, node2.Parent);
        }


        private void DescriptionButton_Click(object sender, EventArgs e)
        {
            if (PresetTree.SelectedNode == null) return;
            DescriptionWindow addPresetWindow = new DescriptionWindow(this);
            addPresetWindow.ShowDialog(this);
        }


        private void PresetTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;

            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            if (selected && unfocused)
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }


        private void RemovePresetFolderButton_Click(object sender, EventArgs e)
        {
            if (PresetTree.SelectedNode == null) return;
            if (PresetTree.SelectedNode.Text.Contains(Tools.FolderIcon))
            {
                if (PresetTree.SelectedNode.Parent != null)
                {
                    DescriptionManager.LoadDescriptionFromFile();
                    foreach (var child in TreeViewTools.Collect(PresetTree.SelectedNode.Nodes))
                    {
                        int currentNodeId = int.Parse(child.Tag.ToString());
                        DescriptionManager.Remove(currentNodeId);
                        PresetsManager.RemovePresetSettings(currentNodeId);
                    }
                    PresetTree.SelectedNode.Remove();
                }
            }
            else
            {
                int currentNodeId = int.Parse(PresetTree.SelectedNode.Tag.ToString());
                PresetTree.SelectedNode.Remove();
                DescriptionManager.Remove(currentNodeId);
                PresetsManager.RemovePresetSettings(currentNodeId);
            }
            PresetsManager.Save();
            SelectItem();
        }


        private void DownPresetButton_Click(object sender, EventArgs e)
        {
            if (PresetTree.SelectedNode == null) return;
            if (PresetTree.SelectedNode.Parent != null)
            {
                TreeViewTools.MoveDown(PresetTree.SelectedNode);
                PresetsManager.Save();
            }
        }


        private void UpPresetButton_Click(object sender, EventArgs e)
        {
            if (PresetTree.SelectedNode == null) return;
            if (PresetTree.SelectedNode.Parent != null)
            {
                TreeViewTools.MoveUp(PresetTree.SelectedNode);
                PresetsManager.Save();
            }
        }


        private void EditFolderButton_Click(object sender, EventArgs e)
        {
            NewFolderWindow newFolderWindow = new NewFolderWindow(PresetTree, true);
            newFolderWindow.ShowDialog(this);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog(this);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            fileBrowser.Filter = "All files (*.*)|*.*";
            fileBrowser.FilterIndex = 1;
            fileBrowser.RestoreDirectory = true;

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                string filePath = Tools.GetRelativePath(fileBrowser.FileName);
                ListFiles.AddFile(filePath);
                ListFiles.Refresh(true);
                RecoverLastSelectedNode();
            }
        }


        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog(this);
        }

        private void CustomExeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog exeBrowser = new OpenFileDialog();
            exeBrowser.Filter = "exe files (*.exe)|*.exe";
            exeBrowser.FilterIndex = 1;
            exeBrowser.RestoreDirectory = true;

            if (Directory.Exists(CustomExeTextBox.Text))
            {
                if (CustomExeTextBox.Text.Contains(Tools.Slash))
                {
                    exeBrowser.InitialDirectory = CustomExeTextBox.Text;
                }
                else
                {
                    var fullPath = Tools.GetPathWithAppDomain(CustomExeTextBox.Text);
                    exeBrowser.InitialDirectory = fullPath;
                }
            }

            if (exeBrowser.ShowDialog() == DialogResult.OK)
            {
                string filePath = exeBrowser.FileName;
                CustomExeTextBox.Text = Tools.GetRelativePath(filePath);
            }
        }
    }
}