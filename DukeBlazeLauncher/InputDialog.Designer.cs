namespace DragDukeLauncher
{
    partial class InputDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDialog));
            Promptlabel = new Label();
            Pathtextbox = new TextBox();
            Savebutton = new Button();
            Cancelbutton = new Button();
            SuspendLayout();
            // 
            // Promptlabel
            // 
            Promptlabel.AutoSize = true;
            Promptlabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Promptlabel.Location = new Point(14, 13);
            Promptlabel.Margin = new Padding(4, 0, 4, 0);
            Promptlabel.Name = "Promptlabel";
            Promptlabel.Size = new Size(81, 15);
            Promptlabel.TabIndex = 0;
            Promptlabel.Text = "Save to Folder";
            // 
            // Pathtextbox
            // 
            Pathtextbox.Location = new Point(14, 35);
            Pathtextbox.Margin = new Padding(4, 3, 4, 3);
            Pathtextbox.Name = "Pathtextbox";
            Pathtextbox.Size = new Size(408, 23);
            Pathtextbox.TabIndex = 1;
            // 
            // Savebutton
            // 
            Savebutton.AutoSize = true;
            Savebutton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Savebutton.Location = new Point(238, 69);
            Savebutton.Margin = new Padding(4, 3, 4, 3);
            Savebutton.Name = "Savebutton";
            Savebutton.Size = new Size(88, 27);
            Savebutton.TabIndex = 2;
            Savebutton.Text = "&Save";
            Savebutton.UseVisualStyleBackColor = true;
            Savebutton.Click += Savebutton_Click;
            // 
            // Cancelbutton
            // 
            Cancelbutton.Location = new Point(334, 69);
            Cancelbutton.Margin = new Padding(4, 3, 4, 3);
            Cancelbutton.Name = "Cancelbutton";
            Cancelbutton.Size = new Size(88, 27);
            Cancelbutton.TabIndex = 3;
            Cancelbutton.Text = "Cancel";
            Cancelbutton.UseVisualStyleBackColor = true;
            Cancelbutton.Click += Cancelbutton_Click;
            // 
            // InputDialog
            // 
            AcceptButton = Savebutton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 108);
            Controls.Add(Cancelbutton);
            Controls.Add(Savebutton);
            Controls.Add(Pathtextbox);
            Controls.Add(Promptlabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "InputDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Save";
            TopMost = true;
            KeyDown += InputDialog_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Promptlabel;
        private TextBox Pathtextbox;
        private Button Savebutton;
        private Button Cancelbutton;
    }
}
