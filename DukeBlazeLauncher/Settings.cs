using DukeBlazeLauncher.Extensions;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace DukeBlazeLauncher
{
    public static class Settings
    {
        private const string SettingsFilePath = $@"{Tools.ldFolder}\{Tools.dSet}";
        private static SettingsWindow _settingsWindow = null;
        public static SettingsData CurrentSettings { get; private set; } = new SettingsData();
        private static readonly string title = MainWindow.MyTitle;
        private const string DefaultExePath = "eduke32.exe";
        public static string DefaultEditorPath { get; private set; } = "notepad.exe";

        // Default Custom Colors
        public static readonly int[] DefaultCustomColors = [6916092, 15195440, 16107657, 1836924,
                3758726, 10526880, 7526079, 7405793, 6945974, 241502, 2296476, 5130294,
                3102017, 7324121, 14993507, 11730944];

        // Enum for Prevent Name Collisions
        public enum PC { Allow, Folder, Global}

        public static void Init(SettingsWindow settingsWindow)
        {
            _settingsWindow = settingsWindow;
        }

        private static PC GetPC(string pc)
        {
            if (pc == nameof(CurrentSettings.PreventPresetCol))
            {
                if (_settingsWindow.rbPresetAll.Checked) return PC.Allow;
                if (_settingsWindow.rbPresetFolder.Checked) return PC.Folder;
                return PC.Global;
            }
            else if (pc == nameof(CurrentSettings.PreventFolderCol))
            {
                if (_settingsWindow.rbFolderAll.Checked) return PC.Allow;
                if (_settingsWindow.rbFolderParent.Checked) return PC.Folder;
                return PC.Global;
            }
            else throw new ArgumentException("Unknown parameter", pc.ToString());
        }

        public static void Save(bool SaveAll = true)
        {
            if (SaveAll)
            {
                string txt = _settingsWindow.ExePathTextBox.Text;
                CurrentSettings.ExePath = txt.Length > 0 ? txt : DefaultExePath;
                txt = _settingsWindow.tbNotepadPath.Text;
                CurrentSettings.notepadPath = txt.Length > 0 ? txt : DefaultEditorPath;
                CurrentSettings.optSaveUseBrowser = _settingsWindow.rbBrowserSave.Checked;
                CurrentSettings.PreventPresetCol = GetPC(nameof(CurrentSettings.PreventPresetCol));
                CurrentSettings.PreventFolderCol = GetPC(nameof(CurrentSettings.PreventFolderCol));
                CurrentSettings.optUseColor = _settingsWindow.cbUseColor.Checked;
                CurrentSettings.CurrentColor = _settingsWindow.CurrentColor;
                CurrentSettings.myCustomColors = _settingsWindow.myCustomColors;
                CurrentSettings.optExpandTree = _settingsWindow.cbExpandTree.Checked;
                CurrentSettings.optConfirmOverWrite = _settingsWindow.cbConfirmOverWrite.Checked;
                CurrentSettings.optConfirmDelete = _settingsWindow.cbConfirmDelete.Checked;
                CurrentSettings.optUseNotepad = _settingsWindow.cbUseNotepad.Checked;
                CurrentSettings.optAutoName = _settingsWindow.cbAutoName.Checked;
            }

            try
            {
                if (!File.Exists(SettingsFilePath)) File.WriteAllText(Tools.GetRelativePath(SettingsFilePath), String.Empty);
                string savedText = JsonConvert.SerializeObject(CurrentSettings);
                File.WriteAllText(SettingsFilePath, savedText);
            }
            catch //(Exception ex)
            {
                MessageBox.Show( "Error saving settings", $"{title} - File Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Debug.WriteLine($"***{ex}");
            }
        }

        public static void Load()
        {
            SettingsData newItems = null;
            try
            {
                if (!File.Exists(SettingsFilePath)) File.WriteAllText(SettingsFilePath, String.Empty);
                var fileText = File.ReadAllText(SettingsFilePath);
                newItems = JsonConvert.DeserializeObject<SettingsData>(fileText);
            }
            catch (Exception ex)
            {
                if (_settingsWindow is not null)
                {
                    Tools.ShowTaskDlg(null, title, "Settings File Error", "There was an error loading or creating the Settings",
                        ex.ToString()); 
                }
                //Debug.WriteLine($"***{ex}");
            }
            finally
            {
                if (newItems is not null)
                {
                    CurrentSettings = newItems;
                }
                else
                {
                    if (_settingsWindow is not null)
                    {
                        Tools.TimedMessage("Error loading settings, using defaults.", $"{title} - File Load Error"); 
                    }
                }

                if (_settingsWindow is not null)
                {
                    _settingsWindow.ExePathTextBox.Text = CurrentSettings.ExePath;
                    _settingsWindow.tbNotepadPath.Text = CurrentSettings.notepadPath;
                    _settingsWindow.rbSimpleSave.Checked = !CurrentSettings.optSaveUseBrowser;
                    _settingsWindow.rbBrowserSave.Checked = CurrentSettings.optSaveUseBrowser;
                    _settingsWindow.rbPresetAll.Checked = CurrentSettings.PreventPresetCol == PC.Allow;
                    _settingsWindow.rbPresetFolder.Checked = CurrentSettings.PreventPresetCol == PC.Folder;
                    _settingsWindow.rbPresetGlobal.Checked = CurrentSettings.PreventPresetCol == PC.Global;
                    _settingsWindow.rbFolderAll.Checked = CurrentSettings.PreventFolderCol == PC.Allow;
                    _settingsWindow.rbFolderParent.Checked = CurrentSettings.PreventFolderCol == PC.Folder;
                    _settingsWindow.rbFolderGlobal.Checked = CurrentSettings.PreventFolderCol == PC.Global;
                    _settingsWindow.cbUseColor.Checked = CurrentSettings.optUseColor;
                    _settingsWindow.cbExpandTree.Checked = CurrentSettings.optExpandTree;
                    _settingsWindow.cbConfirmOverWrite.Checked = CurrentSettings.optConfirmOverWrite;
                    _settingsWindow.cbConfirmDelete.Checked = CurrentSettings.optConfirmDelete;
                    _settingsWindow.cbUseNotepad.Checked = CurrentSettings.optUseNotepad;
                    _settingsWindow.cbAutoName.Checked = CurrentSettings.optAutoName;
                }
            }
        }

        [Serializable]
        public class SettingsData
        {
            public string ExePath { get; set; } = Settings.DefaultExePath; // "eduke32.exe"
            public string notepadPath { get; set; } = Settings.DefaultEditorPath; // "notepad.exe"
            public int Language { get; set; } = 0;
            public bool optSaveUseBrowser { get; set; } = false;
            public PC PreventPresetCol { get; set; } = PC.Allow;
            public PC PreventFolderCol { get; set; } = PC.Allow;
            public bool optUseColor { get; set; } = false;
            public Color CurrentColor {  get; set; } = Color.Red;
            public bool optExpandTree {  get; set; } = false;
            public bool optConfirmOverWrite {  get; set; } = false;
            public bool optConfirmDelete { get; set; } = false;
            public bool optUseNotepad { get; set; } = false;
            public bool optImportSummary { get; set; } = false;
            public bool optClearAfterImport { get; set; } = false;
            public int[] myCustomColors { get; set; } = [6916092, 15195440, 16107657, 1836924,
                3758726, 10526880, 7526079, 7405793, 6945974, 241502, 2296476, 5130294,
                3102017, 7324121, 14993507, 11730944];
            public Finder.Mode findMode { get; set; } = Finder.Mode.Normal;
            public Finder.Target findTarget { get; set; } = Finder.Target.Preset;
            public bool findMatchCase { get; set; } = false;
            public bool findBackward { get; set; } = false;
            public bool findWrap { get; set; } = false;
            public bool optAutoName { get; set; } = false;
            public int savedNodeId { get; set; } = 0;
        }
    }
}