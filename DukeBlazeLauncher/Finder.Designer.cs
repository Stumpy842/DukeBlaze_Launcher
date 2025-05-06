namespace DukeBlazeLauncher
{
    partial class Finder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finder));
            label1 = new Label();
            tbFind = new TextBox();
            groupBox1 = new GroupBox();
            rbBoth = new RadioButton();
            rbFolder = new RadioButton();
            rbPreset = new RadioButton();
            groupBox2 = new GroupBox();
            btRegex = new Button();
            rbExact = new RadioButton();
            rbRegex = new RadioButton();
            rbNormal = new RadioButton();
            cbCase = new CheckBox();
            btFind = new Button();
            btClose = new Button();
            label2 = new Label();
            lbMatches = new Label();
            cbDirection = new CheckBox();
            cbWrap = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "&Find:";
            // 
            // tbFind
            // 
            tbFind.Location = new Point(48, 26);
            tbFind.Name = "tbFind";
            tbFind.PlaceholderText = "Name";
            tbFind.Size = new Size(282, 23);
            tbFind.TabIndex = 1;
            tbFind.Click += tbFind_Click;
            tbFind.TextChanged += tbFind_TextChanged;
            tbFind.Enter += tbFind_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbBoth);
            groupBox1.Controls.Add(rbFolder);
            groupBox1.Controls.Add(rbPreset);
            groupBox1.Location = new Point(6, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(141, 100);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Find In";
            // 
            // rbBoth
            // 
            rbBoth.AutoSize = true;
            rbBoth.Location = new Point(7, 71);
            rbBoth.Name = "rbBoth";
            rbBoth.Size = new Size(50, 19);
            rbBoth.TabIndex = 2;
            rbBoth.Text = "&Both";
            rbBoth.UseVisualStyleBackColor = true;
            rbBoth.CheckedChanged += Target_CheckedChanged;
            // 
            // rbFolder
            // 
            rbFolder.AutoSize = true;
            rbFolder.Location = new Point(7, 46);
            rbFolder.Name = "rbFolder";
            rbFolder.Size = new Size(91, 19);
            rbFolder.TabIndex = 1;
            rbFolder.Text = "F&older name";
            rbFolder.UseVisualStyleBackColor = true;
            rbFolder.CheckedChanged += Target_CheckedChanged;
            // 
            // rbPreset
            // 
            rbPreset.AutoSize = true;
            rbPreset.Checked = true;
            rbPreset.Location = new Point(7, 21);
            rbPreset.Name = "rbPreset";
            rbPreset.Size = new Size(90, 19);
            rbPreset.TabIndex = 0;
            rbPreset.TabStop = true;
            rbPreset.Text = "&Preset name";
            rbPreset.UseVisualStyleBackColor = true;
            rbPreset.CheckedChanged += Target_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btRegex);
            groupBox2.Controls.Add(rbExact);
            groupBox2.Controls.Add(rbRegex);
            groupBox2.Controls.Add(rbNormal);
            groupBox2.Location = new Point(155, 68);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(175, 100);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Search Mode";
            // 
            // btRegex
            // 
            btRegex.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btRegex.Location = new Point(144, 66);
            btRegex.Name = "btRegex";
            btRegex.Size = new Size(25, 25);
            btRegex.TabIndex = 3;
            btRegex.Text = "?";
            btRegex.UseVisualStyleBackColor = true;
            btRegex.Click += btRegex_Click;
            // 
            // rbExact
            // 
            rbExact.AutoSize = true;
            rbExact.Location = new Point(7, 46);
            rbExact.Name = "rbExact";
            rbExact.Size = new Size(89, 19);
            rbExact.TabIndex = 1;
            rbExact.TabStop = true;
            rbExact.Text = "&Whole word";
            rbExact.UseVisualStyleBackColor = true;
            rbExact.CheckedChanged += Mode_CheckedChanged;
            // 
            // rbRegex
            // 
            rbRegex.AutoSize = true;
            rbRegex.Location = new Point(7, 71);
            rbRegex.Name = "rbRegex";
            rbRegex.Size = new Size(123, 19);
            rbRegex.TabIndex = 2;
            rbRegex.Text = "&Regular expression";
            rbRegex.UseVisualStyleBackColor = true;
            rbRegex.CheckedChanged += Mode_CheckedChanged;
            // 
            // rbNormal
            // 
            rbNormal.AutoSize = true;
            rbNormal.Checked = true;
            rbNormal.Location = new Point(7, 21);
            rbNormal.Name = "rbNormal";
            rbNormal.Size = new Size(65, 19);
            rbNormal.TabIndex = 0;
            rbNormal.TabStop = true;
            rbNormal.Text = "&Normal";
            rbNormal.UseVisualStyleBackColor = true;
            rbNormal.CheckedChanged += Mode_CheckedChanged;
            // 
            // cbCase
            // 
            cbCase.AutoSize = true;
            cbCase.Location = new Point(13, 180);
            cbCase.Name = "cbCase";
            cbCase.Size = new Size(86, 19);
            cbCase.TabIndex = 4;
            cbCase.Text = "&Match case";
            cbCase.UseVisualStyleBackColor = true;
            cbCase.CheckedChanged += cbCase_CheckedChanged;
            // 
            // btFind
            // 
            btFind.Location = new Point(349, 26);
            btFind.Name = "btFind";
            btFind.Size = new Size(120, 28);
            btFind.TabIndex = 5;
            btFind.Text = "Find";
            btFind.UseVisualStyleBackColor = true;
            btFind.Click += btFind_Click;
            // 
            // btClose
            // 
            btClose.Location = new Point(349, 68);
            btClose.Name = "btClose";
            btClose.Size = new Size(120, 28);
            btClose.TabIndex = 6;
            btClose.Text = "&Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(12, 212);
            label2.Name = "label2";
            label2.Size = new Size(457, 1);
            label2.TabIndex = 7;
            label2.Text = "label2";
            // 
            // lbMatches
            // 
            lbMatches.AutoSize = true;
            lbMatches.Location = new Point(13, 228);
            lbMatches.Name = "lbMatches";
            lbMatches.Size = new Size(41, 15);
            lbMatches.TabIndex = 8;
            lbMatches.Text = "Match";
            // 
            // cbDirection
            // 
            cbDirection.AutoSize = true;
            cbDirection.Location = new Point(136, 180);
            cbDirection.Name = "cbDirection";
            cbDirection.Size = new Size(127, 19);
            cbDirection.TabIndex = 9;
            cbDirection.Text = "Backward &direciton";
            cbDirection.UseVisualStyleBackColor = true;
            cbDirection.CheckedChanged += cbDirection_CheckedChanged;
            // 
            // cbWrap
            // 
            cbWrap.AutoSize = true;
            cbWrap.Location = new Point(300, 180);
            cbWrap.Name = "cbWrap";
            cbWrap.Size = new Size(95, 19);
            cbWrap.TabIndex = 10;
            cbWrap.Text = "Wra&p around";
            cbWrap.UseVisualStyleBackColor = true;
            cbWrap.CheckedChanged += cbWrap_CheckChanged;
            // 
            // Finder
            // 
            AcceptButton = btFind;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btClose;
            ClientSize = new Size(488, 257);
            Controls.Add(cbWrap);
            Controls.Add(cbDirection);
            Controls.Add(lbMatches);
            Controls.Add(label2);
            Controls.Add(btClose);
            Controls.Add(btFind);
            Controls.Add(cbCase);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(tbFind);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Finder";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Find";
            FormClosing += Finder_FormClosing;
            Load += Finder_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbFind;
        private GroupBox groupBox1;
        private RadioButton rbBoth;
        private RadioButton rbFolder;
        private RadioButton rbPreset;
        private GroupBox groupBox2;
        private RadioButton rbRegex;
        private RadioButton rbNormal;
        private CheckBox cbCase;
        private Button btFind;
        private Button btClose;
        private RadioButton rbExact;
        private Label label2;
        private Label lbMatches;
        private CheckBox cbDirection;
        private CheckBox cbWrap;
        private Button btRegex;
    }
}