using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DukeBlazeLauncher.Extensions
{
    internal static class Tools
    {
// Definitions for LauncherData strings
// Steve - 01/18/2025 20:45:19
        // LauncherData definitions
        internal const string ldFolder = "LauncherData";
        internal const string dExt = ".dat";

        // Names of LauncherData files
        internal const int datFileCount = 4; // Number of .dat files
        internal const string dDesc = $"Description{dExt}";
        internal const string dPre = $"Presets{dExt}";
        internal const string dPset = $"PresetsSettings{dExt}";
        internal const string dSet = $"Settings{dExt}";

        // Directory for Preset Load/Save
        internal const string SavedPresetsDir = "SavedPresets";

        internal const string FolderIcon = "📁";
        internal const string Slash = @"\";

        // Delay time for TimedMessage()
        private static readonly int WaitTime = 5;

        internal static async void WaitSomeTime(int delayTime, Action action)
        {
            await Task.Delay(delayTime);
            action?.Invoke();
        }

        internal static string GetRelativePath(string path)
        {
            return path.Replace(AppDomain.CurrentDomain.BaseDirectory, String.Empty);
        }

        internal static string GetPathWithAppDomain(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

        // Provides a MessageBox display which times out after a delay
        public static async void TimedMessage(string message, string title, Form owner = null, MessageBoxIcon mi = MessageBoxIcon.Error, int time = -1)
        {
            if (time < 0) time = WaitTime;
            // A new form as owner for the MessageBox
            using var invOwner = new Form { Visible = false };
            // Force the creation of the window handle
            // Otherwise the BeginInvoke will not work
            var handle = invOwner.Handle;
            invOwner.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
            {
                if (owner is not null) using (new CenterWinDialog(owner))
                    { MessageBox.Show(invOwner, text: message, title, MessageBoxButtons.OK, mi); }
                else { MessageBox.Show(invOwner, text: message, title, MessageBoxButtons.OK, mi); }
            });
            await Task.Delay(TimeSpan.FromSeconds(time));
            // When the form is disposed the MessageBox is too!
            invOwner.Dispose();
        }

        internal static TaskDialogButton ShowTaskDlg(Form owner, string caption, string heading, string footnote = "",
            string expandertext = "", TaskDialogButtonCollection buttons = null, int defaultbutton = -1, TaskDialogIcon icon = null)
        {
            TaskDialogPage TaskError = new ()
            {
                Caption = caption,
                Heading = heading,
                AllowCancel = true,
                AllowMinimize = false,
                SizeToContent = true
            };
            if (footnote != "") TaskError.Footnote = new () { Text = footnote };
            if (expandertext != "") TaskError.Expander = new() { Text = expandertext, Position = TaskDialogExpanderPosition.AfterFootnote };
            if (buttons is not null)
            {
                TaskError.Buttons = buttons;
                if ((defaultbutton > -1) && (defaultbutton < buttons.Count))
                    TaskError.DefaultButton = buttons[defaultbutton];
            }
            if (icon is not null) TaskError.Icon = icon;

            if (owner is null) return TaskDialog.ShowDialog(TaskError);
                else return TaskDialog.ShowDialog(owner, TaskError, TaskDialogStartupLocation.CenterOwner); 
        }

        internal static string NewName(string Name, TreeNodeCollection Nodes, int Count = 1, bool Folder = false)
        {
            bool done = true;
            // Index past the Folder icon and space
            int c = Folder ? 3 : 0;
            foreach (TreeNode node in TreeViewTools.Collect(Nodes))
            {
                if (!Folder && node.Text.StartsWith(Tools.FolderIcon)) { continue; }
                if (Folder && !node.Text.StartsWith(Tools.FolderIcon)) { continue; }
                if (Name == node.Text[c..])
                {
                    // Name matches old name so get a new name
                    int i = Name.LastIndexOf('_');
                    // Does Name contain _ char?
                    if (i > -1)
                    {
                        // Yes, _ char was found
                        //Debug.WriteLine("***Underscore found");
                        string sSuffix = Name[(i + 1)..];
                        //Debug.WriteLine($"***Suffix: '{sSuffix}'");
                        // Try to parse suffix as integer
                        if (int.TryParse(sSuffix, out int iSuffix))
                        {
                            // Suffix is integer, so replace it with next higher integer
                            Name = $"{Name[..i]}_{++iSuffix}";
                            //Debug.WriteLine("***Suffix is integer");
                            //Debug.WriteLine($"***New Name: '{Name}'");
                        }
                        else
                        {
                            // Suffix in NOT integer, just add _Count
                            //Debug.WriteLine("***Suffix NOT an integer");
                            //Debug.WriteLine($"***Count: '{Count.ToString()}'");
                            Name = $"{Name}_{Count.ToString()}";
                        }
                    }
                    else
                    {
                        // No, _ char not found
                        Name = $"{Name}_{Count.ToString()}";
                        //Debug.WriteLine($"***No _ char found: '{Name}'");
                    }
                    done = false;
                }
                if (!done) break;
            }
            if (!done) Name = NewName(Name, Nodes, ++Count, Folder);
            return Name;
        }

        // Color thingie
        // Steve - 02/06/2025 21:28:41
        internal static Color GetContrastColor(Color color)
        {
            return (color.R * 0.299M) + (color.G * 0.587M) + (color.B * 0.114M) > 149 ?
                SystemColors.WindowText :
                SystemColors.HighlightText;
        }

        // Write warning file to LauncherData folder
        // Steve - 02/06/2025 20:14:00
        internal static void WriteWarningFile()
        {
            string Warning = $"This folder contains the {datFileCount} files {dDesc}, {dPre}, {dPset} and {dSet}, which contain the " +
                $"data and settings necessary for proper operation of {MainWindow.MyTitle}. Please do not modify the contents of this folder.";
            string Fname = "!DO NOT MODIFY THE CONTENTS OF THIS FOLDER.txt";
            //Debug.WriteLine($"***Warning file pathname='{GetPathWithAppDomain($@"{ldFolder}\{Fname}")}'");
            try
            {
                File.WriteAllText(GetPathWithAppDomain($@"{ldFolder}\{Fname}"), Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File write error\n{ex}", MainWindow.MyTitle);
            }       
        }

        internal static bool GetTextFromResourceFile(string TextFilename, out string Text, bool ParagraphBreak = true)
        {
            string errText = $"Failed to read {TextFilename}";
            bool ret = false;
            var assem = Assembly.GetExecutingAssembly();
            string myNamespace = assem.GetName().Name;
            try
            {
                using Stream inst = assem.GetManifestResourceStream($"{myNamespace}.{TextFilename}");
                if (inst is not null)
                {
                    using StreamReader streamReader = new(inst);
                    string line;
                    StringBuilder sb = new();
                    while ((line = streamReader.ReadLine()) is not null)
                        sb.Append(line == "" && ParagraphBreak ? "\n\n" : line);
                    Text = sb.ToString();
                    ret = true;
                }
                else
                {
                    Text = errText;
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                Text = $"{errText}\n{ex}";
                ret = false;
            }
            return ret;
        }
    }
}

