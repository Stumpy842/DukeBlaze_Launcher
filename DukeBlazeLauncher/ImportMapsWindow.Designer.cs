namespace DukeBlazeLauncher
{
    partial class ImportMapsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportMapsWindow));
            lbxFiles = new ListBox();
            groupBox1 = new GroupBox();
            cbImportSummary = new CheckBox();
            cbClearList = new CheckBox();
            btRemoveFiles = new Button();
            btAddFiles = new Button();
            btDone = new Button();
            btImport = new Button();
            groupBox2 = new GroupBox();
            tbFolderName = new TextBox();
            lbInstruct = new Label();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // lbxFiles
            // 
            lbxFiles.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbxFiles.FormattingEnabled = true;
            lbxFiles.Location = new Point(9, 20);
            lbxFiles.Name = "lbxFiles";
            lbxFiles.SelectionMode = SelectionMode.MultiSimple;
            lbxFiles.Size = new Size(290, 484);
            lbxFiles.TabIndex = 0;
            lbxFiles.SelectedIndexChanged += lbxFiles_SelectedIndexChanged;
            lbxFiles.DragDrop += lbxFiles_DragDrop;
            lbxFiles.DragEnter += lbxFiles_DragEnter;
            lbxFiles.KeyDown += lbxFiles_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbImportSummary);
            groupBox1.Controls.Add(cbClearList);
            groupBox1.Controls.Add(btRemoveFiles);
            groupBox1.Controls.Add(btAddFiles);
            groupBox1.Controls.Add(lbxFiles);
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(308, 588);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Files";
            // 
            // cbImportSummary
            // 
            cbImportSummary.AutoSize = true;
            cbImportSummary.Location = new Point(155, 510);
            cbImportSummary.Name = "cbImportSummary";
            cbImportSummary.Size = new Size(148, 19);
            cbImportSummary.TabIndex = 4;
            cbImportSummary.Text = "Show Import Summary";
            cbImportSummary.UseVisualStyleBackColor = true;
            // 
            // cbClearList
            // 
            cbClearList.AutoSize = true;
            cbClearList.Location = new Point(9, 510);
            cbClearList.Name = "cbClearList";
            cbClearList.Size = new Size(140, 19);
            cbClearList.TabIndex = 3;
            cbClearList.Text = "Clear List after Import";
            cbClearList.UseVisualStyleBackColor = true;
            // 
            // btRemoveFiles
            // 
            btRemoveFiles.Location = new Point(166, 542);
            btRemoveFiles.Name = "btRemoveFiles";
            btRemoveFiles.Size = new Size(133, 35);
            btRemoveFiles.TabIndex = 2;
            btRemoveFiles.Text = "&Remove File(s)";
            btRemoveFiles.UseVisualStyleBackColor = true;
            btRemoveFiles.Click += btRemoveFiles_Click;
            // 
            // btAddFiles
            // 
            btAddFiles.Location = new Point(9, 542);
            btAddFiles.Name = "btAddFiles";
            btAddFiles.Size = new Size(133, 35);
            btAddFiles.TabIndex = 1;
            btAddFiles.Text = "&Add File(s)";
            btAddFiles.UseVisualStyleBackColor = true;
            btAddFiles.Click += btAddFiles_Click;
            // 
            // btDone
            // 
            btDone.Location = new Point(501, 554);
            btDone.Name = "btDone";
            btDone.Size = new Size(133, 35);
            btDone.TabIndex = 4;
            btDone.Text = "&Done";
            btDone.UseVisualStyleBackColor = true;
            btDone.Click += btDone_Click;
            // 
            // btImport
            // 
            btImport.Location = new Point(344, 554);
            btImport.Name = "btImport";
            btImport.Size = new Size(133, 35);
            btImport.TabIndex = 3;
            btImport.Text = "&Import";
            btImport.UseVisualStyleBackColor = true;
            btImport.Click += btImport_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tbFolderName);
            groupBox2.Location = new Point(334, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(310, 56);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Folder Name";
            // 
            // tbFolderName
            // 
            tbFolderName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFolderName.Location = new Point(10, 20);
            tbFolderName.Name = "tbFolderName";
            tbFolderName.Size = new Size(290, 23);
            tbFolderName.TabIndex = 0;
            // 
            // lbInstruct
            // 
            lbInstruct.Dock = DockStyle.Fill;
            lbInstruct.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbInstruct.Location = new Point(3, 19);
            lbInstruct.Name = "lbInstruct";
            lbInstruct.Size = new Size(304, 452);
            lbInstruct.TabIndex = 0;
            lbInstruct.Text = "lbInstruct";
            lbInstruct.UseMnemonic = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbInstruct);
            groupBox3.Location = new Point(334, 74);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(310, 474);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Instructions";
            // 
            // ImportMapsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btDone;
            ClientSize = new Size(660, 611);
            Controls.Add(groupBox3);
            Controls.Add(btDone);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btImport);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportMapsWindow";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Import Maps";
            TopMost = true;
            FormClosing += ImportMapsWindow_FormClosing;
            Load += ImportMapsWindow_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbxFiles;
        private GroupBox groupBox1;
        private Button btAddFiles;
        private Button btRemoveFiles;
        private Button btDone;
        private Button btImport;
        private GroupBox groupBox2;
        private TextBox tbFolderName;
        private Label lbInstruct;
        private GroupBox groupBox3;
        internal CheckBox cbClearList;
        internal CheckBox cbImportSummary;
    }
}