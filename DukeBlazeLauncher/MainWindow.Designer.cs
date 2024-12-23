using System;
using System.Drawing;

namespace DragDukeLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("📁 Expansions", 10, 10);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("📁 Episodes");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("📁 Maps");
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.NewPresetFolderButton = new System.Windows.Forms.Button();
            this.EditFolderButton = new System.Windows.Forms.Button();
            this.RemovePresetFolderButton = new System.Windows.Forms.Button();
            this.DownPresetButton = new System.Windows.Forms.Button();
            this.UpPresetButton = new System.Windows.Forms.Button();
            this.PresetTree = new System.Windows.Forms.TreeView();
            this.EmptyButton = new System.Windows.Forms.Button();
            this.LaunchOptionsGroup = new System.Windows.Forms.GroupBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.AdditionalSettingsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.GameDirTextBox = new System.Windows.Forms.TextBox();
            this.GameDirBrowseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CfgPathTextBox = new System.Windows.Forms.TextBox();
            this.CfgPathBrowseButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SkillLevelComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddonComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RespawnModeComboBox = new System.Windows.Forms.ComboBox();
            this.DisableStartupWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.DisableMonstersCheckbox = new System.Windows.Forms.CheckBox();
            this.SkipLogoCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CustomExeTextBox = new System.Windows.Forms.TextBox();
            this.CustomExeButton = new System.Windows.Forms.Button();
            this.ButtonRemoveFile = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.GroupAdditionalParams = new System.Windows.Forms.GroupBox();
            this.ReplaceMainCheckbox = new System.Windows.Forms.CheckBox();
            this.ListBoxFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.ArgsGroup = new System.Windows.Forms.GroupBox();
            this.DescriptionButton = new System.Windows.Forms.Button();
            this.PresetNameTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SaveAsPresetButton = new System.Windows.Forms.Button();
            this.ArgsHelpButton = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AdditionalCommandsTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.LaunchOptionsGroup.SuspendLayout();
            this.AdditionalSettingsPanel.SuspendLayout();
            this.GroupAdditionalParams.SuspendLayout();
            this.ArgsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.PresetTree);
            this.groupBox1.Controls.Add(this.EmptyButton);
            this.groupBox1.Location = new System.Drawing.Point(5, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 612);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presets";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.NewPresetFolderButton);
            this.flowLayoutPanel1.Controls.Add(this.EditFolderButton);
            this.flowLayoutPanel1.Controls.Add(this.RemovePresetFolderButton);
            this.flowLayoutPanel1.Controls.Add(this.DownPresetButton);
            this.flowLayoutPanel1.Controls.Add(this.UpPresetButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 557);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(249, 50);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // NewPresetFolderButton
            // 
            this.NewPresetFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("NewPresetFolderButton.Image")));
            this.NewPresetFolderButton.Location = new System.Drawing.Point(3, 3);
            this.NewPresetFolderButton.Name = "NewPresetFolderButton";
            this.NewPresetFolderButton.Size = new System.Drawing.Size(43, 41);
            this.NewPresetFolderButton.TabIndex = 11;
            this.NewPresetFolderButton.UseVisualStyleBackColor = true;
            this.NewPresetFolderButton.Click += new System.EventHandler(this.NewPresetFolderBtn_Click);
            // 
            // EditFolderButton
            // 
            this.EditFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("EditFolderButton.Image")));
            this.EditFolderButton.Location = new System.Drawing.Point(52, 3);
            this.EditFolderButton.Name = "EditFolderButton";
            this.EditFolderButton.Size = new System.Drawing.Size(43, 41);
            this.EditFolderButton.TabIndex = 15;
            this.EditFolderButton.UseVisualStyleBackColor = true;
            this.EditFolderButton.Click += new System.EventHandler(this.EditFolderButton_Click);
            // 
            // RemovePresetFolderButton
            // 
            this.RemovePresetFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("RemovePresetFolderButton.Image")));
            this.RemovePresetFolderButton.Location = new System.Drawing.Point(101, 3);
            this.RemovePresetFolderButton.Name = "RemovePresetFolderButton";
            this.RemovePresetFolderButton.Size = new System.Drawing.Size(43, 41);
            this.RemovePresetFolderButton.TabIndex = 12;
            this.RemovePresetFolderButton.UseVisualStyleBackColor = true;
            this.RemovePresetFolderButton.Click += new System.EventHandler(this.RemovePresetFolderButton_Click);
            // 
            // DownPresetButton
            // 
            this.DownPresetButton.Image = ((System.Drawing.Image)(resources.GetObject("DownPresetButton.Image")));
            this.DownPresetButton.Location = new System.Drawing.Point(150, 3);
            this.DownPresetButton.Name = "DownPresetButton";
            this.DownPresetButton.Size = new System.Drawing.Size(43, 41);
            this.DownPresetButton.TabIndex = 14;
            this.DownPresetButton.UseVisualStyleBackColor = true;
            this.DownPresetButton.Click += new System.EventHandler(this.DownPresetButton_Click);
            // 
            // UpPresetButton
            // 
            this.UpPresetButton.Image = ((System.Drawing.Image)(resources.GetObject("UpPresetButton.Image")));
            this.UpPresetButton.Location = new System.Drawing.Point(199, 3);
            this.UpPresetButton.Name = "UpPresetButton";
            this.UpPresetButton.Size = new System.Drawing.Size(43, 41);
            this.UpPresetButton.TabIndex = 13;
            this.UpPresetButton.UseVisualStyleBackColor = true;
            this.UpPresetButton.Click += new System.EventHandler(this.UpPresetButton_Click);
            // 
            // PresetTree
            // 
            this.PresetTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PresetTree.Location = new System.Drawing.Point(8, 53);
            this.PresetTree.Name = "PresetTree";
            treeNode7.ImageIndex = 10;
            treeNode7.Name = "Expansions";
            treeNode7.SelectedImageIndex = 10;
            treeNode7.Tag = "0";
            treeNode7.Text = "📁 Expansions";
            treeNode8.Name = "Episodes";
            treeNode8.Tag = "1";
            treeNode8.Text = "📁 Episodes";
            treeNode9.Name = "Maps";
            treeNode9.Tag = "2";
            treeNode9.Text = "📁 Maps";
            this.PresetTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.PresetTree.Size = new System.Drawing.Size(249, 498);
            this.PresetTree.TabIndex = 5;
            // 
            // EmptyButton
            // 
            this.EmptyButton.Location = new System.Drawing.Point(7, 19);
            this.EmptyButton.Name = "EmptyButton";
            this.EmptyButton.Size = new System.Drawing.Size(250, 28);
            this.EmptyButton.TabIndex = 3;
            this.EmptyButton.Text = "Empty";
            this.EmptyButton.UseVisualStyleBackColor = true;
            this.EmptyButton.Click += new System.EventHandler(this.EmptyButton_Click);
            // 
            // LaunchOptionsGroup
            // 
            this.LaunchOptionsGroup.Controls.Add(this.BrowseButton);
            this.LaunchOptionsGroup.Controls.Add(this.label8);
            this.LaunchOptionsGroup.Controls.Add(this.AdditionalSettingsPanel);
            this.LaunchOptionsGroup.Controls.Add(this.ButtonRemoveFile);
            this.LaunchOptionsGroup.Controls.Add(this.MoveDownButton);
            this.LaunchOptionsGroup.Controls.Add(this.MoveUpButton);
            this.LaunchOptionsGroup.Controls.Add(this.GroupAdditionalParams);
            this.LaunchOptionsGroup.Controls.Add(this.ListBoxFiles);
            this.LaunchOptionsGroup.Controls.Add(this.label1);
            this.LaunchOptionsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchOptionsGroup.Location = new System.Drawing.Point(283, 40);
            this.LaunchOptionsGroup.Name = "LaunchOptionsGroup";
            this.LaunchOptionsGroup.Size = new System.Drawing.Size(685, 408);
            this.LaunchOptionsGroup.TabIndex = 3;
            this.LaunchOptionsGroup.TabStop = false;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.BrowseButton.Location = new System.Drawing.Point(264, 139);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(23, 34);
            this.BrowseButton.TabIndex = 20;
            this.BrowseButton.Text = "⁝";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Additional parameters";
            // 
            // AdditionalSettingsPanel
            // 
            this.AdditionalSettingsPanel.AutoScroll = true;
            this.AdditionalSettingsPanel.Controls.Add(this.label3);
            this.AdditionalSettingsPanel.Controls.Add(this.GameDirTextBox);
            this.AdditionalSettingsPanel.Controls.Add(this.GameDirBrowseButton);
            this.AdditionalSettingsPanel.Controls.Add(this.label4);
            this.AdditionalSettingsPanel.Controls.Add(this.CfgPathTextBox);
            this.AdditionalSettingsPanel.Controls.Add(this.CfgPathBrowseButton);
            this.AdditionalSettingsPanel.Controls.Add(this.label6);
            this.AdditionalSettingsPanel.Controls.Add(this.SkillLevelComboBox);
            this.AdditionalSettingsPanel.Controls.Add(this.label5);
            this.AdditionalSettingsPanel.Controls.Add(this.AddonComboBox);
            this.AdditionalSettingsPanel.Controls.Add(this.label7);
            this.AdditionalSettingsPanel.Controls.Add(this.RespawnModeComboBox);
            this.AdditionalSettingsPanel.Controls.Add(this.DisableStartupWindowCheckbox);
            this.AdditionalSettingsPanel.Controls.Add(this.DisableMonstersCheckbox);
            this.AdditionalSettingsPanel.Controls.Add(this.SkipLogoCheckBox);
            this.AdditionalSettingsPanel.Controls.Add(this.label10);
            this.AdditionalSettingsPanel.Controls.Add(this.CustomExeTextBox);
            this.AdditionalSettingsPanel.Controls.Add(this.CustomExeButton);
            this.AdditionalSettingsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.AdditionalSettingsPanel.Location = new System.Drawing.Point(294, 19);
            this.AdditionalSettingsPanel.Name = "AdditionalSettingsPanel";
            this.AdditionalSettingsPanel.Size = new System.Drawing.Size(379, 383);
            this.AdditionalSettingsPanel.TabIndex = 10;
            this.AdditionalSettingsPanel.WrapContents = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Game Directory (-game_dir)";
            // 
            // GameDirTextBox
            // 
            this.GameDirTextBox.Location = new System.Drawing.Point(10, 26);
            this.GameDirTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.GameDirTextBox.Name = "GameDirTextBox";
            this.GameDirTextBox.Size = new System.Drawing.Size(342, 20);
            this.GameDirTextBox.TabIndex = 0;
            // 
            // GameDirBrowseButton
            // 
            this.GameDirBrowseButton.Location = new System.Drawing.Point(9, 49);
            this.GameDirBrowseButton.Margin = new System.Windows.Forms.Padding(9, 0, 3, 3);
            this.GameDirBrowseButton.Name = "GameDirBrowseButton";
            this.GameDirBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.GameDirBrowseButton.TabIndex = 2;
            this.GameDirBrowseButton.Text = "Browse";
            this.GameDirBrowseButton.UseVisualStyleBackColor = true;
            this.GameDirBrowseButton.Click += new System.EventHandler(this.GameDirBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Alternative Configuration File (-cfg)";
            // 
            // CfgPathTextBox
            // 
            this.CfgPathTextBox.Location = new System.Drawing.Point(10, 101);
            this.CfgPathTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.CfgPathTextBox.Name = "CfgPathTextBox";
            this.CfgPathTextBox.Size = new System.Drawing.Size(342, 20);
            this.CfgPathTextBox.TabIndex = 4;
            // 
            // CfgPathBrowseButton
            // 
            this.CfgPathBrowseButton.Location = new System.Drawing.Point(9, 124);
            this.CfgPathBrowseButton.Margin = new System.Windows.Forms.Padding(9, 0, 3, 3);
            this.CfgPathBrowseButton.Name = "CfgPathBrowseButton";
            this.CfgPathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.CfgPathBrowseButton.TabIndex = 6;
            this.CfgPathBrowseButton.Text = "Browse";
            this.CfgPathBrowseButton.UseVisualStyleBackColor = true;
            this.CfgPathBrowseButton.Click += new System.EventHandler(this.CfgPathBrowseButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Skill level";
            // 
            // SkillLevelComboBox
            // 
            this.SkillLevelComboBox.FormattingEnabled = true;
            this.SkillLevelComboBox.Items.AddRange(new object[] {
            "0 - Piece of Cake",
            "1 - Let\'s Rock",
            "2 - Come Get Some",
            "3 - Damn I\'m Good",
            "4 - Respawn Monsters"});
            this.SkillLevelComboBox.Location = new System.Drawing.Point(10, 176);
            this.SkillLevelComboBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.SkillLevelComboBox.Name = "SkillLevelComboBox";
            this.SkillLevelComboBox.Size = new System.Drawing.Size(342, 21);
            this.SkillLevelComboBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Addon (-addon)";
            // 
            // AddonComboBox
            // 
            this.AddonComboBox.FormattingEnabled = true;
            this.AddonComboBox.Items.AddRange(new object[] {
            "0 - none",
            "1 - Duke it out in D.C.",
            "2 - Duke: Nuclear Winter",
            "3 - Duke Caribbean: Life\'s a Beach"});
            this.AddonComboBox.Location = new System.Drawing.Point(10, 226);
            this.AddonComboBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.AddonComboBox.Name = "AddonComboBox";
            this.AddonComboBox.Size = new System.Drawing.Size(342, 21);
            this.AddonComboBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 260);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Respawn Mode";
            // 
            // RespawnModeComboBox
            // 
            this.RespawnModeComboBox.FormattingEnabled = true;
            this.RespawnModeComboBox.Items.AddRange(new object[] {
            "0 - none",
            "1 - Monsters",
            "2 - Items",
            "3 - Inventory",
            "x - All"});
            this.RespawnModeComboBox.Location = new System.Drawing.Point(10, 276);
            this.RespawnModeComboBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.RespawnModeComboBox.Name = "RespawnModeComboBox";
            this.RespawnModeComboBox.Size = new System.Drawing.Size(342, 21);
            this.RespawnModeComboBox.TabIndex = 16;
            // 
            // DisableStartupWindowCheckbox
            // 
            this.DisableStartupWindowCheckbox.AutoSize = true;
            this.DisableStartupWindowCheckbox.Checked = true;
            this.DisableStartupWindowCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisableStartupWindowCheckbox.Location = new System.Drawing.Point(10, 320);
            this.DisableStartupWindowCheckbox.Margin = new System.Windows.Forms.Padding(10, 20, 3, 3);
            this.DisableStartupWindowCheckbox.Name = "DisableStartupWindowCheckbox";
            this.DisableStartupWindowCheckbox.Size = new System.Drawing.Size(185, 17);
            this.DisableStartupWindowCheckbox.TabIndex = 3;
            this.DisableStartupWindowCheckbox.Text = "Disable startup window (-nosetup)";
            this.DisableStartupWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableMonstersCheckbox
            // 
            this.DisableMonstersCheckbox.AutoSize = true;
            this.DisableMonstersCheckbox.Location = new System.Drawing.Point(10, 343);
            this.DisableMonstersCheckbox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.DisableMonstersCheckbox.Name = "DisableMonstersCheckbox";
            this.DisableMonstersCheckbox.Size = new System.Drawing.Size(126, 17);
            this.DisableMonstersCheckbox.TabIndex = 7;
            this.DisableMonstersCheckbox.Text = "Disable monsters (-m)";
            this.DisableMonstersCheckbox.UseVisualStyleBackColor = true;
            // 
            // SkipLogoCheckBox
            // 
            this.SkipLogoCheckBox.AutoSize = true;
            this.SkipLogoCheckBox.Checked = true;
            this.SkipLogoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SkipLogoCheckBox.Location = new System.Drawing.Point(10, 366);
            this.SkipLogoCheckBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.SkipLogoCheckBox.Name = "SkipLogoCheckBox";
            this.SkipLogoCheckBox.Size = new System.Drawing.Size(291, 17);
            this.SkipLogoCheckBox.TabIndex = 8;
            this.SkipLogoCheckBox.Text = "Skip all the startup animations and logos (-nologo,-quick)";
            this.SkipLogoCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 401);
            this.label10.Margin = new System.Windows.Forms.Padding(9, 15, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Custom eDuke32 exe";
            // 
            // CustomExeTextBox
            // 
            this.CustomExeTextBox.Location = new System.Drawing.Point(10, 417);
            this.CustomExeTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.CustomExeTextBox.Name = "CustomExeTextBox";
            this.CustomExeTextBox.Size = new System.Drawing.Size(342, 20);
            this.CustomExeTextBox.TabIndex = 18;
            // 
            // CustomExeButton
            // 
            this.CustomExeButton.Location = new System.Drawing.Point(9, 440);
            this.CustomExeButton.Margin = new System.Windows.Forms.Padding(9, 0, 3, 3);
            this.CustomExeButton.Name = "CustomExeButton";
            this.CustomExeButton.Size = new System.Drawing.Size(75, 23);
            this.CustomExeButton.TabIndex = 20;
            this.CustomExeButton.Text = "Browse";
            this.CustomExeButton.UseVisualStyleBackColor = true;
            this.CustomExeButton.Click += new System.EventHandler(this.CustomExeButton_Click);
            // 
            // ButtonRemoveFile
            // 
            this.ButtonRemoveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonRemoveFile.Location = new System.Drawing.Point(264, 99);
            this.ButtonRemoveFile.Name = "ButtonRemoveFile";
            this.ButtonRemoveFile.Size = new System.Drawing.Size(23, 34);
            this.ButtonRemoveFile.TabIndex = 9;
            this.ButtonRemoveFile.Text = "x";
            this.ButtonRemoveFile.UseVisualStyleBackColor = true;
            this.ButtonRemoveFile.Click += new System.EventHandler(this.ButtonRemoveFile_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoveDownButton.Location = new System.Drawing.Point(264, 59);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(23, 34);
            this.MoveDownButton.TabIndex = 8;
            this.MoveDownButton.Text = "⬇";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoveUpButton.Location = new System.Drawing.Point(264, 19);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(23, 34);
            this.MoveUpButton.TabIndex = 7;
            this.MoveUpButton.Text = "⬆";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // GroupAdditionalParams
            // 
            this.GroupAdditionalParams.Controls.Add(this.ReplaceMainCheckbox);
            this.GroupAdditionalParams.Location = new System.Drawing.Point(9, 269);
            this.GroupAdditionalParams.Name = "GroupAdditionalParams";
            this.GroupAdditionalParams.Size = new System.Drawing.Size(249, 133);
            this.GroupAdditionalParams.TabIndex = 2;
            this.GroupAdditionalParams.TabStop = false;
            this.GroupAdditionalParams.Text = "DEFINITION.DEF";
            // 
            // ReplaceMainCheckbox
            // 
            this.ReplaceMainCheckbox.AutoSize = true;
            this.ReplaceMainCheckbox.Location = new System.Drawing.Point(7, 20);
            this.ReplaceMainCheckbox.Name = "ReplaceMainCheckbox";
            this.ReplaceMainCheckbox.Size = new System.Drawing.Size(92, 17);
            this.ReplaceMainCheckbox.TabIndex = 0;
            this.ReplaceMainCheckbox.Text = "Replace Main";
            this.ReplaceMainCheckbox.UseVisualStyleBackColor = true;
            this.ReplaceMainCheckbox.CheckedChanged += new System.EventHandler(this.ReplaceMainCheckbox_CheckedChanged);
            // 
            // ListBoxFiles
            // 
            this.ListBoxFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ListBoxFiles.FormattingEnabled = true;
            this.ListBoxFiles.ItemHeight = 16;
            this.ListBoxFiles.Location = new System.Drawing.Point(9, 19);
            this.ListBoxFiles.Name = "ListBoxFiles";
            this.ListBoxFiles.Size = new System.Drawing.Size(249, 244);
            this.ListBoxFiles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Files";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(566, 81);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(107, 34);
            this.RunButton.TabIndex = 4;
            this.RunButton.Text = "RUN ▶";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(125, 6);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(107, 28);
            this.AboutButton.TabIndex = 6;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // ArgsGroup
            // 
            this.ArgsGroup.Controls.Add(this.DescriptionButton);
            this.ArgsGroup.Controls.Add(this.PresetNameTextBox);
            this.ArgsGroup.Controls.Add(this.label9);
            this.ArgsGroup.Controls.Add(this.SaveAsPresetButton);
            this.ArgsGroup.Controls.Add(this.ArgsHelpButton);
            this.ArgsGroup.Controls.Add(this.label2);
            this.ArgsGroup.Controls.Add(this.AdditionalCommandsTextBox);
            this.ArgsGroup.Controls.Add(this.RunButton);
            this.ArgsGroup.Location = new System.Drawing.Point(283, 454);
            this.ArgsGroup.Name = "ArgsGroup";
            this.ArgsGroup.Size = new System.Drawing.Size(685, 180);
            this.ArgsGroup.TabIndex = 7;
            this.ArgsGroup.TabStop = false;
            // 
            // DescriptionButton
            // 
            this.DescriptionButton.Location = new System.Drawing.Point(122, 133);
            this.DescriptionButton.Name = "DescriptionButton";
            this.DescriptionButton.Size = new System.Drawing.Size(107, 34);
            this.DescriptionButton.TabIndex = 13;
            this.DescriptionButton.Text = "Description";
            this.DescriptionButton.UseVisualStyleBackColor = true;
            this.DescriptionButton.Click += new System.EventHandler(this.DescriptionButton_Click);
            // 
            // PresetNameTextBox
            // 
            this.PresetNameTextBox.Location = new System.Drawing.Point(9, 104);
            this.PresetNameTextBox.Name = "PresetNameTextBox";
            this.PresetNameTextBox.Size = new System.Drawing.Size(330, 20);
            this.PresetNameTextBox.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Preset Name";
            // 
            // SaveAsPresetButton
            // 
            this.SaveAsPresetButton.Location = new System.Drawing.Point(9, 133);
            this.SaveAsPresetButton.Name = "SaveAsPresetButton";
            this.SaveAsPresetButton.Size = new System.Drawing.Size(107, 34);
            this.SaveAsPresetButton.TabIndex = 8;
            this.SaveAsPresetButton.Text = "Save Preset";
            this.SaveAsPresetButton.UseVisualStyleBackColor = true;
            this.SaveAsPresetButton.Click += new System.EventHandler(this.SaveAsPresetButton_Click);
            // 
            // ArgsHelpButton
            // 
            this.ArgsHelpButton.AutoSize = true;
            this.ArgsHelpButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArgsHelpButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ArgsHelpButton.Location = new System.Drawing.Point(182, 15);
            this.ArgsHelpButton.Name = "ArgsHelpButton";
            this.ArgsHelpButton.Size = new System.Drawing.Size(35, 13);
            this.ArgsHelpButton.TabIndex = 10;
            this.ArgsHelpButton.Text = "(Help)";
            this.ArgsHelpButton.Click += new System.EventHandler(this.ArgsHelpButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Additional Command-Line Arguments";
            // 
            // AdditionalCommandsTextBox
            // 
            this.AdditionalCommandsTextBox.Location = new System.Drawing.Point(9, 31);
            this.AdditionalCommandsTextBox.Name = "AdditionalCommandsTextBox";
            this.AdditionalCommandsTextBox.Size = new System.Drawing.Size(664, 44);
            this.AdditionalCommandsTextBox.TabIndex = 0;
            this.AdditionalCommandsTextBox.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 659);
            this.Controls.Add(this.ArgsGroup);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.LaunchOptionsGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(996, 698);
            this.MinimumSize = new System.Drawing.Size(996, 698);
            this.Name = "MainWindow";
            this.Text = "DukeBlaze Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.LaunchOptionsGroup.ResumeLayout(false);
            this.LaunchOptionsGroup.PerformLayout();
            this.AdditionalSettingsPanel.ResumeLayout(false);
            this.AdditionalSettingsPanel.PerformLayout();
            this.GroupAdditionalParams.ResumeLayout(false);
            this.GroupAdditionalParams.PerformLayout();
            this.ArgsGroup.ResumeLayout(false);
            this.ArgsGroup.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button EmptyButton;
        private System.Windows.Forms.GroupBox LaunchOptionsGroup;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button AboutButton;
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
        public System.Windows.Forms.TreeView PresetTree;
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
    }
}

