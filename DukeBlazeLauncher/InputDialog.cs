using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DukeBlazeLauncher
{
    internal partial class InputDialog : Form
    {
        internal InputDialog()
        {
            InitializeComponent();
        }

        internal DialogResult ShowDialog(out string Value, string lblPrompt = "Save Presets to Folder", 
            string btnText = "&Save", string frmTitle = "Save Presets")
        {
            InputDialog x = new InputDialog();
            x.Promptlabel.Text = lblPrompt;
            x.Savebutton.Text = btnText;
            x.Text = frmTitle;
            DialogResult result = x.ShowDialog();
            Value = x.Pathtextbox.Text;
            return result;
        }
        private void InputDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
