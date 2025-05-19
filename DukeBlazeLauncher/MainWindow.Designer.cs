using System;
using System.Drawing;

namespace DukeBlazeLauncher
{
    partial class MainWindow
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TreeNode treeNode1 = new TreeNode("📁 Expansions", 10, 10);
            TreeNode treeNode2 = new TreeNode("📁 Episodes");
            TreeNode treeNode3 = new TreeNode("📁 Maps");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            groupBox1 = new GroupBox();
            ExpandButton = new Button();
            PresetTree = new MyTreeView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            NewPresetFolderButton = new Button();
            EditFolderButton = new Button();
            RemovePresetFolderButton = new Button();
            DownPresetButton = new Button();
            UpPresetButton = new Button();
            EmptyButton = new Button();
            LaunchOptionsGroup = new GroupBox();
            BrowseButton = new Button();
            label8 = new Label();
            AdditionalSettingsPanel = new FlowLayoutPanel();
            label3 = new Label();
            GameDirTextBox = new TextBox();
            GameDirBrowseButton = new Button();
            label4 = new Label();
            CfgPathTextBox = new TextBox();
            CfgPathBrowseButton = new Button();
            label6 = new Label();
            SkillLevelComboBox = new ComboBox();
            label5 = new Label();
            AddonComboBox = new ComboBox();
            label7 = new Label();
            RespawnModeComboBox = new ComboBox();
            DisableStartupWindowCheckbox = new CheckBox();
            DisableMonstersCheckbox = new CheckBox();
            SkipLogoCheckBox = new CheckBox();
            DisableInstanceCheckbox = new CheckBox();
            label10 = new Label();
            CustomExeTextBox = new TextBox();
            CustomExeButton = new Button();
            ButtonRemoveFile = new Button();
            MoveDownButton = new Button();
            MoveUpButton = new Button();
            GroupAdditionalParams = new GroupBox();
            ReplaceMainCheckbox = new CheckBox();
            ListBoxFiles = new ListBox();
            label1 = new Label();
            RunButton = new Button();
            ArgsGroup = new GroupBox();
            lbLoadSavePath = new Label();
            DescriptionButton = new Button();
            PresetNameTextBox = new TextBox();
            label9 = new Label();
            SaveAsPresetButton = new Button();
            ArgsHelpButton = new Label();
            label2 = new Label();
            AdditionalCommandsTextBox = new RichTextBox();
            toolTip1 = new ToolTip(components);
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadPresetsToolStripMenuItem = new ToolStripMenuItem();
            savePresetsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            findToolStripMenuItem = new ToolStripMenuItem();
            removeAllpresetsToolStripMenuItem = new ToolStripMenuItem();
            sortToolStripMenuItem = new ToolStripMenuItem();
            entireTreeToolStripMenuItem = new ToolStripMenuItem();
            selectedNodeToolStripMenuItem = new ToolStripMenuItem();
            selectedFolderSubfoldersToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            cfgFilesToolStripMenuItem = new ToolStripMenuItem();
            autoexeccfgToolStripMenuItem = new ToolStripMenuItem();
            eduke32cfgToolStripMenuItem = new ToolStripMenuItem();
            settingscfgToolStripMenuItem = new ToolStripMenuItem();
            eduke32logToolStripMenuItem = new ToolStripMenuItem();
            reloadOriginalPresetsToolStripMenuItem = new ToolStripMenuItem();
            importMapsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            StatusStrip = new StatusStrip();
            TreeStatusLabel = new ToolStripStatusLabel();
            CollisionsStatusLabel = new ToolStripStatusLabel();
            ExePathStatusLabel = new SpringLabel();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            LaunchOptionsGroup.SuspendLayout();
            AdditionalSettingsPanel.SuspendLayout();
            GroupAdditionalParams.SuspendLayout();
            ArgsGroup.SuspendLayout();
            menuStrip1.SuspendLayout();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ExpandButton);
            groupBox1.Controls.Add(PresetTree);
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Controls.Add(EmptyButton);
            groupBox1.Location = new Point(6, 46);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(307, 678);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Presets";
            // 
            // ExpandButton
            // 
            ExpandButton.Location = new Point(8, 22);
            ExpandButton.Margin = new Padding(4, 3, 4, 3);
            ExpandButton.Name = "ExpandButton";
            ExpandButton.Size = new Size(140, 32);
            ExpandButton.TabIndex = 0;
            ExpandButton.Text = "Expand";
            ExpandButton.UseVisualStyleBackColor = true;
            ExpandButton.Click += ExpandButton_Click;
            // 
            // PresetTree
            // 
            PresetTree.Font = new Font("Microsoft Sans Serif", 10F);
            PresetTree.Location = new Point(9, 61);
            PresetTree.Margin = new Padding(4, 3, 4, 3);
            PresetTree.Name = "PresetTree";
            treeNode1.ImageIndex = 10;
            treeNode1.Name = "Expansions";
            treeNode1.SelectedImageIndex = 10;
            treeNode1.Tag = "0";
            treeNode1.Text = "📁 Expansions";
            treeNode2.Name = "Episodes";
            treeNode2.Tag = "1";
            treeNode2.Text = "📁 Episodes";
            treeNode3.Name = "Maps";
            treeNode3.Tag = "2";
            treeNode3.Text = "📁 Maps";
            PresetTree.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            PresetTree.Size = new Size(290, 546);
            PresetTree.TabIndex = 2;
            toolTip1.SetToolTip(PresetTree, "Navigate with mouse or arrow keys\r\nDouble-click or Enter key to open Description\r\nRight-click item for Drag Drop help");
            PresetTree.DoubleClick += PresetTree_DoubleClick;
            PresetTree.Enter += PresetTree_Enter;
            PresetTree.KeyDown += PresetTree_KeyDown;
            PresetTree.MouseClick += PresetTree_MouseClick;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(NewPresetFolderButton);
            flowLayoutPanel1.Controls.Add(EditFolderButton);
            flowLayoutPanel1.Controls.Add(RemovePresetFolderButton);
            flowLayoutPanel1.Controls.Add(DownPresetButton);
            flowLayoutPanel1.Controls.Add(UpPresetButton);
            flowLayoutPanel1.Location = new Point(9, 615);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(290, 58);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // NewPresetFolderButton
            // 
            NewPresetFolderButton.Image = (Image)resources.GetObject("NewPresetFolderButton.Image");
            NewPresetFolderButton.Location = new Point(4, 3);
            NewPresetFolderButton.Margin = new Padding(4, 3, 4, 3);
            NewPresetFolderButton.Name = "NewPresetFolderButton";
            NewPresetFolderButton.Size = new Size(50, 47);
            NewPresetFolderButton.TabIndex = 0;
            toolTip1.SetToolTip(NewPresetFolderButton, "Add new folder");
            NewPresetFolderButton.UseVisualStyleBackColor = true;
            NewPresetFolderButton.Click += NewPresetFolderBtn_Click;
            // 
            // EditFolderButton
            // 
            EditFolderButton.Image = (Image)resources.GetObject("EditFolderButton.Image");
            EditFolderButton.Location = new Point(62, 3);
            EditFolderButton.Margin = new Padding(4, 3, 4, 3);
            EditFolderButton.Name = "EditFolderButton";
            EditFolderButton.Size = new Size(50, 47);
            EditFolderButton.TabIndex = 1;
            toolTip1.SetToolTip(EditFolderButton, "Edit current folder");
            EditFolderButton.UseVisualStyleBackColor = true;
            EditFolderButton.Click += EditFolderButton_Click;
            // 
            // RemovePresetFolderButton
            // 
            RemovePresetFolderButton.Image = (Image)resources.GetObject("RemovePresetFolderButton.Image");
            RemovePresetFolderButton.Location = new Point(120, 3);
            RemovePresetFolderButton.Margin = new Padding(4, 3, 4, 3);
            RemovePresetFolderButton.Name = "RemovePresetFolderButton";
            RemovePresetFolderButton.Size = new Size(50, 47);
            RemovePresetFolderButton.TabIndex = 2;
            toolTip1.SetToolTip(RemovePresetFolderButton, "Remove item");
            RemovePresetFolderButton.UseVisualStyleBackColor = true;
            RemovePresetFolderButton.Click += RemovePresetFolderButton_Click;
            // 
            // DownPresetButton
            // 
            DownPresetButton.Image = (Image)resources.GetObject("DownPresetButton.Image");
            DownPresetButton.Location = new Point(178, 3);
            DownPresetButton.Margin = new Padding(4, 3, 4, 3);
            DownPresetButton.Name = "DownPresetButton";
            DownPresetButton.Size = new Size(50, 47);
            DownPresetButton.TabIndex = 3;
            toolTip1.SetToolTip(DownPresetButton, "Move item down");
            DownPresetButton.UseVisualStyleBackColor = true;
            DownPresetButton.Click += DownPresetButton_Click;
            // 
            // UpPresetButton
            // 
            UpPresetButton.Image = (Image)resources.GetObject("UpPresetButton.Image");
            UpPresetButton.Location = new Point(236, 3);
            UpPresetButton.Margin = new Padding(4, 3, 4, 3);
            UpPresetButton.Name = "UpPresetButton";
            UpPresetButton.Size = new Size(50, 47);
            UpPresetButton.TabIndex = 4;
            toolTip1.SetToolTip(UpPresetButton, "Move item up");
            UpPresetButton.UseVisualStyleBackColor = true;
            UpPresetButton.Click += UpPresetButton_Click;
            // 
            // EmptyButton
            // 
            EmptyButton.Location = new Point(160, 22);
            EmptyButton.Margin = new Padding(4, 3, 4, 3);
            EmptyButton.Name = "EmptyButton";
            EmptyButton.Size = new Size(140, 32);
            EmptyButton.TabIndex = 1;
            EmptyButton.Text = "Empt&y";
            toolTip1.SetToolTip(EmptyButton, "Empty files list and launch options");
            EmptyButton.UseVisualStyleBackColor = true;
            EmptyButton.Click += EmptyButton_Click;
            // 
            // LaunchOptionsGroup
            // 
            LaunchOptionsGroup.Controls.Add(BrowseButton);
            LaunchOptionsGroup.Controls.Add(label8);
            LaunchOptionsGroup.Controls.Add(AdditionalSettingsPanel);
            LaunchOptionsGroup.Controls.Add(ButtonRemoveFile);
            LaunchOptionsGroup.Controls.Add(MoveDownButton);
            LaunchOptionsGroup.Controls.Add(MoveUpButton);
            LaunchOptionsGroup.Controls.Add(GroupAdditionalParams);
            LaunchOptionsGroup.Controls.Add(ListBoxFiles);
            LaunchOptionsGroup.Controls.Add(label1);
            LaunchOptionsGroup.FlatStyle = FlatStyle.Flat;
            LaunchOptionsGroup.Location = new Point(330, 46);
            LaunchOptionsGroup.Margin = new Padding(4, 3, 4, 3);
            LaunchOptionsGroup.Name = "LaunchOptionsGroup";
            LaunchOptionsGroup.Padding = new Padding(4, 3, 4, 3);
            LaunchOptionsGroup.Size = new Size(799, 471);
            LaunchOptionsGroup.TabIndex = 2;
            LaunchOptionsGroup.TabStop = false;
            // 
            // BrowseButton
            // 
            BrowseButton.Font = new Font("Microsoft Sans Serif", 15.25F);
            BrowseButton.Location = new Point(308, 160);
            BrowseButton.Margin = new Padding(4, 3, 4, 3);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(27, 39);
            BrowseButton.TabIndex = 6;
            BrowseButton.Text = "⁝";
            toolTip1.SetToolTip(BrowseButton, "Open file browser");
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(340, 0);
            label8.Margin = new Padding(9, 12, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(124, 15);
            label8.TabIndex = 7;
            label8.Text = "Additional Parameters";
            // 
            // AdditionalSettingsPanel
            // 
            AdditionalSettingsPanel.AutoScroll = true;
            AdditionalSettingsPanel.Controls.Add(label3);
            AdditionalSettingsPanel.Controls.Add(GameDirTextBox);
            AdditionalSettingsPanel.Controls.Add(GameDirBrowseButton);
            AdditionalSettingsPanel.Controls.Add(label4);
            AdditionalSettingsPanel.Controls.Add(CfgPathTextBox);
            AdditionalSettingsPanel.Controls.Add(CfgPathBrowseButton);
            AdditionalSettingsPanel.Controls.Add(label6);
            AdditionalSettingsPanel.Controls.Add(SkillLevelComboBox);
            AdditionalSettingsPanel.Controls.Add(label5);
            AdditionalSettingsPanel.Controls.Add(AddonComboBox);
            AdditionalSettingsPanel.Controls.Add(label7);
            AdditionalSettingsPanel.Controls.Add(RespawnModeComboBox);
            AdditionalSettingsPanel.Controls.Add(DisableStartupWindowCheckbox);
            AdditionalSettingsPanel.Controls.Add(DisableMonstersCheckbox);
            AdditionalSettingsPanel.Controls.Add(SkipLogoCheckBox);
            AdditionalSettingsPanel.Controls.Add(DisableInstanceCheckbox);
            AdditionalSettingsPanel.Controls.Add(label10);
            AdditionalSettingsPanel.Controls.Add(CustomExeTextBox);
            AdditionalSettingsPanel.Controls.Add(CustomExeButton);
            AdditionalSettingsPanel.FlowDirection = FlowDirection.TopDown;
            AdditionalSettingsPanel.Location = new Point(343, 22);
            AdditionalSettingsPanel.Margin = new Padding(4, 3, 4, 3);
            AdditionalSettingsPanel.Name = "AdditionalSettingsPanel";
            AdditionalSettingsPanel.Size = new Size(442, 442);
            AdditionalSettingsPanel.TabIndex = 8;
            AdditionalSettingsPanel.WrapContents = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 12);
            label3.Margin = new Padding(9, 12, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(154, 15);
            label3.TabIndex = 0;
            label3.Text = "&Game Directory (-game_dir)";
            // 
            // GameDirTextBox
            // 
            GameDirTextBox.Location = new Point(12, 30);
            GameDirTextBox.Margin = new Padding(12, 3, 4, 3);
            GameDirTextBox.Name = "GameDirTextBox";
            GameDirTextBox.Size = new Size(398, 23);
            GameDirTextBox.TabIndex = 1;
            toolTip1.SetToolTip(GameDirTextBox, "Select game directory");
            // 
            // GameDirBrowseButton
            // 
            GameDirBrowseButton.Location = new Point(10, 56);
            GameDirBrowseButton.Margin = new Padding(10, 0, 4, 3);
            GameDirBrowseButton.Name = "GameDirBrowseButton";
            GameDirBrowseButton.Size = new Size(88, 27);
            GameDirBrowseButton.TabIndex = 2;
            GameDirBrowseButton.Text = "Browse";
            GameDirBrowseButton.UseVisualStyleBackColor = true;
            GameDirBrowseButton.Click += GameDirBrowseButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 98);
            label4.Margin = new Padding(9, 12, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(195, 15);
            label4.TabIndex = 3;
            label4.Text = "&Alternative Configuration File (-cfg)";
            // 
            // CfgPathTextBox
            // 
            CfgPathTextBox.Location = new Point(12, 116);
            CfgPathTextBox.Margin = new Padding(12, 3, 4, 3);
            CfgPathTextBox.Name = "CfgPathTextBox";
            CfgPathTextBox.Size = new Size(398, 23);
            CfgPathTextBox.TabIndex = 4;
            toolTip1.SetToolTip(CfgPathTextBox, "Select alternative cfg file");
            // 
            // CfgPathBrowseButton
            // 
            CfgPathBrowseButton.Location = new Point(10, 142);
            CfgPathBrowseButton.Margin = new Padding(10, 0, 4, 3);
            CfgPathBrowseButton.Name = "CfgPathBrowseButton";
            CfgPathBrowseButton.Size = new Size(88, 27);
            CfgPathBrowseButton.TabIndex = 5;
            CfgPathBrowseButton.Text = "Browse";
            CfgPathBrowseButton.UseVisualStyleBackColor = true;
            CfgPathBrowseButton.Click += CfgPathBrowseButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 184);
            label6.Margin = new Padding(9, 12, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 6;
            label6.Text = "Skill Le&vel";
            // 
            // SkillLevelComboBox
            // 
            SkillLevelComboBox.FormattingEnabled = true;
            SkillLevelComboBox.Items.AddRange(new object[] { "0 - Piece of Cake", "1 - Let's Rock", "2 - Come Get Some", "3 - Damn I'm Good", "4 - Respawn Monsters" });
            SkillLevelComboBox.Location = new Point(12, 202);
            SkillLevelComboBox.Margin = new Padding(12, 3, 4, 3);
            SkillLevelComboBox.Name = "SkillLevelComboBox";
            SkillLevelComboBox.Size = new Size(398, 23);
            SkillLevelComboBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 240);
            label5.Margin = new Padding(9, 12, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 8;
            label5.Text = "Addo&n (-addon)";
            // 
            // AddonComboBox
            // 
            AddonComboBox.FormattingEnabled = true;
            AddonComboBox.Items.AddRange(new object[] { "0 - none", "1 - Duke it out in D.C.", "2 - Duke: Nuclear Winter", "3 - Duke Caribbean: Life's a Beach" });
            AddonComboBox.Location = new Point(12, 258);
            AddonComboBox.Margin = new Padding(12, 3, 4, 3);
            AddonComboBox.Name = "AddonComboBox";
            AddonComboBox.Size = new Size(398, 23);
            AddonComboBox.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 296);
            label7.Margin = new Padding(9, 12, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(88, 15);
            label7.TabIndex = 10;
            label7.Text = "Res&pawn Mode";
            // 
            // RespawnModeComboBox
            // 
            RespawnModeComboBox.FormattingEnabled = true;
            RespawnModeComboBox.Items.AddRange(new object[] { "0 - none", "1 - Monsters", "2 - Items", "3 - Inventory", "x - All" });
            RespawnModeComboBox.Location = new Point(12, 314);
            RespawnModeComboBox.Margin = new Padding(12, 3, 4, 3);
            RespawnModeComboBox.Name = "RespawnModeComboBox";
            RespawnModeComboBox.Size = new Size(398, 23);
            RespawnModeComboBox.TabIndex = 11;
            // 
            // DisableStartupWindowCheckbox
            // 
            DisableStartupWindowCheckbox.AutoSize = true;
            DisableStartupWindowCheckbox.Checked = true;
            DisableStartupWindowCheckbox.CheckState = CheckState.Checked;
            DisableStartupWindowCheckbox.Location = new Point(12, 363);
            DisableStartupWindowCheckbox.Margin = new Padding(12, 23, 4, 3);
            DisableStartupWindowCheckbox.Name = "DisableStartupWindowCheckbox";
            DisableStartupWindowCheckbox.Size = new Size(208, 19);
            DisableStartupWindowCheckbox.TabIndex = 12;
            DisableStartupWindowCheckbox.Text = "Disable startup &window (-nosetup)";
            DisableStartupWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableMonstersCheckbox
            // 
            DisableMonstersCheckbox.AutoSize = true;
            DisableMonstersCheckbox.Location = new Point(12, 388);
            DisableMonstersCheckbox.Margin = new Padding(12, 3, 4, 3);
            DisableMonstersCheckbox.Name = "DisableMonstersCheckbox";
            DisableMonstersCheckbox.Size = new Size(143, 19);
            DisableMonstersCheckbox.TabIndex = 13;
            DisableMonstersCheckbox.Text = "Disable &monsters (-m)";
            DisableMonstersCheckbox.UseVisualStyleBackColor = true;
            // 
            // SkipLogoCheckBox
            // 
            SkipLogoCheckBox.AutoSize = true;
            SkipLogoCheckBox.Checked = true;
            SkipLogoCheckBox.CheckState = CheckState.Checked;
            SkipLogoCheckBox.Location = new Point(12, 413);
            SkipLogoCheckBox.Margin = new Padding(12, 3, 4, 3);
            SkipLogoCheckBox.Name = "SkipLogoCheckBox";
            SkipLogoCheckBox.Size = new Size(331, 19);
            SkipLogoCheckBox.TabIndex = 14;
            SkipLogoCheckBox.Text = "S&kip all the startup animations and logos (-nologo,-quick)";
            SkipLogoCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableInstanceCheckbox
            // 
            DisableInstanceCheckbox.AutoSize = true;
            DisableInstanceCheckbox.Checked = true;
            DisableInstanceCheckbox.CheckState = CheckState.Checked;
            DisableInstanceCheckbox.Location = new Point(12, 438);
            DisableInstanceCheckbox.Margin = new Padding(12, 3, 4, 3);
            DisableInstanceCheckbox.Name = "DisableInstanceCheckbox";
            DisableInstanceCheckbox.Size = new Size(314, 19);
            DisableInstanceCheckbox.TabIndex = 18;
            DisableInstanceCheckbox.Text = "Disable eduke32 instance check (-noinstancechecking)";
            toolTip1.SetToolTip(DisableInstanceCheckbox, "Prevents eduke32 from checking whether another instance is already running");
            DisableInstanceCheckbox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 477);
            label10.Margin = new Padding(10, 17, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(117, 15);
            label10.TabIndex = 15;
            label10.Text = "Custom eD&uke32 exe";
            // 
            // CustomExeTextBox
            // 
            CustomExeTextBox.Location = new Point(12, 495);
            CustomExeTextBox.Margin = new Padding(12, 3, 4, 3);
            CustomExeTextBox.Name = "CustomExeTextBox";
            CustomExeTextBox.Size = new Size(398, 23);
            CustomExeTextBox.TabIndex = 16;
            toolTip1.SetToolTip(CustomExeTextBox, "Run the mod for another Duke3D.exe file");
            // 
            // CustomExeButton
            // 
            CustomExeButton.Location = new Point(10, 521);
            CustomExeButton.Margin = new Padding(10, 0, 4, 3);
            CustomExeButton.Name = "CustomExeButton";
            CustomExeButton.Size = new Size(88, 27);
            CustomExeButton.TabIndex = 17;
            CustomExeButton.Text = "Browse";
            CustomExeButton.UseVisualStyleBackColor = true;
            CustomExeButton.Click += CustomExeButton_Click;
            // 
            // ButtonRemoveFile
            // 
            ButtonRemoveFile.Font = new Font("Microsoft Sans Serif", 15.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonRemoveFile.Location = new Point(308, 114);
            ButtonRemoveFile.Margin = new Padding(4, 3, 4, 3);
            ButtonRemoveFile.Name = "ButtonRemoveFile";
            ButtonRemoveFile.Size = new Size(27, 39);
            ButtonRemoveFile.TabIndex = 5;
            ButtonRemoveFile.Text = "x";
            toolTip1.SetToolTip(ButtonRemoveFile, "Remove item");
            ButtonRemoveFile.UseVisualStyleBackColor = true;
            ButtonRemoveFile.Click += ButtonRemoveFile_Click;
            // 
            // MoveDownButton
            // 
            MoveDownButton.Font = new Font("Microsoft Sans Serif", 15.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MoveDownButton.Location = new Point(308, 68);
            MoveDownButton.Margin = new Padding(4, 3, 4, 3);
            MoveDownButton.Name = "MoveDownButton";
            MoveDownButton.Size = new Size(27, 39);
            MoveDownButton.TabIndex = 4;
            MoveDownButton.Text = "⬇";
            toolTip1.SetToolTip(MoveDownButton, "Move item down");
            MoveDownButton.UseVisualStyleBackColor = true;
            MoveDownButton.Click += MoveDownButton_Click;
            // 
            // MoveUpButton
            // 
            MoveUpButton.Font = new Font("Microsoft Sans Serif", 15.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MoveUpButton.Location = new Point(308, 22);
            MoveUpButton.Margin = new Padding(4, 3, 4, 3);
            MoveUpButton.Name = "MoveUpButton";
            MoveUpButton.Size = new Size(27, 39);
            MoveUpButton.TabIndex = 3;
            MoveUpButton.Text = "⬆";
            toolTip1.SetToolTip(MoveUpButton, "Move item up");
            MoveUpButton.UseVisualStyleBackColor = true;
            MoveUpButton.Click += MoveUpButton_Click;
            // 
            // GroupAdditionalParams
            // 
            GroupAdditionalParams.Controls.Add(ReplaceMainCheckbox);
            GroupAdditionalParams.Location = new Point(10, 310);
            GroupAdditionalParams.Margin = new Padding(4, 3, 4, 3);
            GroupAdditionalParams.Name = "GroupAdditionalParams";
            GroupAdditionalParams.Padding = new Padding(4, 3, 4, 3);
            GroupAdditionalParams.Size = new Size(290, 153);
            GroupAdditionalParams.TabIndex = 2;
            GroupAdditionalParams.TabStop = false;
            GroupAdditionalParams.Text = "DEFINITION.DEF";
            // 
            // ReplaceMainCheckbox
            // 
            ReplaceMainCheckbox.AutoSize = true;
            ReplaceMainCheckbox.Location = new Point(8, 23);
            ReplaceMainCheckbox.Margin = new Padding(4, 3, 4, 3);
            ReplaceMainCheckbox.Name = "ReplaceMainCheckbox";
            ReplaceMainCheckbox.Size = new Size(97, 19);
            ReplaceMainCheckbox.TabIndex = 0;
            ReplaceMainCheckbox.Text = "Replace Ma&in";
            toolTip1.SetToolTip(ReplaceMainCheckbox, "Make grp/con/def file as main");
            ReplaceMainCheckbox.UseVisualStyleBackColor = true;
            ReplaceMainCheckbox.CheckedChanged += ReplaceMainCheckbox_CheckedChanged;
            // 
            // ListBoxFiles
            // 
            ListBoxFiles.Font = new Font("Microsoft Sans Serif", 10F);
            ListBoxFiles.FormattingEnabled = true;
            ListBoxFiles.Location = new Point(10, 22);
            ListBoxFiles.Margin = new Padding(4, 3, 4, 3);
            ListBoxFiles.Name = "ListBoxFiles";
            ListBoxFiles.Size = new Size(290, 276);
            ListBoxFiles.TabIndex = 1;
            toolTip1.SetToolTip(ListBoxFiles, "Drag and drop files here to add");
            ListBoxFiles.DoubleClick += ListBoxFiles_DoubleClick;
            ListBoxFiles.Enter += ListBoxFiles_Enter;
            ListBoxFiles.KeyDown += ListBoxFiles_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 0);
            label1.Margin = new Padding(9, 12, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Fi&les";
            // 
            // RunButton
            // 
            RunButton.Location = new Point(660, 104);
            RunButton.Margin = new Padding(4, 3, 4, 3);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(125, 39);
            RunButton.TabIndex = 7;
            RunButton.Text = "&RUN ▶";
            toolTip1.SetToolTip(RunButton, "Run selected preset");
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // ArgsGroup
            // 
            ArgsGroup.Controls.Add(lbLoadSavePath);
            ArgsGroup.Controls.Add(DescriptionButton);
            ArgsGroup.Controls.Add(PresetNameTextBox);
            ArgsGroup.Controls.Add(label9);
            ArgsGroup.Controls.Add(SaveAsPresetButton);
            ArgsGroup.Controls.Add(ArgsHelpButton);
            ArgsGroup.Controls.Add(label2);
            ArgsGroup.Controls.Add(AdditionalCommandsTextBox);
            ArgsGroup.Controls.Add(RunButton);
            ArgsGroup.Location = new Point(330, 524);
            ArgsGroup.Margin = new Padding(4, 3, 4, 3);
            ArgsGroup.Name = "ArgsGroup";
            ArgsGroup.Padding = new Padding(4, 3, 4, 3);
            ArgsGroup.Size = new Size(799, 200);
            ArgsGroup.TabIndex = 3;
            ArgsGroup.TabStop = false;
            // 
            // lbLoadSavePath
            // 
            lbLoadSavePath.AutoEllipsis = true;
            lbLoadSavePath.Location = new Point(310, 169);
            lbLoadSavePath.Name = "lbLoadSavePath";
            lbLoadSavePath.Size = new Size(474, 23);
            lbLoadSavePath.TabIndex = 8;
            lbLoadSavePath.Text = "Load/Save Path:";
            lbLoadSavePath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DescriptionButton
            // 
            DescriptionButton.Location = new Point(142, 153);
            DescriptionButton.Margin = new Padding(4, 3, 4, 3);
            DescriptionButton.Name = "DescriptionButton";
            DescriptionButton.Size = new Size(125, 39);
            DescriptionButton.TabIndex = 6;
            DescriptionButton.Text = "&Description";
            toolTip1.SetToolTip(DescriptionButton, "Open description window");
            DescriptionButton.UseVisualStyleBackColor = true;
            DescriptionButton.Click += DescriptionButton_Click;
            // 
            // PresetNameTextBox
            // 
            PresetNameTextBox.Location = new Point(10, 120);
            PresetNameTextBox.Margin = new Padding(4, 3, 4, 3);
            PresetNameTextBox.Name = "PresetNameTextBox";
            PresetNameTextBox.Size = new Size(384, 23);
            PresetNameTextBox.TabIndex = 4;
            toolTip1.SetToolTip(PresetNameTextBox, "Enter name for preset");
            PresetNameTextBox.TextChanged += PresetNameTextBox_TextChanged;
            PresetNameTextBox.KeyDown += PresetNameTextBox_KeyDown;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 100);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(74, 15);
            label9.TabIndex = 3;
            label9.Text = "Preset &Name";
            // 
            // SaveAsPresetButton
            // 
            SaveAsPresetButton.Location = new Point(10, 153);
            SaveAsPresetButton.Margin = new Padding(4, 3, 4, 3);
            SaveAsPresetButton.Name = "SaveAsPresetButton";
            SaveAsPresetButton.Size = new Size(125, 39);
            SaveAsPresetButton.TabIndex = 5;
            SaveAsPresetButton.Text = "&Save Preset";
            toolTip1.SetToolTip(SaveAsPresetButton, "Save current preset");
            SaveAsPresetButton.UseVisualStyleBackColor = true;
            SaveAsPresetButton.Click += SaveAsPresetButton_Click;
            // 
            // ArgsHelpButton
            // 
            ArgsHelpButton.AutoSize = true;
            ArgsHelpButton.Cursor = Cursors.Hand;
            ArgsHelpButton.ForeColor = SystemColors.HotTrack;
            ArgsHelpButton.Location = new Point(212, 17);
            ArgsHelpButton.Margin = new Padding(4, 0, 4, 0);
            ArgsHelpButton.Name = "ArgsHelpButton";
            ArgsHelpButton.Size = new Size(40, 15);
            ArgsHelpButton.TabIndex = 1;
            ArgsHelpButton.Text = "(Help)";
            ArgsHelpButton.Click += ArgsHelpButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 17);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(211, 15);
            label2.TabIndex = 0;
            label2.Text = "Additional &Command-Line Arguments";
            // 
            // AdditionalCommandsTextBox
            // 
            AdditionalCommandsTextBox.Location = new Point(10, 36);
            AdditionalCommandsTextBox.Margin = new Padding(4, 3, 4, 3);
            AdditionalCommandsTextBox.Name = "AdditionalCommandsTextBox";
            AdditionalCommandsTextBox.Size = new Size(774, 50);
            AdditionalCommandsTextBox.TabIndex = 2;
            AdditionalCommandsTextBox.Text = "";
            toolTip1.SetToolTip(AdditionalCommandsTextBox, "Add any additional arguments here\r\nClick the Help link above for more info");
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1143, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadPresetsToolStripMenuItem, savePresetsToolStripMenuItem, settingsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // loadPresetsToolStripMenuItem
            // 
            loadPresetsToolStripMenuItem.Name = "loadPresetsToolStripMenuItem";
            loadPresetsToolStripMenuItem.Size = new Size(140, 22);
            loadPresetsToolStripMenuItem.Text = "&Load Presets";
            loadPresetsToolStripMenuItem.Click += loadPresetsToolStripMenuItem_Click;
            // 
            // savePresetsToolStripMenuItem
            // 
            savePresetsToolStripMenuItem.Name = "savePresetsToolStripMenuItem";
            savePresetsToolStripMenuItem.Size = new Size(140, 22);
            savePresetsToolStripMenuItem.Text = "&Save Presets";
            savePresetsToolStripMenuItem.Click += savePresetsToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(140, 22);
            settingsToolStripMenuItem.Text = "S&ettings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(140, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { findToolStripMenuItem, removeAllpresetsToolStripMenuItem, sortToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // findToolStripMenuItem
            // 
            findToolStripMenuItem.Name = "findToolStripMenuItem";
            findToolStripMenuItem.Size = new Size(165, 22);
            findToolStripMenuItem.Text = "&Find";
            findToolStripMenuItem.Click += findToolStripMenuItem_Click;
            // 
            // removeAllpresetsToolStripMenuItem
            // 
            removeAllpresetsToolStripMenuItem.Name = "removeAllpresetsToolStripMenuItem";
            removeAllpresetsToolStripMenuItem.Size = new Size(165, 22);
            removeAllpresetsToolStripMenuItem.Text = "&Prune Preset Tree";
            removeAllpresetsToolStripMenuItem.Click += removeAllpresetsToolStripMenuItem_Click;
            // 
            // sortToolStripMenuItem
            // 
            sortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { entireTreeToolStripMenuItem, selectedNodeToolStripMenuItem, selectedFolderSubfoldersToolStripMenuItem });
            sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            sortToolStripMenuItem.Size = new Size(165, 22);
            sortToolStripMenuItem.Text = "&Sort";
            // 
            // entireTreeToolStripMenuItem
            // 
            entireTreeToolStripMenuItem.Name = "entireTreeToolStripMenuItem";
            entireTreeToolStripMenuItem.Size = new Size(226, 22);
            entireTreeToolStripMenuItem.Text = "Entire &Tree";
            entireTreeToolStripMenuItem.Click += entireTreeToolStripMenuItem_Click;
            // 
            // selectedNodeToolStripMenuItem
            // 
            selectedNodeToolStripMenuItem.Name = "selectedNodeToolStripMenuItem";
            selectedNodeToolStripMenuItem.Size = new Size(226, 22);
            selectedNodeToolStripMenuItem.Text = "Selected &Folder";
            selectedNodeToolStripMenuItem.Click += selectedNodeToolStripMenuItem_Click;
            // 
            // selectedFolderSubfoldersToolStripMenuItem
            // 
            selectedFolderSubfoldersToolStripMenuItem.Name = "selectedFolderSubfoldersToolStripMenuItem";
            selectedFolderSubfoldersToolStripMenuItem.Size = new Size(226, 22);
            selectedFolderSubfoldersToolStripMenuItem.Text = "Selected Folder && &Subfolders";
            selectedFolderSubfoldersToolStripMenuItem.Click += selectedFolderSubfoldersToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cfgFilesToolStripMenuItem, reloadOriginalPresetsToolStripMenuItem, importMapsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // cfgFilesToolStripMenuItem
            // 
            cfgFilesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { autoexeccfgToolStripMenuItem, eduke32cfgToolStripMenuItem, settingscfgToolStripMenuItem, eduke32logToolStripMenuItem });
            cfgFilesToolStripMenuItem.Name = "cfgFilesToolStripMenuItem";
            cfgFilesToolStripMenuItem.Size = new Size(195, 22);
            cfgFilesToolStripMenuItem.Text = "&Configuration Files";
            // 
            // autoexeccfgToolStripMenuItem
            // 
            autoexeccfgToolStripMenuItem.Name = "autoexeccfgToolStripMenuItem";
            autoexeccfgToolStripMenuItem.Size = new Size(141, 22);
            autoexeccfgToolStripMenuItem.Text = "autoexec.cfg";
            autoexeccfgToolStripMenuItem.Click += autoexeccfgToolStripMenuItem_Click;
            // 
            // eduke32cfgToolStripMenuItem
            // 
            eduke32cfgToolStripMenuItem.Name = "eduke32cfgToolStripMenuItem";
            eduke32cfgToolStripMenuItem.Size = new Size(141, 22);
            eduke32cfgToolStripMenuItem.Text = "eduke32.cfg";
            eduke32cfgToolStripMenuItem.Click += eduke32cfgToolStripMenuItem_Click;
            // 
            // settingscfgToolStripMenuItem
            // 
            settingscfgToolStripMenuItem.Name = "settingscfgToolStripMenuItem";
            settingscfgToolStripMenuItem.Size = new Size(141, 22);
            settingscfgToolStripMenuItem.Text = "settings.cfg";
            settingscfgToolStripMenuItem.Click += settingscfgToolStripMenuItem_Click;
            // 
            // eduke32logToolStripMenuItem
            // 
            eduke32logToolStripMenuItem.Name = "eduke32logToolStripMenuItem";
            eduke32logToolStripMenuItem.Size = new Size(141, 22);
            eduke32logToolStripMenuItem.Text = "eduke32.log";
            eduke32logToolStripMenuItem.Click += eduke32logToolStripMenuItem_Click;
            // 
            // reloadOriginalPresetsToolStripMenuItem
            // 
            reloadOriginalPresetsToolStripMenuItem.Name = "reloadOriginalPresetsToolStripMenuItem";
            reloadOriginalPresetsToolStripMenuItem.Size = new Size(195, 22);
            reloadOriginalPresetsToolStripMenuItem.Text = "&Reload Original Presets";
            reloadOriginalPresetsToolStripMenuItem.Click += reloadOriginalPresetsToolStripMenuItem_Click;
            // 
            // importMapsToolStripMenuItem
            // 
            importMapsToolStripMenuItem.Name = "importMapsToolStripMenuItem";
            importMapsToolStripMenuItem.Size = new Size(195, 22);
            importMapsToolStripMenuItem.Text = "&Import Maps";
            importMapsToolStripMenuItem.Click += importMapsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // StatusStrip
            // 
            StatusStrip.AutoSize = false;
            StatusStrip.Items.AddRange(new ToolStripItem[] { TreeStatusLabel, CollisionsStatusLabel, ExePathStatusLabel });
            StatusStrip.Location = new Point(0, 736);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.ShowItemToolTips = true;
            StatusStrip.Size = new Size(1143, 24);
            StatusStrip.SizingGrip = false;
            StatusStrip.TabIndex = 4;
            StatusStrip.Text = "statusStrip1";
            // 
            // TreeStatusLabel
            // 
            TreeStatusLabel.AutoToolTip = true;
            TreeStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left;
            TreeStatusLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TreeStatusLabel.Name = "TreeStatusLabel";
            TreeStatusLabel.Overflow = ToolStripItemOverflow.Never;
            TreeStatusLabel.Size = new Size(76, 19);
            TreeStatusLabel.Text = "Presets Tree:";
            TreeStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CollisionsStatusLabel
            // 
            CollisionsStatusLabel.AutoToolTip = true;
            CollisionsStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left;
            CollisionsStatusLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            CollisionsStatusLabel.Name = "CollisionsStatusLabel";
            CollisionsStatusLabel.Overflow = ToolStripItemOverflow.Never;
            CollisionsStatusLabel.Size = new Size(100, 19);
            CollisionsStatusLabel.Text = "Name Collisions:";
            CollisionsStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ExePathStatusLabel
            // 
            ExePathStatusLabel.AutoToolTip = true;
            ExePathStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Right;
            ExePathStatusLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ExePathStatusLabel.Name = "ExePathStatusLabel";
            ExePathStatusLabel.Overflow = ToolStripItemOverflow.Never;
            ExePathStatusLabel.Size = new Size(952, 19);
            ExePathStatusLabel.Spring = true;
            ExePathStatusLabel.Text = "EDuke32 Path:";
            ExePathStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            ExePathStatusLabel.ToolTipText = "EDuke32 Path:";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 760);
            Controls.Add(StatusStrip);
            Controls.Add(ArgsGroup);
            Controls.Add(LaunchOptionsGroup);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(1159, 799);
            MinimumSize = new Size(1159, 799);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DukeBlaze Launcher";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            LaunchOptionsGroup.ResumeLayout(false);
            LaunchOptionsGroup.PerformLayout();
            AdditionalSettingsPanel.ResumeLayout(false);
            AdditionalSettingsPanel.PerformLayout();
            GroupAdditionalParams.ResumeLayout(false);
            GroupAdditionalParams.PerformLayout();
            ArgsGroup.ResumeLayout(false);
            ArgsGroup.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button EmptyButton;
        private System.Windows.Forms.GroupBox LaunchOptionsGroup;
        private System.Windows.Forms.Button RunButton;
        public System.Windows.Forms.ListBox ListBoxFiles;
        private System.Windows.Forms.GroupBox GroupAdditionalParams;
        private System.Windows.Forms.CheckBox ReplaceMainCheckbox;
        private System.Windows.Forms.Button ButtonRemoveFile;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.GroupBox ArgsGroup;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox AdditionalCommandsTextBox;
        private System.Windows.Forms.Label ArgsHelpButton;
        private System.Windows.Forms.FlowLayoutPanel AdditionalSettingsPanel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox GameDirTextBox;
        private System.Windows.Forms.Button GameDirBrowseButton;
        public System.Windows.Forms.CheckBox DisableStartupWindowCheckbox;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox CfgPathTextBox;
        private System.Windows.Forms.Button CfgPathBrowseButton;
        public System.Windows.Forms.CheckBox DisableMonstersCheckbox;
        public System.Windows.Forms.CheckBox SkipLogoCheckBox;
        public System.Windows.Forms.ComboBox AddonComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox SkillLevelComboBox;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox RespawnModeComboBox;
        private System.Windows.Forms.Button SaveAsPresetButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button NewPresetFolderButton;
        private System.Windows.Forms.Button RemovePresetFolderButton;
        private System.Windows.Forms.Button DownPresetButton;
        private System.Windows.Forms.Button UpPresetButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button DescriptionButton;
        private System.Windows.Forms.TextBox PresetNameTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button EditFolderButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox CustomExeTextBox;
        private System.Windows.Forms.Button CustomExeButton;
        public MyTreeView PresetTree;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllpresetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cfgFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoexeccfgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eduke32cfgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingscfgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eduke32logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePresetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPresetsToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem entireTreeToolStripMenuItem;
        private ToolStripMenuItem selectedNodeToolStripMenuItem;
        private ToolStripMenuItem reloadOriginalPresetsToolStripMenuItem;
        private Button ExpandButton;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel TreeStatusLabel;
        private ToolStripStatusLabel CollisionsStatusLabel;
        private SpringLabel ExePathStatusLabel;
        private Label lbLoadSavePath;
        private ToolStripMenuItem selectedFolderSubfoldersToolStripMenuItem;
        private ToolStripMenuItem importMapsToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        public CheckBox DisableInstanceCheckbox;
    }
}

