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
            label3 = new Label();
            PresetDescriptionTextBox = new RichTextBox();
            CancelPresetButton = new Button();
            SavePresetButton = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 10);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 0;
            label3.Text = "Preset description";
            // 
            // PresetDescriptionTextBox
            // 
            PresetDescriptionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PresetDescriptionTextBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PresetDescriptionTextBox.Location = new Point(18, 29);
            PresetDescriptionTextBox.Margin = new Padding(4, 3, 4, 3);
            PresetDescriptionTextBox.Name = "PresetDescriptionTextBox";
            PresetDescriptionTextBox.Size = new Size(767, 513);
            PresetDescriptionTextBox.TabIndex = 1;
            PresetDescriptionTextBox.Text = "";
            // 
            // CancelPresetButton
            // 
            CancelPresetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelPresetButton.Location = new Point(645, 550);
            CancelPresetButton.Margin = new Padding(4, 3, 4, 3);
            CancelPresetButton.Name = "CancelPresetButton";
            CancelPresetButton.Size = new Size(140, 27);
            CancelPresetButton.TabIndex = 3;
            CancelPresetButton.Text = "&Cancel";
            CancelPresetButton.UseVisualStyleBackColor = true;
            CancelPresetButton.Click += CancelPresetButton_Click;
            // 
            // SavePresetButton
            // 
            SavePresetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SavePresetButton.Location = new Point(497, 550);
            SavePresetButton.Margin = new Padding(4, 3, 4, 3);
            SavePresetButton.Name = "SavePresetButton";
            SavePresetButton.Size = new Size(140, 27);
            SavePresetButton.TabIndex = 2;
            SavePresetButton.Text = "&Save";
            SavePresetButton.UseVisualStyleBackColor = true;
            SavePresetButton.Click += SavePresetButton_Click;
            // 
            // DescriptionWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 591);
            Controls.Add(SavePresetButton);
            Controls.Add(CancelPresetButton);
            Controls.Add(PresetDescriptionTextBox);
            Controls.Add(label3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MinimizeBox = false;
            MinimumSize = new Size(815, 630);
            Name = "DescriptionWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Description";
            KeyDown += DescriptionWindow_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox PresetDescriptionTextBox;
        private System.Windows.Forms.Button CancelPresetButton;
        private Button SavePresetButton;
    }
}