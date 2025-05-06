using DukeBlazeLauncher.Extensions;
using DukeBlazeLauncher;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DukeBlazeLauncher
{
    public partial class MainWindow : Form
    {
        // Definition of SettingsFilePath is in Settings.cs
        // Definitions of PresetsSavePath and PresetsSettingsSavePath are in PresetsManager.cs
        // Definition of DescriptionFilePath is in DescriptionManager.cs

        // Link displayed in ArgsHelpButton label
        private const string DukeWikiCommandsLink = @"https://wiki.eduke32.com/wiki/Command_line_options";

        // Notepad definition (used for opening cfg files)
        private string notepadPath;

        // MainWindow.Text property
        internal static string MyTitle { get; private set; }

        // Color the ancestors of the selected tree node
        private bool DoColor;
        private readonly List<TreeNode> ColoredNodes = [];
        private Color myColor, myBackColor;

        // PresetTree expanded state
        private bool TreeExpanded = false;
        private bool optExpandTree = false;

        // Strings for Tools -> Cfg Files menu item
        // Steve - 01/18/2025 21:23:00
        // Configuration files from EDuke32
        private const string autoexec = "autoexec.cfg";
        private const string edcfg = "eduke32.cfg";
        private const string setcfg = "settings.cfg";
        private const string edlog = "eduke32.log";

        // Settings variables
        private bool optSaveUseBrowser;
        private bool optConfirmOverWrite;
        private bool optConfirmDelete;
        private bool optUseNotepad;
        private Settings.PC PreventPresetCollisions;
        private Settings.PC PreventFolderCollisions;

        // The screenOffset is used to account for any desktop bands 
        // that may be at the top or left side of the screen when 
        // determining when to cancel the drag drop operation
        private Point screenOffset;

        public MainWindow()
        {
            InitializeComponent();
            PresetTree.Sorted = false;
            ListFiles.Init(ListBoxFiles, this);
            Run.Init(AdditionalCommandsTextBox);
            AdditionalParameters.Init(this);
            MyTitle = Text;
        }

        TreeNode lastSelectedNode { get; set; } = null;
        TreeNode lastDraggedNode { get; set; } = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBoxFiles.AllowDrop = true;
            //ListBoxFiles.SelectionMode = SelectionMode.MultiSimple;
            ListBoxFiles.DragDrop += listBoxFiles_DragDrop;
            ListBoxFiles.DragEnter += listBoxFiles_DragEnter;
            ListBoxFiles.SelectedIndexChanged += ListBoxFilesSelected;

            PresetTree.AllowDrop = true;
            // New handler for MyTreeView control which supports SelectedNodeChanged event
            // This handles both mouse click and keyboard input
            PresetTree.SelectedNodeChanged += FolderSelect;

            // New event handler for PresetTree drag drop
            // Steve - 04/27/25
            PresetTree.QueryContinueDrag += PresetTree_QueryContinueDrag;

            PresetTree.ItemDrag += PresetTree_ItemDrag;
            PresetTree.DragEnter += PresetTree_DragEnter;
            PresetTree.DragOver += PresetTree_DragOver;
            PresetTree.DragDrop += PresetTree_DragDrop;

            PresetTree.HideSelection = false;
            PresetTree.DrawMode = TreeViewDrawMode.OwnerDrawText;
            PresetTree.DrawNode += PresetTree_DrawNode;

            NewPresetFolderButton.Enabled = false;
            SaveAsPresetButton.Enabled = false;
            EditFolderButton.Enabled = false;
            MoveUpButton.Enabled = false;
            MoveDownButton.Enabled = false;
            ButtonRemoveFile.Enabled = false;
            RunButton.Enabled = false;
            RemovePresetFolderButton.Enabled = false;
            UpPresetButton.Enabled = false;
            DownPresetButton.Enabled = false;
            DescriptionButton.Enabled = false;
            RespawnModeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            GameDirTextBox.TextChanged += GameDirTextBox_TextChanged;
            CfgPathTextBox.TextChanged += CfgPathTextBox_TextAlignChanged;
            CustomExeTextBox.TextChanged += CustomExeTextBox_TextChanged;

            aboutToolStripMenuItem.Text = $"&About {MyTitle}";
            lbLoadSavePath.Text = "";
            // Create the SavedPresets and LauncherData folders if missing
            CheckCreateDir();
            // Write a warning file to LauncherData folder (do not modify folder contents)
            // Steve - 02/06/2025 21:02:13
            Tools.WriteWarningFile();
            LoadSettings();
            PresetsManager.CreateFiles();
            ResetAll();
        }

        private void LoadSettings()
        {
            Settings.Load();
            // Does Save Presets dialog use FolderBrowser or simple InputDialog
            optSaveUseBrowser = Settings.CurrentSettings.optSaveUseBrowser;
            // Prevent name collisions when adding new Presets
            PreventPresetCollisions = Settings.CurrentSettings.PreventPresetCol;
            // Prevent name collisions when adding new Folders
            PreventFolderCollisions = Settings.CurrentSettings.PreventFolderCol;
            DoColor = Settings.CurrentSettings.optUseColor;
            myColor = Settings.CurrentSettings.CurrentColor;
            myBackColor = Tools.GetContrastColor(myColor);
            optExpandTree = Settings.CurrentSettings.optExpandTree;
            optConfirmOverWrite = Settings.CurrentSettings.optConfirmOverWrite;
            optConfirmDelete = Settings.CurrentSettings.optConfirmDelete;
            optUseNotepad = Settings.CurrentSettings.optUseNotepad;
            notepadPath = Settings.CurrentSettings.notepadPath;
        }

        private void ResetAll()
        {
            PresetTree.BeginUpdate();
            PresetTree.Nodes.Clear();
            PresetTree.TreeViewNodeSorter = null;
            SetDefaultParameters();
            GroupAdditionalParamsSetActive(false);
            PresetsManager.Init(PresetTree, this);
            PresetsManager.Load();
            PresetTree.EndUpdate();
            PresetTree.SelectedNode = PresetTree.TopNode;
            SaveLastSelectedNode();
            RefreshButtonDescription();
            CheckExpand(true);
            UpdateStatusStrip();
        }

        private void CheckExpand(bool ExpandIt = false)
        {
            if (PresetTree.GetNodeCount(true) <= 3)
            {
                ExpandButton.Enabled = false;
                TreeExpanded = false;
                ExpandButton.Text = "Expand";
            }
            else
            {
                ExpandButton.Enabled = true;
                TreeExpanded = true;
                ExpandButton.Text = "Collapse";
                if (ExpandIt)
                {
                    TreeExpanded = !optExpandTree;
                    TreeExpand();
                }
            }
        }

        // Update the contents of the StatusStrip 
        // Steve - 01/31/2025 14:28:26
        private void UpdateStatusStrip()
        {
            UpdateTreeStatusLabel();
            UpdateCollisionsStatus();
            UpdateExePathStatusLabel();
            StatusStrip.Refresh();
        }

        private void UpdateExePathStatusLabel()
        {
            string path = $"EDuke32 Path: {Settings.CurrentSettings.ExePath}";
            ExePathStatusLabel.Text = path;
        }

        private void UpdateCollisionsStatus()
        {
            CollisionsStatusLabel.Text = $"Collisions: Folders={GetNC(true)}, Presets={GetNC()}";
        }

        private void UpdateTreeStatusLabel()
        {
            int f = 0; int p = 0;
            foreach (var node in TreeViewTools.Collect(PresetTree.Nodes))
            { if (node.Text.StartsWith(Tools.FolderIcon)) f++; else p++; }
            TreeStatusLabel.Text = $"Tree: {f} Folders, {p} Presets";
        }

        // Create the SavedPresets & LauncherData folders (if they don't exist)
        // Steve - 01/31/2025 08:53:01
        private static void CheckCreateDir()
        {
            static void DoDir(string path)
            {
                try
                {
                    if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine($@"***Failed to create directory '{path}'", ex);
                    MessageBox.Show($"Failed to create directory '{path}'\n{ex}", MyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            DoDir(Tools.GetPathWithAppDomain(Tools.SavedPresetsDir));
            DoDir(Tools.GetPathWithAppDomain(Tools.ldFolder));
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

        internal void RecoverLastSelectedNode()
        {
            PresetTree.SelectedNode = lastSelectedNode;
        }

        internal void SaveLastSelectedNode()
        {
            lastSelectedNode = PresetTree.SelectedNode;
        }

        internal void RecoverLastDraggedNode()
        {
            PresetTree.SelectedNode = lastDraggedNode;
        }

        internal void SaveLastDraggedNode()
        {
            lastDraggedNode = PresetTree.SelectedNode;
        }

        internal void SetDefaultParameters()
        {
            ListBoxFiles.Items.Clear();
            GroupAdditionalParamsSetActive(false);
            AdditionalParameters.SetDefaultParameters();
            AdditionalCommandsTextBox.Text = String.Empty;
            PresetNameTextBox.Text = String.Empty;
            CustomExeTextBox.Text = String.Empty;
        }

        // ListBoxFiles.SelectedIndexChanged event handler
        private void ListBoxFilesSelected(object sender, EventArgs e)
        {
            IsListBoxFileSelected();
        }

        private void IsListBoxFileSelected()
        {
            int si = ListBoxFiles.SelectedIndex;
            if (si == -1)
            {
                MoveUpButton.Enabled = false;
                MoveDownButton.Enabled = false;
                ButtonRemoveFile.Enabled = false;
                return;
            }
            ButtonRemoveFile.Enabled = true;
            MoveUpButton.Enabled = si > 0;
            MoveDownButton.Enabled = si < ListBoxFiles.Items.Count - 1;
            string fileExtension = ListBoxFiles.Items[ListBoxFiles.SelectedIndex].ToString().Split('.').Last();
            DukeFileType fileType = FileTypesBase.GetFileType(fileExtension);

            bool hasParams = fileType is not null && fileType.HasAdditionalParameters;
            GroupAdditionalParamsSetActive(hasParams);
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
            RemoveAFile();
        }

        private void RemoveAFile()
        {
            ListFiles.RemoveFile();
            ListFiles.Refresh();
            ListFiles.ClearSelection();
            GroupAdditionalParamsSetActive(false);
            // There is no file selected now so disable ButtonRemoveFile etc
            // Steve - 01/17/2025 23:01:28
            ButtonRemoveFile.Enabled = false;
            MoveUpButton.Enabled = false;
            MoveDownButton.Enabled = false;
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
            try
            {
                using Process pr = Process.Start(new ProcessStartInfo(DukeWikiCommandsLink) { UseShellExecute = true })!;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"***{ex}");
                MessageBox.Show($@"Cannot start {DukeWikiCommandsLink}" + $"\n{ex}", MyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            Run.RunGame();
        }

        private void GameDirBrowseButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog folderBrowser = new()
            {
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Folder Selection"
            };

            if (!String.IsNullOrEmpty(GameDirTextBox.Text) && (Directory.Exists(GameDirTextBox.Text)))
            {
                if (GameDirTextBox.Text.Contains(Tools.Slash))
                {
                    folderBrowser.InitialDirectory = GameDirTextBox.Text;
                }
                else
                {
                    var fullPath = Tools.GetPathWithAppDomain(GameDirTextBox.Text);
                    folderBrowser.InitialDirectory = fullPath;
                }
            }
            else { folderBrowser.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory; }


            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                GameDirTextBox.Text = Tools.GetRelativePath(folderPath);
                Console.WriteLine(folderPath);
                //Debug.WriteLine($"***{folderPath}");
            }
        }

        private void CfgPathBrowseButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog cfgBrowser = new();
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

            if (cfgBrowser.ShowDialog(this) == DialogResult.OK)
            {
                string filePath = cfgBrowser.FileName;
                CfgPathTextBox.Text = Tools.GetRelativePath(filePath);
            }
        }

        private void SaveAsPresetButton_Click(object sender, EventArgs e)
        {
            SaveAsPreset();
        }

        // Separate method from Button_Click event handler so it can be reused
        // Steve - 01/17/2025 16:40:28
        private void SaveAsPreset()
        {
            void AddAsNew()
            {
                string pName = PresetNameTextBox.Text.Trim();
                // If name collisions not allowed, get a new name for Preset
                // Steve - 01/23/2025 16:37:48
                if (PreventPresetCollisions == Settings.PC.Folder)
                { pName = Tools.NewName(pName, PresetTree.SelectedNode.Nodes); }
                else if (PreventPresetCollisions == Settings.PC.Global)
                { pName = Tools.NewName(pName, PresetTree.Nodes); }
                PresetsManager.IsPresetSelected = true;
                var newNode = PresetTree.SelectedNode.Nodes.Add(pName);
                newNode.Tag = PresetsManager.GetNewId();
                PresetTree.SelectedNode = newNode;
                SaveLastSelectedNode();
                PresetsManager.AddCurrentPresetSettings();
                DescriptionManager.SaveLastDescription((int)newNode.Tag);
                RefreshButtonDescription();
                newNode.Expand();
            }

            int AddReplacePreset()
            {
                TaskDialogPage AorR = new()
                {
                    Caption = "Add or Replace Preset",
                    Heading = "Do you want to add a new preset\nor replace the current one?",
                    AllowCancel = true,
                    AllowMinimize = false,
                    SizeToContent = true,
                    Footnote = new TaskDialogFootnote() { Text = $"Name collision is currently set to {GetNC()}" },
                    Buttons =
                    {
                        new TaskDialogCommandLinkButton("&Add Preset", "Add a new Preset in the current Folder"),
                        new TaskDialogCommandLinkButton("&Replace Preset", "Replace the current Preset with this one"),
                        new TaskDialogCommandLinkButton("&Cancel", "Cancel the operation")
                    },
                    Expander = new TaskDialogExpander()
                    {
                        Text = "Name collision settings are under File -> Settings on the Advanced tab. Sorting the tree " +
                            "may not work properly if there are multiple nodes with the same name.",
                        Position = TaskDialogExpanderPosition.AfterFootnote
                    }
                };

                TaskDialogButton result = TaskDialog.ShowDialog(this, AorR);
                // Debug.WriteLine($"***{result.ToString()}");
                return result.ToString() switch
                {
                    "&Add Preset" => 1,
                    "&Replace Preset" => 2,
                    _ => 3,
                };
            }

            // Main SaveAsPreset() method starts here
            // Steve - 01/23/2025 15:46:15
            if (PresetTree.SelectedNode is null) { return; }
            if (!String.IsNullOrEmpty(PresetNameTextBox.Text))
            {
                if (PresetTree.SelectedNode.Text.StartsWith(Tools.FolderIcon))
                {
                    // Add as new
                    AddAsNew();
                }
                else
                {
                    switch (AddReplacePreset())
                    {
                        case 1:
                            {   // Add as new preset
                                // Need to move up one node first
                                if (PresetTree.SelectedNode.Parent is null)
                                {
                                    Tools.TimedMessage($"Can't find parent of '{PresetTree.SelectedNode.Text}'", "Error", this);
                                    return;
                                }
                                PresetTree.SelectedNode = PresetTree.SelectedNode.Parent;
                                SaveLastSelectedNode(); // Is this needed this here?
                                AddAsNew();
                                break;
                            }
                        case 2:
                            {
                                // Replace current preset
                                // Name collision detection not needed here
                                PresetTree.SelectedNode.Text = PresetNameTextBox.Text;
                                PresetsManager.AddCurrentPresetSettings();
                                break;
                            }
                        case 3:
                            {
                                // Cancel operation
                                return;
                            }
                    }
                }
                PresetsManager.Save();
                UpdateStatusStrip();
                CheckExpand();
            }
            else
            {
                // Execution will not reach this point since SaveAsPresetButton is disabled when PresetNameTextbox is empty
                Tools.TimedMessage("Preset name is empty", "Error", this);
            }
        }

        private string GetNC(bool Folders = false)
        {
            string nc;
            using SettingsWindow nsw = new(false);
            if (Folders)
            {
                nc = PreventFolderCollisions switch
                {
                    Settings.PC.Allow => nsw.rbFolderAll.Text,
                    Settings.PC.Folder => nsw.rbFolderParent.Text,
                    Settings.PC.Global => nsw.rbFolderGlobal.Text,
                    _ => throw new ArgumentException("Unknown parameter", PreventFolderCollisions.ToString()),
                };
            }
            else
            {
                nc = PreventPresetCollisions switch
                {
                    Settings.PC.Allow => nsw.rbPresetAll.Text,
                    Settings.PC.Folder => nsw.rbPresetFolder.Text,
                    Settings.PC.Global => nsw.rbPresetGlobal.Text,
                    _ => throw new ArgumentException("Unknown parameter", PreventPresetCollisions.ToString()),
                };
            }
            return nc;
        }

        private void EmptyButton_Click(object sender, EventArgs e)
        {
            SetDefaultParameters();
            ListFiles.Clear();
            PresetTree.SelectedNode = PresetTree.TopNode;
        }

        // PRESET TREE
        // Updated for new MyTreeView control which supports SelectedNodeChanged event
        private void FolderSelect(object sender, TreeViewEventArgs e)
        {
            Tools.WaitSomeTime(1, delegate //lol
            {
                SelectItem();
            });
        }

        internal void SelectItem()  // This method is looking like Spaghetti code now, sorry ;-)
        {
            void SetRPFButtonToolTip()
            {
                string s = PresetTree.SelectedNode.GetNodeCount(true) > 0 ? " and subitems" : "";
                toolTip1.SetToolTip(RemovePresetFolderButton, $"Remove item{s}");
            }

            if (PresetTree.SelectedNode is null) return;
            if (PresetTree.SelectedNode.Parent is null)
            {
                EditFolderButton.Enabled = false;
                RemovePresetFolderButton.Enabled = false;
            }
            ListFiles.Clear();
            ListBoxFiles.Items.Clear();
            if (PresetTree.SelectedNode.Text.StartsWith(Tools.FolderIcon))
            {
                // A folder is selected
                RunButton.Enabled = false;
                DescriptionButton.Enabled = false;
                NewPresetFolderButton.Enabled = true;
                PresetNameTextBox.Text = String.Empty;
                removeAllpresetsToolStripMenuItem.Enabled = true;
                selectedNodeToolStripMenuItem.Enabled = true;
                selectedFolderSubfoldersToolStripMenuItem.Enabled = true;
                if (PresetTree.SelectedNode.Parent is not null)
                {
                    EditFolderButton.Enabled = true;
                    RemovePresetFolderButton.Enabled = true;
                    SetRPFButtonToolTip();
                }
                if (PresetsManager.IsPresetSelected)
                {
                    PresetsManager.IsPresetSelected = false;
                    SetDefaultParameters();
                }
            }
            else
            {
                // A preset is selected
                RunButton.Enabled = true;
                DescriptionButton.Enabled = true;
                NewPresetFolderButton.Enabled = false;
                SetDefaultParameters();
                PresetNameTextBox.Text = PresetTree.SelectedNode.Text;
                removeAllpresetsToolStripMenuItem.Enabled = false;
                selectedNodeToolStripMenuItem.Enabled = false;
                selectedFolderSubfoldersToolStripMenuItem.Enabled = false;
                // Steve - 01/13/2025 19:32:02
                EditFolderButton.Enabled = false;
                RemovePresetFolderButton.Enabled = true;
                SetRPFButtonToolTip();
                PresetsManager.SetCurrentPresetSettings();
            }
            DescriptionManager.ClearLastDescription();
            RefreshButtonDescription();
            // 
            // Steve - 01/17/2025 00:56:16
            SetUpDownPresetButtons();
            IsListBoxFileSelected();
            SaveLastSelectedNode();
            ColorAncestors();
        }

        private void ColorAncestors()
        {
            foreach (var anode in ColoredNodes)
            {
                anode.ForeColor = SystemColors.WindowText;
                anode.BackColor = SystemColors.Window;
            }
            ColoredNodes.Clear();
            if (!DoColor) { return; }
            var node = PresetTree.SelectedNode;
            while (node.Parent != null)
            {
                node = node.Parent;
                node.ForeColor = myColor;
                node.BackColor = myBackColor;
                ColoredNodes.Add(node);
            }
        }

        // Method to enable/disable up/down preset buttons
        // Steve - 01/17/2025 00:52:20
        internal void SetUpDownPresetButtons()
        {
            UpPresetButton.Enabled = TreeViewTools.NotFirstOrLast(PresetTree.SelectedNode);
            DownPresetButton.Enabled = TreeViewTools.NotFirstOrLast(PresetTree.SelectedNode, false);
        }

        internal void RefreshButtonDescription()
        {
            if (PresetTree.SelectedNode is not null)
            {
                if (DescriptionManager.IsDescriptionExist((int)PresetTree.SelectedNode.Tag))
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
            if (PresetTree.SelectedNode.Text.StartsWith(Tools.FolderIcon))
            {
                using NewFolderWindow newFolderWindow = new(PresetTree, PreventFolderCollisions) { KeyPreview = true };
                newFolderWindow.ShowDialog(this);
                UpdateStatusStrip();
                PresetTree.Focus();
            }
            else
            {
                // You can't create a folder in the preset
                // Execution will not reach this point since NewPresetFolderButton is disabled
                //   when a preset node is selected as opposed to a folder node being selected
                Tools.TimedMessage("You can't create a folder in the preset", "Error", this);
            }
        }

        private void PresetTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SaveLastDraggedNode();
                // Fixed PresetTree drag drop to allow Copy
                // Steve - 04/27/2025 19:55:54
                screenOffset = SystemInformation.WorkingArea.Location;
                DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy | DragDropEffects.Link);
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
            // Only allow drag drop of TreeNode data type
            // Steve - 04/27/2025 19:17:37
            if (!e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            // Set the operation based upon the KeyState
            if ((e.KeyState & (4 + 8)) == (4 + 8)) e.Effect = DragDropEffects.Move | DragDropEffects.Copy; // SHIFT+CTRL = Copy all children
            else if ((e.KeyState & (8 + 32)) == (8 + 32)) e.Effect = DragDropEffects.Copy | DragDropEffects.Link; // ALT+CTRL = Copy Preset only
            else if ((e.KeyState & 4) == 4) e.Effect = DragDropEffects.Move | DragDropEffects.Link; // SHIFT = Move all children
            else if ((e.KeyState & 8) == 8) e.Effect = DragDropEffects.Copy; // CTRL = Copy
            else if ((e.KeyState & 32) == 32) e.Effect = DragDropEffects.Link; // ALT = Move Preset only
            else e.Effect = DragDropEffects.Move; // By default, the drop action is Move
        }

        private void PresetTree_DragDrop(object sender, DragEventArgs e)
        {
            static bool ContainsNode(TreeNode dragged, TreeNode target)
            {
                if (target.Parent is null) return false;
                if (target.Parent.Equals(dragged)) return true;
                return ContainsNode(dragged, target.Parent);
            }

            static void MoveNode(TreeNode dragged, TreeNode target)
            {
                dragged.Remove();
                target.Nodes.Add(dragged);
            }

            static void CopyNode(TreeNode dragged, TreeNode target)
            {
                target.Nodes.Add((TreeNode)dragged.Clone());
            }

            void MoveCopyNodes(TreeNode dragged, TreeNode target, bool move, bool folders = true)
            {
                // Move/Copy content or Preset only from dragged node to target
                if (dragged.Text.StartsWith(Tools.FolderIcon))
                {
                    // Dragged a folder, move/copy just the content or Preset to target
                    for (int i = dragged.Nodes.Count - 1; i >= 0; i--)
                    {
                        if (folders || !dragged.Nodes[i].Text.StartsWith(Tools.FolderIcon))
                        {
                            if (move)
                            {
                                MoveNode(dragged.Nodes[i], target);
                            }
                            else
                            {
                                CopyNode(dragged.Nodes[i], target);
                            }
                        }
                    }
                    PresetTree.SelectedNode = target;
                }
                else
                {
                    // Dragged a Preset, move/copy it
                    MoveNode(dragged, target);
                    PresetTree.SelectedNode = dragged;
                }
            }

            // Method starts here
            Point targetPoint = PresetTree.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = PresetTree.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            // Need to check if targetNode is null also
            // Steve - 04/27/2025 21:53:27
            if (draggedNode is null || targetNode is null)
            {
                RecoverLastDraggedNode();
                return;
            }
            // Prevent moving/copying Root nodes
            if (draggedNode.Parent is null && e.Effect < (DragDropEffects.Move | DragDropEffects.Copy))
            {
                RecoverLastDraggedNode();
                return;
            }
            try
            {
                if (draggedNode.Equals(targetNode) || !targetNode.Text.StartsWith(Tools.FolderIcon))
                {
                    RecoverLastDraggedNode();
                    return;
                }

                if (e.Effect == DragDropEffects.Move)
                {
                    if (ContainsNode(draggedNode, targetNode) || draggedNode.Parent.Equals(targetNode))
                    {
                        RecoverLastDraggedNode();
                        return;
                    }
                    else
                    {
                        MoveNode(draggedNode, targetNode);
                        // Select the dragged node now
                        // Steve - 04/28/2025 22:18:48
                        PresetTree.SelectedNode = draggedNode;
                    }
                }
                else if (e.Effect == DragDropEffects.Copy)
                {
                    if (ContainsNode(draggedNode, targetNode))
                    {
                        RecoverLastDraggedNode();
                        return;
                    }
                    else
                    {
                        CopyNode(draggedNode, targetNode);
                        // Select the dragged node now
                        // Steve - 04/28/2025 22:18:48
                        PresetTree.SelectedNode = targetNode.Nodes[^1];
                    }
                }
                else if (e.Effect == DragDropEffects.Link)
                {
                    // Move Preset only from dragged node to target
                    MoveCopyNodes(draggedNode, targetNode, true, false);
                }
                else if (e.Effect == (DragDropEffects.Move | DragDropEffects.Link))
                {
                    // Move all children to target
                    if (ContainsNode(draggedNode, targetNode))
                    {
                        RecoverLastDraggedNode();
                        return;
                    }
                    else
                        MoveCopyNodes(draggedNode, targetNode, true);
                }
                else if (e.Effect == (DragDropEffects.Copy | DragDropEffects.Link))
                {
                    // Copy Preset only from dragged node to target
                    MoveCopyNodes(draggedNode, targetNode, false, false);
                }
                else if (e.Effect == (DragDropEffects.Copy | DragDropEffects.Move))
                {
                    // Copy all children to target
                    if (ContainsNode(draggedNode, targetNode))
                    {
                        RecoverLastDraggedNode();
                        return;
                    }
                    else
                        MoveCopyNodes(draggedNode, targetNode, false);
                }

                targetNode.Expand();
                // Now save the changes
                // Steve - 04/27/2025 20:46:28
                PresetsManager.Save();
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"***{ex}");
                Tools.ShowTaskDlg(this, MyTitle, "Error moving/copying node(s)", $"Source: {draggedNode}\nTarget: {targetNode}",
                    ex.ToString(), null, -1, TaskDialogIcon.Error);
            }
        }

        private void PresetTree_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // Cancel the drag if the mouse moves off the form
            TreeView treeView = sender as TreeView;
            if (treeView is not null)
            {
                Form f = treeView.FindForm();
                if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
                   ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
                   ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
                   ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
                {
                    e.Action = DragAction.Cancel;
                }
            }
        }

        private void OpenDescriptionWindow()
        {
            if (PresetTree.SelectedNode is null) { return; }
            using DescriptionWindow addPresetWindow = new(this) { KeyPreview = true };
            addPresetWindow.ShowDialog(this);
        }

        private void DescriptionButton_Click(object sender, EventArgs e)
        {
            OpenDescriptionWindow();
        }

        private void PresetTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node is null || e.Node.IsEditing) return;

            TreeNode node = e.Node;
            bool selected = e.State.HasFlag(TreeNodeStates.Selected);
            bool focused = e.State.HasFlag(TreeNodeStates.Focused);
            bool highlight = selected && (focused || !node.TreeView.HideSelection);
            Font font = node.NodeFont ?? node.TreeView.Font;
            Color foreColor = highlight
                ? SystemColors.HighlightText
                : node.ForeColor.IsEmpty
                ? node.TreeView.ForeColor
                : node.ForeColor;
            Color backColor = highlight
                ? SystemColors.Highlight
                : node.BackColor.IsEmpty
                ? node.TreeView.BackColor
                : node.BackColor;
            Rectangle bounds = e.Bounds;

            if (e.Node.TreeView.CheckBoxes)
            {
                bounds.Inflate(-1, 0);
            }

            using var brBack = new SolidBrush(backColor);

            e.Graphics.FillRectangle(brBack, bounds);

            TextRenderer.DrawText(
                e.Graphics,
                e.Node.Text,
                font,
                bounds,
                foreColor,
                TextFormatFlags.Left |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine);

            if (highlight && node.TreeView.Focused)
            {
                bounds.Width--;
                bounds.Height--;
                ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
            }
        }

        // Separate method from RemovePresetFolderButton_Click event handler so it can be reused
        // Steve - 01/13/2025 19:45:05
        private void RemovePresetFolderButton_Click(object sender, EventArgs e)
        {
            RemovePresetFolder(optConfirmDelete);
        }

        private void RemovePresetFolder(bool confirmOverWrite)
        {
            bool YesOrNo(string p, int c)
            {
                string s = c > 0 ? " and all subitems" : "";
                DialogResult result;
                using (new CenterWinDialog(this))
                {
                    result = MessageBox.Show($"Remove '{p}'{s}?", "Remove Preset", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                }
                return result == DialogResult.OK;
            }

            if (PresetTree.SelectedNode is null) return;
            if (PresetTree.SelectedNode.Text.StartsWith(Tools.FolderIcon))
            // Folder node is selected
            // Steve - 01/16/2025 14:03:46
            {
                if (PresetTree.SelectedNode.Parent is not null)
                {
                    DescriptionManager.LoadDescriptionFromFile();
                    // Confirm remove action
                    if (confirmOverWrite && (!YesOrNo(PresetTree.SelectedNode.Text[3..], PresetTree.SelectedNode.Nodes.Count))) return;

                    foreach (var child in TreeViewTools.Collect(PresetTree.SelectedNode.Nodes))
                    {
                        int currentNodeId = (int)child.Tag;
                        DescriptionManager.Remove(currentNodeId);
                        PresetsManager.RemovePresetSettings(currentNodeId);
                    }
                    PresetTree.SelectedNode.Remove();
                }
            }
            else
            // Preset node is selected
            // Steve - 01/16/2025 14:04:32
            {
                // Confirm remove action
                if (confirmOverWrite && (!YesOrNo(PresetTree.SelectedNode.Text, PresetTree.SelectedNode.Nodes.Count))) return;

                int currentNodeId = (int)PresetTree.SelectedNode.Tag;
                PresetTree.SelectedNode.Remove();
                DescriptionManager.Remove(currentNodeId);
                PresetsManager.RemovePresetSettings(currentNodeId);
            }
            PresetsManager.Save();
            SelectItem();
            UpdateStatusStrip();
            CheckExpand();
            PresetTree.Focus();
        }

        private void DownPresetButton_Click(object sender, EventArgs e)
        {
            if (PresetTree.SelectedNode is null) return;
            if (PresetTree.SelectedNode.Parent is not null)
            {
                TreeViewTools.MoveDown(PresetTree.SelectedNode);
                PresetsManager.Save();
                PresetTree.Focus();
            }
        }

        private void UpPresetButton_Click(object sender, EventArgs e)
        {
            if (PresetTree.SelectedNode is null) return;
            if (PresetTree.SelectedNode.Parent is not null)
            {
                TreeViewTools.MoveUp(PresetTree.SelectedNode);
                PresetsManager.Save();
                PresetTree.Focus();
            }
        }

        private void EditFolderButton_Click(object sender, EventArgs e)
        {
            using NewFolderWindow newFolderWindow = new(PresetTree, PreventFolderCollisions, true) { KeyPreview = true };
            newFolderWindow.ShowDialog(this);
            PresetTree.Focus();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileBrowser = new()
            {
                Filter = "All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = Tools.GetPathWithAppDomain("")
            };

            if (fileBrowser.ShowDialog(this) == DialogResult.OK)
            {
                string filePath = Tools.GetRelativePath(fileBrowser.FileName);
                ListFiles.AddFile(filePath);
                ListFiles.Refresh(true);
                RecoverLastSelectedNode();
            }
        }

        private void CustomExeButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog exeBrowser = new();
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

            if (exeBrowser.ShowDialog(this) == DialogResult.OK)
            {
                string filePath = exeBrowser.FileName;
                CustomExeTextBox.Text = Tools.GetRelativePath(filePath);
            }
        }

        private void PresetNameTextBox_TextChanged(object sender, EventArgs e)
        {
            bool Ok = PresetNameTextBox.Text.Length > 0;
            DescriptionButton.Enabled = Ok;
            SaveAsPresetButton.Enabled = Ok;
        }

        // Need this to repopulate fields since user can click on the same node after making changes
        //   and clicking the same node doesn't fire the SelectedNodeChanged event
        private void PresetTree_Enter(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void TryOpenDescriptionWindow()
        {
            if (!PresetTree.SelectedNode.Text.StartsWith(Tools.FolderIcon))
                OpenDescriptionWindow();
        }

        // DoubleClick on a preset node will open the Description window
        private void PresetTree_DoubleClick(object sender, EventArgs e)
        {
            TryOpenDescriptionWindow();
        }

        // Pressing the Enter key on a preset will open the Description window
        private void PresetTree_KeyDown(object sender, KeyEventArgs e)
        {
            // Add Delete key processing
            // Steve - 01/13/2025 20:14:10

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        e.SuppressKeyPress = true;
                        // Delay processing of event to prevent annoying Windows Asterisk "ding" sound
                        Tools.WaitSomeTime(1, delegate
                        {
                            TryOpenDescriptionWindow();
                        });
                        break;
                    }
                // Better handling of Delete key press on PresetTree node
                // Steve - 01/16/2025 16:39:54
                case Keys.Delete:
                    {
                        e.SuppressKeyPress = true;
                        if (PresetTree.SelectedNode.Text.StartsWith(Tools.FolderIcon))
                        {
                            if (PresetTree.SelectedNode.Parent is null)
                            {
                                Tools.TimedMessage($"May not delete Root folder '{PresetTree.SelectedNode.Text[3..]}'",
                                    "Root Folder Protected", this);
                                return;
                            }
                            else
                            {
                                Tools.TimedMessage("Use 'Edit -> Prune Preset Tree' to remove Folders",
                                    "Information", this, MessageBoxIcon.Asterisk);
                                return;
                            }
                        }
                        else RemovePresetFolder(optConfirmDelete);
                        break;
                    }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using AboutWindow aboutWindow = new() { KeyPreview = true };
            aboutWindow.ShowDialog(this);
        }

        private void ShowSettingsWindow(bool Show = true, int Tab = 0)
        {
            using SettingsWindow settingsWindow = new(Show, Tab) { KeyPreview = true };
            if (settingsWindow.ShowDialog(this) == DialogResult.OK)
            {
                LoadSettings();
                UpdateStatusStrip();
                ColorAncestors();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsWindow();
        }

        // New menu items
        // Steve - 01/13/2025 22:12:23
        private void RemoveAllFoldersOrPresets()
        {
            string Snode = PresetTree.SelectedNode.Text[3..];
            TaskDialogButtonCollection cButtons =
            [
                new TaskDialogCommandLinkButton($"&Prune Folder '{Snode}'",
                "Remove current folder including all subfolders and presets")
                { Tag = "Prune" },
                new TaskDialogCommandLinkButton($"&Crop Folder '{Snode}'",
                "Remove just the subfolders (and their presets) from current folder")
                { Tag = "Crop" },
                new TaskDialogCommandLinkButton($"&Trim Folder '{Snode}'",
                "Remove just the presets from current folder and subfolders")
                { Tag = "Trim" },
                new TaskDialogCommandLinkButton($"&Snip Folder '{Snode}'",
                "Remove presets from this folder only, keep subfolders")
                { Tag = "Snip" },
                TaskDialogButton.Cancel
            ];
            cButtons[cButtons.IndexOf(TaskDialogButton.Cancel)].Tag = "Cancel";

            TaskDialogPage PruneDlg = new()
            {
                Caption = "Prune Preset Tree",
                Heading = "What do you want to remove?",
                Text = "You can choose to remove Folders and Presets, or Presets only",
                Footnote = new()
                {
                    Text = "Operation cannot be undone. Save a copy first" +
                    "\nusing 'Save Presets' under the 'File' menu.",
                },
                Expander = new()
                {
                    Text = "Note: You can reload the original Presets by selecting" +
                        "\n'Reload Original Presets' under the 'Tools' menu." +
                        "\n\nThe Expansions, Episodes and Maps folders cannot be removed.",
                    Position = TaskDialogExpanderPosition.AfterFootnote
                },
                Buttons = cButtons,
                SizeToContent = true
            };

            TaskDialogButton result = TaskDialog.ShowDialog(this, PruneDlg, TaskDialogStartupLocation.CenterOwner);
            // Code to actually remove stuff from PresetsTree
            // Steve - 01/20/2025 20:13:48
            TreeNodeCollection Nodes = PresetTree.SelectedNode.Nodes;
            switch (result.Tag)
            {
                case "Prune":
                    RemoveStuff(Nodes, true);
                    break;
                case "Crop":
                    RemoveStuff(Nodes, false, false, true);
                    break;
                case "Trim": // It's complicated!
                    RemoveStuff(Nodes, false, true);
                    foreach (var child in TreeViewTools.Collect(Nodes))
                    {
                        if (child.Text.StartsWith(Tools.FolderIcon))
                        { RemoveStuff(child.Nodes, false, true); }
                    }
                    break;
                case "Snip":
                    RemoveStuff(Nodes, false, true);
                    break;
                default: return;
            }
            PresetsManager.Save();
            SelectItem();
            UpdateStatusStrip();
            CheckExpand();
            PresetTree.Focus();
        }

        private void RemoveStuff(TreeNodeCollection nodes, bool prune = false, bool presetsonly = false, bool foldersonly = false)
        {
            DescriptionManager.LoadDescriptionFromFile();
            foreach (var child in TreeViewTools.Collect(nodes))
            {
                if (presetsonly && child.Text.StartsWith(Tools.FolderIcon)) { continue; }
                if (foldersonly && !child.Text.StartsWith(Tools.FolderIcon)) { continue; }
                int currentNodeId = (int)child.Tag;
                DescriptionManager.Remove(currentNodeId);
                PresetsManager.RemovePresetSettings(currentNodeId);
            }
            if (prune && PresetTree.SelectedNode.Parent is not null) { PresetTree.SelectedNode.Remove(); }
            else
                for (int i = nodes.Count - 1; i >= 0; i--)
                {
                    if (presetsonly && nodes[i].Text.StartsWith(Tools.FolderIcon)) { continue; }
                    if (foldersonly && !nodes[i].Text.StartsWith(Tools.FolderIcon)) { continue; }
                    nodes.Remove(nodes[i]);
                }
        }

        private void removeAllpresetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllFoldersOrPresets();
        }

        private void PresetNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SaveAsPreset();
            }
        }

        static bool FileExists(string fName, out string fPath)
        {
            fPath = Tools.GetPathWithAppDomain(fName);
            return File.Exists(fPath);
        }

        string filePath;
        private void LaunchFile(string fileName)
        {
            if (FileExists(fileName, out filePath))
            {
                string param = null;
                bool shellEx = true;
                if (optUseNotepad)
                {
                    param = filePath;
                    filePath = notepadPath;
                    shellEx = false;
                }
                try
                {
                    { using Process p = Process.Start(new ProcessStartInfo(filePath, param) { UseShellExecute = shellEx })!; }

                }
                catch //(Exception ex)
                {
                    //Debug.WriteLine($"***{ex}");
                    Tools.ShowTaskDlg(this, MyTitle, "File not found or not executable", filePath, "Check 'Custom Text Editor Path' on the" +
                        "\nAdvanced tab of the Settings dialog.", null, -1, TaskDialogIcon.Error);
                    ShowSettingsWindow(true, 1);
                }
            }
            else
            {
                Tools.TimedMessage($"Cannot find file '{filePath}'", "Missing File", this, MessageBoxIcon.Warning);
            }
        }

        // New menu items under Tools -> Configuration Files
        // Steve - 01/19/2025 19:33:16

        private void autoexeccfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchFile(autoexec);
        }

        private void eduke32cfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchFile(edcfg);
        }

        private void settingscfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchFile(setcfg);
        }

        private void eduke32logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchFile(edlog);
        }

        private void ListBoxFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                RemoveAFile();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ShowListBoxFilePath();
            }
        }

        private void ListBoxFiles_DoubleClick(object sender, EventArgs e)
        {
            ShowListBoxFilePath();
        }

        private void ShowListBoxFilePath()
        {
            if (ListBoxFiles.SelectedIndex > -1)
                Tools.TimedMessage(ListFiles.Files[ListBoxFiles.SelectedIndex].FilePath,
                    MyTitle, this, MessageBoxIcon.Information);
        }

        private static string CopyDatFiles(string Src, string Dst)
        {
            try
            {
                DirectoryInfo diSrc = new(Src);
                FileInfo[] files = diSrc.GetFiles($"*{Tools.dExt}");
                if (files.Length == Tools.datFileCount)
                {
                    int c = 0;
                    foreach (FileInfo file in files)
                    {
                        //Debug.WriteLine($@"***Copying {file.FullName} to {Dst}\{file.Name}");
                        file.CopyTo($@"{Dst}\{file.Name}", true);
                        c++;
                    }
                    if (c != Tools.datFileCount)
                    {
                        return $"Not all files were copied to {Tools.GetRelativePath(Dst)}";
                    }
                    else { return String.Empty; }
                }
                else { return $"Missing {Tools.dExt} files in '{Tools.GetRelativePath(Src)}'"; }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private bool IsLauncherDataPath(string pth, bool Warn = true)
        {
            if (String.Equals(Path.GetFullPath(pth), Tools.GetPathWithAppDomain(Tools.ldFolder),
                StringComparison.OrdinalIgnoreCase))
            {
                if (Warn)
                {
                    Tools.ShowTaskDlg(this, MyTitle, $"Cannot save to working\nfolder '{Tools.ldFolder}'",
                "Please choose another folder", $"{Tools.ldFolder} is used by {MyTitle} to store the\ndata files" +
                " and should not be altered by the user.", null, -1, TaskDialogIcon.Error);
                }
                return true;
            }
            else return false;
        }

        // Menu item File -> Save Presets
        // Steve - 01/19/2025 11:58:32
        private void savePresetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string savePath = Tools.GetPathWithAppDomain(Tools.SavedPresetsDir);
            //Debug.WriteLine($"***Save Presets starting in '{savePath}'");
            DialogResult ans;
            if (optSaveUseBrowser)
            {
                // Use SaveFileDialog to save Presets
                // Steve - 01/25/2025 23:01:52
                string ext = Tools.dExt;
                using SaveFileDialog saveFileDialog = new()
                {
                    Filter = $"{ext[1..]} files (*{ext})|*{ext}",
                    RestoreDirectory = true,
                    InitialDirectory = savePath,
                    FileName = Tools.dPre,
                    OverwritePrompt = optConfirmOverWrite,
                    Title = "Save Presets"
                };
                ans = saveFileDialog.ShowDialog(this);
                if (ans != DialogResult.OK) return;
                savePath = Path.GetDirectoryName(saveFileDialog.FileName);
                //Debug.WriteLine($"***savePath='{savePath}'");
                // Check if savePath is LauncherData folder
                if (IsLauncherDataPath(savePath)) return;
            }
            else
            {
                // Use InputDialog to save Presets
                // Steve - 01/25/2025 23:02:34
                using InputDialog inputDialog = new();
                ans = inputDialog.ShowDialog(out string Val);
                if (ans != DialogResult.OK) { return; }
                savePath = $@"{savePath}\{Val}";
                // Check if savePath is LauncherData folder
                if (IsLauncherDataPath(savePath)) return;
                try
                {
                    if (!Directory.Exists(savePath)) { Directory.CreateDirectory(savePath); }
                    DirectoryInfo directory = new(savePath);
                    FileInfo[] fi = directory.GetFiles($"*{Tools.dExt}");
                    if (fi.Length > 0)
                    {
                        if (Val == "") { Val = Tools.SavedPresetsDir; }
                        if (optConfirmOverWrite &&
                            Tools.ShowTaskDlg(this, MyTitle, "Overwrite Files?",
                            $"Do you want to overwrite the existing Presets in '{Val}'?",
                            "Cancel this action and choose a different folder\nto preserve the existing saved Presets",
                            [TaskDialogButton.OK, TaskDialogButton.Cancel], 1,
                            TaskDialogIcon.Warning) != TaskDialogButton.OK) { return; }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"File Error: {ex}", MyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Debug.WriteLine($"***File Error", ex);
                    return;
                }
            }
            // Copy files from LauncherData to folder
            string result = CopyDatFiles(Tools.GetPathWithAppDomain(Tools.ldFolder), savePath);
            if (result != String.Empty)
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(result, $"{MyTitle} - Error Saving Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lbLoadSavePath.Text = $"Last save: {Tools.GetRelativePath(savePath)}";
            }
        }

        // Menu item File -> Load Presets
        // Steve - 01/20/2025 08:08:40
        private void loadPresetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog folderBrowser = new()
            {
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Folder Selection",
                InitialDirectory = Tools.GetPathWithAppDomain(Tools.SavedPresetsDir),
                Title = "Load Presets"
            };

            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                string src = Path.GetDirectoryName(folderBrowser.FileName);
                // If src is LauncherData folder, don't attempt to load (suppress warning)
                if (IsLauncherDataPath(src, false)) return;

                // copy presets to LauncherData folder
                string result = CopyDatFiles(src, Tools.GetPathWithAppDomain(Tools.ldFolder));
                if (result != String.Empty)
                { MessageBox.Show(result, $"{MyTitle} - Error Loading Files", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    LoadSettings();
                    lbLoadSavePath.Text = $"Last load: {Tools.GetRelativePath(src)}";
                    ResetAll();
                }
            }
        }

        // Sort entire TreeView alphanumerically
        // Steve - 01/24/2025 22:37:47
        private void entireTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresetTree.Sort();
            PresetTree.SelectedNode = PresetTree.TopNode;
            PresetTree.Sorted = false;
        }

        // Sort selected Node alphanumerically
        // Steve - 02/17/2025 12:10:25
        private void selectedNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresetTree.SelectedNode.Sort();
            PresetTree.SelectedNode = PresetTree.TopNode;
            PresetTree.Sorted = false;
        }

        // Sort selected Node and child nodes alphanumerically
        // Steve - 02/17/2025 17:59:08
        private void selectedFolderSubfoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            static void ReverseTraverse(TreeNodeCollection nodes, ref List<TreeNode> nodeList)
            {
                if (nodes is null) return;
                foreach (TreeNode child in nodes)
                {
                    //if (child is not null)
                    ReverseTraverse(child.Nodes, ref nodeList);

                    //if ((child is not null) && (child.Text.StartsWith(Tools.FolderIcon)))
                    if (child.Text.StartsWith(Tools.FolderIcon))
                        nodeList.Add(child);
                }
            }
            List<TreeNode> nodeList = [];
            TreeNodeCollection Nodes = PresetTree.SelectedNode.Nodes;
            SaveLastSelectedNode();
            ReverseTraverse(Nodes, ref nodeList);
            for (int n = nodeList.Count - 1; n >= 0; n--)
                nodeList[n].Sort();

            RecoverLastSelectedNode(); // Sorting zaps the selected node
            PresetTree.SelectedNode.Sort();
            RecoverLastSelectedNode(); // ditto
            PresetTree.Sorted = false;
            PresetsManager.Save();
        }

        // Restore default Presets and associated files
        //      This does NOT alter the Settings file
        // Steve - 01/30/2025 19:11:35
        private void reloadOriginalPresetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskDialogButtonCollection tdbc = [TaskDialogButton.OK, TaskDialogButton.Cancel];
            if (Tools.ShowTaskDlg(this, MyTitle, "Reload Original Presets", "This will replace all Presets" +
                " in the tree with the defaults", "If you want to keep the current Presets, save a copy" +
                "\nfirst with File -> Save Presets", tdbc, 1) == TaskDialogButton.OK)
            {
                PresetsManager.CreateFiles(true);
                ResetAll();
            }
        }

        private void TreeExpand()
        {
            if (TreeExpanded)
            {
                ExpandButton.Text = "Expand";
                PresetTree.CollapseAll();
                PresetTree.SelectedNode = PresetTree.TopNode;
                SaveLastSelectedNode();
            }
            else
            {
                ExpandButton.Text = "Collapse";
                PresetTree.ExpandAll();
                RecoverLastSelectedNode();
            }
            TreeExpanded ^= true;
            PresetTree.Focus();
        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            TreeExpand();
        }

        private void ListBoxFiles_Enter(object sender, EventArgs e)
        {
            if (ListBoxFiles.Items.Count > 0) { ListBoxFiles.SelectedIndex = 0; }
        }

        private void importMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ImportMapsWindow importMapsWindow = new(PresetTree, PreventFolderCollisions, PreventPresetCollisions) { KeyPreview = true };
            importMapsWindow.ShowDialog(this);
            UpdateStatusStrip();
            PresetTree.Focus();
        }

        private void PresetTree_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                using (new CenterWinDialog(this))
                    MessageBox.Show("Use left mouse button to drag plus:\n\n" +
                    "Key\t\tAction\n----------------------------------------------\n" +
                    "None\t\tMove\nCtrl\t\tCopy\nShift\t\tMove all children\nShift+Ctrl\tCopy all children\n" +
                    "Alt\t\tMove Preset only\nAlt+Ctrl\t\tCopy Preset only", "PresetTree Drag Drop Help");
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using Finder finder = new(PresetTree) { KeyPreview = true };
            finder.ShowDialog(this);
        }
    }
}
