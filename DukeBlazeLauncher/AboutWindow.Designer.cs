namespace DukeBlazeLauncher
{
    partial class AboutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
            label1 = new Label();
            VersionLabel = new Label();
            label5 = new Label();
            GitHubPageLink = new Label();
            label6 = new Label();
            label3 = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(92, 135);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(176, 20);
            label1.TabIndex = 0;
            label1.Text = "DukeBlaze Launcher";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new Point(153, 158);
            VersionLabel.Margin = new Padding(4, 0, 4, 0);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(66, 15);
            VersionLabel.TabIndex = 1;
            VersionLabel.Text = "Version: 0.0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(93, 193);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(233, 15);
            label5.TabIndex = 4;
            label5.Text = "Andrei Ivashentsev (dragzxnd, doom wads)";
            // 
            // GitHubPageLink
            // 
            GitHubPageLink.AutoSize = true;
            GitHubPageLink.Cursor = Cursors.Hand;
            GitHubPageLink.ForeColor = SystemColors.HotTrack;
            GitHubPageLink.Location = new Point(93, 247);
            GitHubPageLink.Margin = new Padding(4, 0, 4, 0);
            GitHubPageLink.Name = "GitHubPageLink";
            GitHubPageLink.Size = new Size(230, 15);
            GitHubPageLink.TabIndex = 6;
            GitHubPageLink.Text = "github.com/dragxnd/DukeBlaze_Launcher";
            GitHubPageLink.Click += GitHubPage_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 247);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 5;
            label6.Text = "Page:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(41, 193);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(41, 13);
            label3.TabIndex = 2;
            label3.Text = "Author:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(41, 282);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.MaximumSize = new Size(303, 0);
            label7.Name = "label7";
            label7.Size = new Size(301, 45);
            label7.TabIndex = 7;
            label7.Text = "DukeBlaze is a Launcher for eDuke32 that will allow you to easily run custom maps and modifications, and build your own collection.";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(135, 14);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(113, 107);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 220);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 9;
            label2.Text = "Fork by:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 220);
            label4.Name = "label4";
            label4.Size = new Size(155, 15);
            label4.TabIndex = 10;
            label4.Text = "Steven J Stover (Stumpy842)";
            // 
            // AboutWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 356);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            Controls.Add(GitHubPageLink);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(VersionLabel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            MaximumSize = new Size(406, 395);
            MinimumSize = new Size(406, 395);
            Name = "AboutWindow";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            KeyDown += AboutWindow_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label GitHubPageLink;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Label label2;
        private Label label4;
    }
}