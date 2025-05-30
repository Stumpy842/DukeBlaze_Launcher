namespace DukeBlazeLauncher
{
    partial class SettingsWindow
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            label3 = new Label();
            ExePathTextBox = new TextBox();
            ExeBrowseButton = new Button();
            LanguageComboBox = new ComboBox();
            label1 = new Label();
            CancelSettingsButton = new Button();
            SaveSettingsButton = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            cbConfirmDelete = new CheckBox();
            cbConfirmOverWrite = new CheckBox();
            cbExpandTree = new CheckBox();
            groupBox3 = new GroupBox();
            btDefaultCustomColors = new Button();
            lbColor = new Label();
            btPickColor = new Button();
            cbUseColor = new CheckBox();
            gbSavePresets = new GroupBox();
            rbBrowserSave = new RadioButton();
            rbSimpleSave = new RadioButton();
            tabPage2 = new TabPage();
            btTextEditorHelp = new Button();
            cbUseNotepad = new CheckBox();
            btNotepadPath = new Button();
            tbNotepadPath = new TextBox();
            lbUseNotepad = new Label();
            groupBox2 = new GroupBox();
            rbPresetGlobal = new RadioButton();
            rbPresetFolder = new RadioButton();
            rbPresetAll = new RadioButton();
            groupBox1 = new GroupBox();
            rbFolderGlobal = new RadioButton();
            rbFolderParent = new RadioButton();
            rbFolderAll = new RadioButton();
            cbAutoName = new CheckBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            gbSavePresets.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 15);
            label3.Margin = new Padding(9, 12, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 0;
            label3.Text = "Eduke32.exe path";
            // 
            // ExePathTextBox
            // 
            ExePathTextBox.Location = new Point(16, 34);
            ExePathTextBox.Margin = new Padding(12, 3, 4, 3);
            ExePathTextBox.Name = "ExePathTextBox";
            ExePathTextBox.Size = new Size(372, 23);
            ExePathTextBox.TabIndex = 1;
            // 
            // ExeBrowseButton
            // 
            ExeBrowseButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExeBrowseButton.Location = new Point(395, 34);
            ExeBrowseButton.Margin = new Padding(10, 0, 4, 3);
            ExeBrowseButton.Name = "ExeBrowseButton";
            ExeBrowseButton.Size = new Size(25, 25);
            ExeBrowseButton.TabIndex = 2;
            ExeBrowseButton.Text = "⁝";
            ExeBrowseButton.UseVisualStyleBackColor = true;
            ExeBrowseButton.Click += ExeBrowseButton_Click;
            // 
            // LanguageComboBox
            // 
            LanguageComboBox.FormattingEnabled = true;
            LanguageComboBox.Location = new Point(16, 85);
            LanguageComboBox.Margin = new Padding(4, 3, 4, 3);
            LanguageComboBox.Name = "LanguageComboBox";
            LanguageComboBox.Size = new Size(397, 23);
            LanguageComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 66);
            label1.Margin = new Padding(9, 12, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 3;
            label1.Text = "Language (WIP)";
            // 
            // CancelSettingsButton
            // 
            CancelSettingsButton.Location = new Point(230, 323);
            CancelSettingsButton.Margin = new Padding(10, 0, 4, 3);
            CancelSettingsButton.Name = "CancelSettingsButton";
            CancelSettingsButton.Size = new Size(88, 27);
            CancelSettingsButton.TabIndex = 2;
            CancelSettingsButton.Text = "Cancel";
            CancelSettingsButton.UseVisualStyleBackColor = true;
            CancelSettingsButton.Click += CancelSettingsButton_Click;
            // 
            // SaveSettingsButton
            // 
            SaveSettingsButton.Location = new Point(128, 323);
            SaveSettingsButton.Margin = new Padding(10, 0, 4, 3);
            SaveSettingsButton.Name = "SaveSettingsButton";
            SaveSettingsButton.Size = new Size(88, 27);
            SaveSettingsButton.TabIndex = 1;
            SaveSettingsButton.Text = "&Save";
            SaveSettingsButton.UseVisualStyleBackColor = true;
            SaveSettingsButton.Click += SaveSettingsButton_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.HotTrack = true;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(446, 310);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cbAutoName);
            tabPage1.Controls.Add(cbConfirmDelete);
            tabPage1.Controls.Add(cbConfirmOverWrite);
            tabPage1.Controls.Add(cbExpandTree);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(gbSavePresets);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(ExeBrowseButton);
            tabPage1.Controls.Add(ExePathTextBox);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(LanguageComboBox);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(438, 282);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbConfirmDelete
            // 
            cbConfirmDelete.AutoSize = true;
            cbConfirmDelete.Location = new Point(241, 179);
            cbConfirmDelete.Name = "cbConfirmDelete";
            cbConfirmDelete.Size = new Size(146, 19);
            cbConfirmDelete.TabIndex = 9;
            cbConfirmDelete.Text = "Confirm Delete Presets";
            cbConfirmDelete.UseVisualStyleBackColor = true;
            // 
            // cbConfirmOverWrite
            // 
            cbConfirmOverWrite.AutoSize = true;
            cbConfirmOverWrite.Location = new Point(241, 154);
            cbConfirmOverWrite.Name = "cbConfirmOverWrite";
            cbConfirmOverWrite.Size = new Size(168, 19);
            cbConfirmOverWrite.TabIndex = 8;
            cbConfirmOverWrite.Text = "Confirm Overwrite on Save";
            cbConfirmOverWrite.UseVisualStyleBackColor = true;
            // 
            // cbExpandTree
            // 
            cbExpandTree.AutoSize = true;
            cbExpandTree.Location = new Point(241, 129);
            cbExpandTree.Name = "cbExpandTree";
            cbExpandTree.Size = new Size(135, 19);
            cbExpandTree.TabIndex = 7;
            cbExpandTree.Text = "Expand Tree on Load";
            cbExpandTree.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btDefaultCustomColors);
            groupBox3.Controls.Add(lbColor);
            groupBox3.Controls.Add(btPickColor);
            groupBox3.Controls.Add(cbUseColor);
            groupBox3.Location = new Point(16, 179);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(206, 97);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Use Color in Preset Tree";
            // 
            // btDefaultCustomColors
            // 
            btDefaultCustomColors.AutoSize = true;
            btDefaultCustomColors.Location = new Point(35, 60);
            btDefaultCustomColors.Name = "btDefaultCustomColors";
            btDefaultCustomColors.Size = new Size(137, 27);
            btDefaultCustomColors.TabIndex = 3;
            btDefaultCustomColors.Text = "Default Custom Colors";
            btDefaultCustomColors.UseVisualStyleBackColor = true;
            btDefaultCustomColors.Click += btDefaultCustomColors_Click;
            // 
            // lbColor
            // 
            lbColor.BackColor = Color.Red;
            lbColor.BorderStyle = BorderStyle.FixedSingle;
            lbColor.Location = new Point(56, 24);
            lbColor.Name = "lbColor";
            lbColor.Size = new Size(40, 27);
            lbColor.TabIndex = 2;
            lbColor.Click += btPickColor_Click;
            // 
            // btPickColor
            // 
            btPickColor.Enabled = false;
            btPickColor.Location = new Point(106, 24);
            btPickColor.Name = "btPickColor";
            btPickColor.Size = new Size(88, 27);
            btPickColor.TabIndex = 1;
            btPickColor.Text = "&Choose Color";
            btPickColor.UseVisualStyleBackColor = true;
            btPickColor.Click += btPickColor_Click;
            // 
            // cbUseColor
            // 
            cbUseColor.AutoSize = true;
            cbUseColor.Location = new Point(9, 28);
            cbUseColor.Name = "cbUseColor";
            cbUseColor.Size = new Size(42, 19);
            cbUseColor.TabIndex = 0;
            cbUseColor.Text = "No";
            cbUseColor.UseVisualStyleBackColor = true;
            cbUseColor.CheckedChanged += cbUseColor_CheckedChanged;
            // 
            // gbSavePresets
            // 
            gbSavePresets.Controls.Add(rbBrowserSave);
            gbSavePresets.Controls.Add(rbSimpleSave);
            gbSavePresets.Location = new Point(16, 119);
            gbSavePresets.Name = "gbSavePresets";
            gbSavePresets.Size = new Size(206, 51);
            gbSavePresets.TabIndex = 5;
            gbSavePresets.TabStop = false;
            gbSavePresets.Text = "Save Presets Using:";
            // 
            // rbBrowserSave
            // 
            rbBrowserSave.AutoSize = true;
            rbBrowserSave.Location = new Point(103, 22);
            rbBrowserSave.Name = "rbBrowserSave";
            rbBrowserSave.Size = new Size(88, 19);
            rbBrowserSave.TabIndex = 1;
            rbBrowserSave.TabStop = true;
            rbBrowserSave.Text = "File Browser";
            rbBrowserSave.UseVisualStyleBackColor = true;
            // 
            // rbSimpleSave
            // 
            rbSimpleSave.AutoSize = true;
            rbSimpleSave.Location = new Point(7, 22);
            rbSimpleSave.Name = "rbSimpleSave";
            rbSimpleSave.Size = new Size(90, 19);
            rbSimpleSave.TabIndex = 0;
            rbSimpleSave.TabStop = true;
            rbSimpleSave.Text = "Input Dialog";
            rbSimpleSave.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btTextEditorHelp);
            tabPage2.Controls.Add(cbUseNotepad);
            tabPage2.Controls.Add(btNotepadPath);
            tabPage2.Controls.Add(tbNotepadPath);
            tabPage2.Controls.Add(lbUseNotepad);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(438, 282);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Advanced";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btTextEditorHelp
            // 
            btTextEditorHelp.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btTextEditorHelp.Location = new Point(246, 116);
            btTextEditorHelp.Name = "btTextEditorHelp";
            btTextEditorHelp.Size = new Size(25, 25);
            btTextEditorHelp.TabIndex = 3;
            btTextEditorHelp.Text = "?";
            btTextEditorHelp.UseVisualStyleBackColor = true;
            btTextEditorHelp.Click += btTextEditorHelp_Click;
            // 
            // cbUseNotepad
            // 
            cbUseNotepad.AutoSize = true;
            cbUseNotepad.Location = new Point(16, 120);
            cbUseNotepad.Name = "cbUseNotepad";
            cbUseNotepad.Size = new Size(214, 19);
            cbUseNotepad.TabIndex = 2;
            cbUseNotepad.Text = "Use Text Editor for Viewing Cfg Files";
            cbUseNotepad.UseVisualStyleBackColor = true;
            cbUseNotepad.CheckedChanged += cbUseNotepad_CheckedChanged;
            // 
            // btNotepadPath
            // 
            btNotepadPath.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btNotepadPath.Location = new Point(395, 167);
            btNotepadPath.Name = "btNotepadPath";
            btNotepadPath.Size = new Size(25, 25);
            btNotepadPath.TabIndex = 6;
            btNotepadPath.Text = "⁝";
            btNotepadPath.UseVisualStyleBackColor = true;
            btNotepadPath.Click += btNotepadPath_Click;
            // 
            // tbNotepadPath
            // 
            tbNotepadPath.Location = new Point(16, 167);
            tbNotepadPath.Name = "tbNotepadPath";
            tbNotepadPath.Size = new Size(372, 23);
            tbNotepadPath.TabIndex = 5;
            // 
            // lbUseNotepad
            // 
            lbUseNotepad.AutoSize = true;
            lbUseNotepad.Location = new Point(16, 148);
            lbUseNotepad.Name = "lbUseNotepad";
            lbUseNotepad.Size = new Size(134, 15);
            lbUseNotepad.TabIndex = 4;
            lbUseNotepad.Text = "Custom Text Editor Path";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbPresetGlobal);
            groupBox2.Controls.Add(rbPresetFolder);
            groupBox2.Controls.Add(rbPresetAll);
            groupBox2.Location = new Point(230, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(190, 100);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Preset Name Collisions";
            // 
            // rbPresetGlobal
            // 
            rbPresetGlobal.AutoSize = true;
            rbPresetGlobal.Location = new Point(6, 68);
            rbPresetGlobal.Name = "rbPresetGlobal";
            rbPresetGlobal.Size = new Size(111, 19);
            rbPresetGlobal.TabIndex = 2;
            rbPresetGlobal.TabStop = true;
            rbPresetGlobal.Text = "Prevent Globally";
            rbPresetGlobal.UseVisualStyleBackColor = true;
            // 
            // rbPresetFolder
            // 
            rbPresetFolder.AutoSize = true;
            rbPresetFolder.Location = new Point(6, 45);
            rbPresetFolder.Name = "rbPresetFolder";
            rbPresetFolder.Size = new Size(139, 19);
            rbPresetFolder.TabIndex = 1;
            rbPresetFolder.TabStop = true;
            rbPresetFolder.Text = "Prevent In This Folder";
            rbPresetFolder.UseVisualStyleBackColor = true;
            // 
            // rbPresetAll
            // 
            rbPresetAll.AutoSize = true;
            rbPresetAll.Location = new Point(6, 22);
            rbPresetAll.Name = "rbPresetAll";
            rbPresetAll.Size = new Size(72, 19);
            rbPresetAll.TabIndex = 0;
            rbPresetAll.TabStop = true;
            rbPresetAll.Text = "Allow All";
            rbPresetAll.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbFolderGlobal);
            groupBox1.Controls.Add(rbFolderParent);
            groupBox1.Controls.Add(rbFolderAll);
            groupBox1.Location = new Point(16, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(190, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Folder Name Collisions";
            // 
            // rbFolderGlobal
            // 
            rbFolderGlobal.AutoSize = true;
            rbFolderGlobal.Location = new Point(6, 68);
            rbFolderGlobal.Name = "rbFolderGlobal";
            rbFolderGlobal.Size = new Size(111, 19);
            rbFolderGlobal.TabIndex = 2;
            rbFolderGlobal.TabStop = true;
            rbFolderGlobal.Text = "Prevent Globally";
            rbFolderGlobal.UseVisualStyleBackColor = true;
            // 
            // rbFolderParent
            // 
            rbFolderParent.AutoSize = true;
            rbFolderParent.Location = new Point(6, 45);
            rbFolderParent.Name = "rbFolderParent";
            rbFolderParent.Size = new Size(169, 19);
            rbFolderParent.TabIndex = 1;
            rbFolderParent.TabStop = true;
            rbFolderParent.Text = "Prevent From Parent Folder";
            rbFolderParent.UseVisualStyleBackColor = true;
            // 
            // rbFolderAll
            // 
            rbFolderAll.AutoSize = true;
            rbFolderAll.Location = new Point(6, 22);
            rbFolderAll.Name = "rbFolderAll";
            rbFolderAll.Size = new Size(72, 19);
            rbFolderAll.TabIndex = 0;
            rbFolderAll.TabStop = true;
            rbFolderAll.Text = "Allow All";
            rbFolderAll.UseVisualStyleBackColor = true;
            // 
            // cbAutoName
            // 
            cbAutoName.AutoSize = true;
            cbAutoName.Location = new Point(241, 204);
            cbAutoName.Name = "cbAutoName";
            cbAutoName.Size = new Size(122, 19);
            cbAutoName.TabIndex = 10;
            cbAutoName.Text = "Auto Name Preset";
            cbAutoName.UseVisualStyleBackColor = true;
            // 
            // SettingsWindow
            // 
            AcceptButton = SaveSettingsButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 362);
            Controls.Add(tabControl1);
            Controls.Add(SaveSettingsButton);
            Controls.Add(CancelSettingsButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(462, 259);
            Name = "SettingsWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            KeyDown += SettingsWindow_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbSavePresets.ResumeLayout(false);
            gbSavePresets.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ExeBrowseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelSettingsButton;
        private Button SaveSettingsButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox gbSavePresets;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        public RadioButton rbFolderGlobal;
        public RadioButton rbFolderParent;
        public RadioButton rbFolderAll;
        public RadioButton rbPresetGlobal;
        public RadioButton rbPresetFolder;
        public RadioButton rbPresetAll;
        private GroupBox groupBox3;
        internal CheckBox cbConfirmOverWrite;
        internal CheckBox cbExpandTree;
        internal TextBox ExePathTextBox;
        internal ComboBox LanguageComboBox;
        internal RadioButton rbSimpleSave;
        internal RadioButton rbBrowserSave;
        internal CheckBox cbUseColor;
        internal Button btPickColor;
        internal Label lbColor;
        internal CheckBox cbConfirmDelete;
        private Label lbUseNotepad;
        internal TextBox tbNotepadPath;
        private Button btNotepadPath;
        private Button btDefaultCustomColors;
        internal CheckBox cbUseNotepad;
        private Button btTextEditorHelp;
        internal CheckBox cbAutoName;
    }
}