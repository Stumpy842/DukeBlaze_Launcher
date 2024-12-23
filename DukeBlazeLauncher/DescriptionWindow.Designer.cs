namespace DragDukeLauncher
{
    partial class DescriptionWindow
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescriptionWindow));
            this.label3 = new System.Windows.Forms.Label();
            this.PresetDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.SavePresetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Preset description";
            // 
            // PresetDescriptionTextBox
            // 
            this.PresetDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PresetDescriptionTextBox.Location = new System.Drawing.Point(15, 25);
            this.PresetDescriptionTextBox.Name = "PresetDescriptionTextBox";
            this.PresetDescriptionTextBox.Size = new System.Drawing.Size(658, 445);
            this.PresetDescriptionTextBox.TabIndex = 22;
            this.PresetDescriptionTextBox.Text = "";
            // 
            // SavePresetButton
            // 
            this.SavePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePresetButton.Location = new System.Drawing.Point(553, 477);
            this.SavePresetButton.Name = "SavePresetButton";
            this.SavePresetButton.Size = new System.Drawing.Size(120, 23);
            this.SavePresetButton.TabIndex = 23;
            this.SavePresetButton.Text = "Save";
            this.SavePresetButton.UseVisualStyleBackColor = true;
            this.SavePresetButton.Click += new System.EventHandler(this.SavePresetButton_Click);
            // 
            // DescriptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 512);
            this.Controls.Add(this.SavePresetButton);
            this.Controls.Add(this.PresetDescriptionTextBox);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(701, 551);
            this.Name = "DescriptionWindow";
            this.Text = "Description";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox PresetDescriptionTextBox;
        private System.Windows.Forms.Button SavePresetButton;
    }
}