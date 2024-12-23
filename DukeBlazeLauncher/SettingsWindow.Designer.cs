namespace DragDukeLauncher
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
            this.label3 = new System.Windows.Forms.Label();
            this.ExePathTextBox = new System.Windows.Forms.TextBox();
            this.ExeBrowseButton = new System.Windows.Forms.Button();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Eduke32.exe path";
            // 
            // ExePathTextBox
            // 
            this.ExePathTextBox.Location = new System.Drawing.Point(19, 32);
            this.ExePathTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.ExePathTextBox.Name = "ExePathTextBox";
            this.ExePathTextBox.Size = new System.Drawing.Size(342, 20);
            this.ExePathTextBox.TabIndex = 3;
            // 
            // ExeBrowseButton
            // 
            this.ExeBrowseButton.Location = new System.Drawing.Point(18, 55);
            this.ExeBrowseButton.Margin = new System.Windows.Forms.Padding(9, 0, 3, 3);
            this.ExeBrowseButton.Name = "ExeBrowseButton";
            this.ExeBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ExeBrowseButton.TabIndex = 5;
            this.ExeBrowseButton.Text = "Browse";
            this.ExeBrowseButton.UseVisualStyleBackColor = true;
            this.ExeBrowseButton.Click += new System.EventHandler(this.ExeBrowseButton_Click);
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(18, 107);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(341, 21);
            this.LanguageComboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Language (WIP)";
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Location = new System.Drawing.Point(286, 147);
            this.SaveSettingsButton.Margin = new System.Windows.Forms.Padding(9, 0, 3, 3);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.SaveSettingsButton.TabIndex = 8;
            this.SaveSettingsButton.Text = "Save";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 191);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExePathTextBox);
            this.Controls.Add(this.ExeBrowseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(398, 230);
            this.MinimumSize = new System.Drawing.Size(398, 230);
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox ExePathTextBox;
        private System.Windows.Forms.Button ExeBrowseButton;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveSettingsButton;
    }
}