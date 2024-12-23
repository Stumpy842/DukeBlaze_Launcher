namespace DragDukeLauncher
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
            this.NewFolderNameTextBox = new System.Windows.Forms.TextBox();
            this.CreateFolderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewFolderNameTextBox
            // 
            this.NewFolderNameTextBox.Location = new System.Drawing.Point(12, 30);
            this.NewFolderNameTextBox.Name = "NewFolderNameTextBox";
            this.NewFolderNameTextBox.Size = new System.Drawing.Size(350, 20);
            this.NewFolderNameTextBox.TabIndex = 0;
            // 
            // CreateFolderButton
            // 
            this.CreateFolderButton.Location = new System.Drawing.Point(274, 59);
            this.CreateFolderButton.Name = "CreateFolderButton";
            this.CreateFolderButton.Size = new System.Drawing.Size(88, 23);
            this.CreateFolderButton.TabIndex = 1;
            this.CreateFolderButton.Text = "Create";
            this.CreateFolderButton.UseVisualStyleBackColor = true;
            this.CreateFolderButton.Click += new System.EventHandler(this.CreateFolderButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // NewFolderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 94);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateFolderButton);
            this.Controls.Add(this.NewFolderNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(391, 133);
            this.MinimumSize = new System.Drawing.Size(391, 133);
            this.Name = "NewFolderWindow";
            this.Text = "Folder Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewFolderNameTextBox;
        private System.Windows.Forms.Button CreateFolderButton;
        private System.Windows.Forms.Label label1;
    }
}