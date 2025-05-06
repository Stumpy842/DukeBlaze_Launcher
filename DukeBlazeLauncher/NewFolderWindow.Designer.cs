namespace DukeBlazeLauncher
{
    partial class NewFolderWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFolderWindow));
            NewFolderNameTextBox = new TextBox();
            CancelFolderButton = new Button();
            label1 = new Label();
            CreateFolderButton = new Button();
            SuspendLayout();
            // 
            // NewFolderNameTextBox
            // 
            NewFolderNameTextBox.Location = new Point(14, 35);
            NewFolderNameTextBox.Margin = new Padding(4, 3, 4, 3);
            NewFolderNameTextBox.Name = "NewFolderNameTextBox";
            NewFolderNameTextBox.Size = new Size(408, 23);
            NewFolderNameTextBox.TabIndex = 1;
            NewFolderNameTextBox.TextChanged += NewFolderNameTextBox_TextChanged;
            // 
            // CancelFolderButton
            // 
            CancelFolderButton.Location = new Point(334, 69);
            CancelFolderButton.Margin = new Padding(4, 3, 4, 3);
            CancelFolderButton.Name = "CancelFolderButton";
            CancelFolderButton.Size = new Size(88, 27);
            CancelFolderButton.TabIndex = 3;
            CancelFolderButton.Text = "Cancel";
            CancelFolderButton.UseVisualStyleBackColor = true;
            CancelFolderButton.Click += CancelFolderButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // CreateFolderButton
            // 
            CreateFolderButton.Enabled = false;
            CreateFolderButton.Location = new Point(238, 69);
            CreateFolderButton.Margin = new Padding(4, 3, 4, 3);
            CreateFolderButton.Name = "CreateFolderButton";
            CreateFolderButton.Size = new Size(88, 27);
            CreateFolderButton.TabIndex = 2;
            CreateFolderButton.Text = "&Create";
            CreateFolderButton.UseVisualStyleBackColor = true;
            CreateFolderButton.Click += CreateFolderButton_Click;
            // 
            // NewFolderWindow
            // 
            AcceptButton = CreateFolderButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 108);
            Controls.Add(label1);
            Controls.Add(CreateFolderButton);
            Controls.Add(CancelFolderButton);
            Controls.Add(NewFolderNameTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(454, 147);
            MinimizeBox = false;
            MinimumSize = new Size(454, 147);
            Name = "NewFolderWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Folder Name";
            KeyDown += NewFolderWindow_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox NewFolderNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelFolderButton;
        private Button CreateFolderButton;
    }
}
