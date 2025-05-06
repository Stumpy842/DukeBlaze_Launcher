using DukeBlazeLauncher.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DukeBlazeLauncher
{
    public partial class Finder : Form
    {

        private const string regexHelp = @"https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference";
        private readonly string title = MainWindow.MyTitle;
        private readonly TreeView _presetTree;
        public enum Mode
        {
            Normal,
            Exact,
            Regex
        }
        private Mode _mode;

        public enum Target
        {
            Preset,
            Folder,
            Both
        }
        private Target _target;

        private readonly Color textColor = SystemColors.ControlText;
        private readonly Color warnColor = Color.Red;
        private List<TreeNode> _nodes = [];
        private bool _case;
        private bool _backward;
        private bool _oldback;
        private bool _wrap;
        private Regex rg;
        private int count = 0;
        private bool _done = false;
        private string find;
        private string msg;

        public Finder(TreeView presetTree)
        {
            InitializeComponent();
            _presetTree = presetTree;
            btFind.Enabled = false;
            lbMatches.Text = "";
        }

        private void Finder_Load(object sender, EventArgs e)
        {
            _mode = Settings.CurrentSettings.findMode;
            rbNormal.Checked = _mode == Mode.Normal;
            rbExact.Checked = _mode == Mode.Exact;
            rbRegex.Checked = _mode == Mode.Regex;

            _target = Settings.CurrentSettings.findTarget;
            rbPreset.Checked = _target == Target.Preset;
            rbFolder.Checked = _target == Target.Folder;
            rbBoth.Checked = _target == Target.Both;

            _case = Settings.CurrentSettings.findMatchCase;
            cbCase.Checked = _case;

            _backward = Settings.CurrentSettings.findBackward;
            cbDirection.Checked = _backward;

            _wrap = Settings.CurrentSettings.findWrap;
            cbWrap.Checked = _wrap;
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            Find(ref count);
        }

        private void Find(ref int count)
        {
            if (count > 0)
            {
                if (_backward != _oldback)
                {
                    if (count == _nodes.Count) count--;
                    else count = _nodes.Count - count - 1;
                    if (count <= 0) count = _nodes.Count;
                    _done = false;
                }

                if (_done)
                {
                    msg = _backward ? "Beginning" : "End";
                    lbMatches.ForeColor = warnColor;
                    lbMatches.Text = $"{msg} reached";
                    return;
                }

                lbMatches.ForeColor = textColor; ;
                if (_backward)
                {
                    lbMatches.Text = $"Match {count} of {_nodes.Count}";
                    _presetTree.SelectedNode = _nodes[--count];
                }
                else
                {
                    _presetTree.SelectedNode = _nodes[^(count--)];
                    lbMatches.Text = $"Match {_nodes.Count - count} of {_nodes.Count}";
                }

                if (count == 0)
                {
                    count = _nodes.Count;
                    _done = !_wrap;
                }

                _oldback = _backward;
                return;
            }

            _nodes.Clear();
            find = tbFind.Text;

            if (_mode == Mode.Regex)
            {
                try
                {
                    if (_case)
                        rg = new Regex(find);
                    else
                        rg = new Regex(find, RegexOptions.IgnoreCase);

                }
                catch (Exception ex)
                {
                    Tools.ShowTaskDlg(this, title, "Invalid regular expression","", ex.ToString(), null, -1, TaskDialogIcon.Error);
                    return;
                }
            }

            foreach (TreeNode node in TreeViewTools.Collect(_presetTree.Nodes))
            {
                if (_target == Target.Preset && node.Text.StartsWith(Tools.FolderIcon)) { continue; }
                if (_target == Target.Folder && !node.Text.StartsWith(Tools.FolderIcon)) { continue; }
                if (node.Parent is null) { continue; }

                string name = node.Text;
                if (name.StartsWith(Tools.FolderIcon)) name = name[3..];

                if (_mode == Mode.Exact)
                {
                    if (_case)
                    {
                        if (find == name) _nodes.Add(node);
                    }
                    else
                    {
                        if (find.Equals(name, StringComparison.OrdinalIgnoreCase)) _nodes.Add(node);
                    }
                }
                else if (_mode == Mode.Normal)
                {
                    if (_case)
                    {
                        if (name.Contains(find)) _nodes.Add(node);
                    }
                    else
                    {
                        if (name.Contains(find, StringComparison.OrdinalIgnoreCase)) _nodes.Add(node);
                    }
                }
                else
                {
                    if (rg.IsMatch(name)) _nodes.Add(node);
                }
            }

            count = _nodes.Count;
            if (count == 0)
            {
                lbMatches.ForeColor = warnColor;
                lbMatches.Text = "No matches found";
            }
            else
            {
                _oldback = _backward;
                Find(ref count);
            }
        }

        private void Reset()
        {
            count = 0;
            lbMatches.Text = "";
            _done = false;
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            btFind.Enabled = tbFind.Text.Length > 0;
            Reset();
        }

        private void tbFind_Click(object sender, EventArgs e)
        {
            tbFind.SelectAll();
        }

        private void Target_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPreset.Checked) { _target = Target.Preset; }
            else if (rbFolder.Checked) { _target = Target.Folder; }
            else if (rbBoth.Checked) { _target = Target.Both; }
            Reset();
        }

        private void Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNormal.Checked) { _mode = Mode.Normal; }
            else if (rbExact.Checked) { _mode = Mode.Exact; }
            else if (rbRegex.Checked) { _mode = Mode.Regex; }
            Reset();
        }

        private void cbCase_CheckedChanged(object sender, EventArgs e)
        {
            _case = cbCase.Checked;
            Reset();
        }

        private void cbDirection_CheckedChanged(object sender, EventArgs e)
        {
            _backward = cbDirection.Checked;
        }

        private void cbWrap_CheckChanged(object sender, EventArgs e)
        {
            _wrap = cbWrap.Checked;
            if (_wrap) { _done = false; }
            else
            {
                if (_backward) { _done = count == _nodes.Count; }
                else { _done = count == 1; }
            }
        }

        private void SaveSettings()
        {
            Settings.CurrentSettings.findMode = _mode;
            Settings.CurrentSettings.findTarget = _target;
            Settings.CurrentSettings.findMatchCase = _case;
            Settings.CurrentSettings.findBackward = _backward;
            Settings.CurrentSettings.findWrap = _wrap;
            Settings.Save(false);
        }

        private void Finder_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btRegex_Click(object sender, EventArgs e)
        {
            try
            {
                using Process ps = Process.Start(new ProcessStartInfo(regexHelp) { UseShellExecute = true })!;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"***{ex}");
               Tools.ShowTaskDlg(this, title, $@"Cannot start {regexHelp}", "", ex.ToString(), null, -1, TaskDialogIcon.Error);
            }
        }
    }
}
