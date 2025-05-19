using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DukeBlazeLauncher.Extensions;
using Newtonsoft.Json;

namespace DukeBlazeLauncher
{
    public static class PresetsManager
    {
        //        private const string PresetsSavePath = "LauncherData\\Presets.dat";
        //        private const string PresetsSettingsSavePath = "LauncherData\\PresetsSettings.dat";
        private const string PresetsSavePath = $@"{Tools.ldFolder}\{Tools.dPre}";
        private const string PresetsSettingsSavePath = $@"{Tools.ldFolder}\{Tools.dPset}";

        private static TreeView _presetTree = null;
        private static MainWindow _mainWindow = null;
        private static List<PresetItem> PresetSettings = [];
        public static bool IsPresetSelected { get; set; } = false;
        public static int LastNodeId { get; private set; } = 2;

        public static void CreateFiles(bool force = false)
        {
            // Since the Presets, PresetsSettings and Description files must stay in sync,
            //      if any files are missing just replace them all with the defaults
            // Steve - 01/29/2025 22:36:26
            try
            {
                if (force || !File.Exists(PresetsSavePath) || !File.Exists(PresetsSettingsSavePath) ||
            !File.Exists(DescriptionManager.DescriptionFilePath))
                {
                    string def = "[{\"Text\":\"📁 Expansions\",\"Tag\":\"0\",\"Children\":[]},{\"Text\":\"📁 Episodes\",\"Tag\":\"1\",\"Children\":[]},{\"Text\":\"📁 Maps\",\"Tag\":\"2\",\"Children\":[]}]";
                    File.WriteAllText(Tools.GetRelativePath(PresetsSavePath), def);
                    File.WriteAllText(Tools.GetRelativePath(PresetsSettingsSavePath), "[]");
                    File.WriteAllText(Tools.GetRelativePath(DescriptionManager.DescriptionFilePath), "[]");
                    //if (!force) Debug.WriteLine("***One of the Presets files was missing, replacing all with defaults");
                    Tools.WriteWarningFile();  // May as well replace the warning file also
                }

            }
            catch (Exception ex)
            {
                using (new CenterWinDialog(_mainWindow))
                {
                    MessageBox.Show(MainWindow.MyTitle, $"Error Saving Files\n{ex}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static int GetNewId()
        {
            LastNodeId++;
            return LastNodeId;
        }

        private static int GetLastIdFromSave()
        {
            int id = 0;
            int tag;
            var allNodes = TreeViewTools.Collect(_presetTree.Nodes);
            foreach (var node in allNodes)
            {
                if (node.Tag is not null)
                {
                    tag = (int)node.Tag;
                    if (tag > id) id = tag;
                }
            }
            return id;
        }

        public static void Init(TreeView presetTree, MainWindow mainWindow)
        {
            _presetTree = presetTree;
            _mainWindow = mainWindow;
        }

        public static void Save()
        {
            File.WriteAllText(PresetsSavePath, TreeViewTools.SaveTreeViewToJson(_presetTree));
            DescriptionManager.SaveDescriptionToFile();
        }

        public static void Load()
        {
            TreeViewTools.LoadTreeViewFromJson(_presetTree, File.ReadAllText(PresetsSavePath));
            LastNodeId = GetLastIdFromSave();
            LoadPresetSettingsFromFile();
            DescriptionManager.LoadDescriptionFromFile();
        }



        public static bool IsPresetExist(int nodeId)
        {
            bool exist = false;
            var allNodes = TreeViewTools.Collect(_presetTree.Nodes);
            foreach (var node in allNodes)
            {
                if ((int)node.Tag == nodeId) return exist;
            }
            return exist;
        }


        public static TreeNode GetPresetByNodeId(int nodeId)
        {
            if (!IsPresetExist(nodeId)) return null;
            var allNodes = TreeViewTools.Collect(_presetTree.Nodes);
            foreach (var node in allNodes)
            {
                if ((int)node.Tag == nodeId) return node;
            }
            return null;
        }


        public static PresetItem GetCurrentPresetSettings()
        {
            PresetItem item = new()
            {
                NodeId = (int)_presetTree.SelectedNode.Tag,
                Files = ListFiles.Files,
                GameDirectoryPath = AdditionalParameters.GameDirectory,
                ConfigPath = AdditionalParameters.ConfigPath,
                SkillLevel = AdditionalParameters.Skill,
                Addon = AdditionalParameters.Addon,
                RespawnMode = AdditionalParameters.RespawnMode,
                DisableStartup = AdditionalParameters.DisableStartupWindow,
                DisableMonsters = AdditionalParameters.DisableMonstersWindow,
                DisableLogo = AdditionalParameters.DisableStartupAnimationsAndLogos,
                AdditionalCommands = _mainWindow.AdditionalCommandsTextBox.Text,
                CustomExePath = AdditionalParameters.CustomExe,
                DisableInstance = AdditionalParameters.DisableInstanceCheck
            };
            return item;
        }


        public static void SetCurrentPresetSettings()
        {
            var item = PresetSettings.Find(x => x.NodeId == (int)_presetTree.SelectedNode.Tag);
            if (item is not null)
            {
                ListFiles.Clear();
                foreach (var file in item.Files)
                {
                    ListFiles.AddFile(Tools.GetRelativePath(file.FilePath), file.LoadAsMain);
                    ListFiles.Refresh(false);
                }

                AdditionalParameters.GameDirectory = item.GameDirectoryPath;
                AdditionalParameters.ConfigPath = item.ConfigPath;
                AdditionalParameters.Skill = item.SkillLevel;
                AdditionalParameters.Addon = item.Addon;
                AdditionalParameters.RespawnMode = item.RespawnMode;
                AdditionalParameters.DisableStartupWindow = item.DisableStartup;
                AdditionalParameters.DisableMonstersWindow = item.DisableMonsters;
                AdditionalParameters.DisableStartupAnimationsAndLogos = item.DisableLogo;
                _mainWindow.AdditionalCommandsTextBox.Text = item.AdditionalCommands;
                AdditionalParameters.CustomExe = item.CustomExePath;
                AdditionalParameters.DisableInstanceCheck = item.DisableInstance;

                IsPresetSelected = true;
            }
        }


        public static void AddCurrentPresetSettings()
        {
            bool found = false;

            for (int i = 0; i < PresetSettings.Count; i++)
            {
                if (PresetSettings[i].NodeId == (int)_presetTree.SelectedNode.Tag)
                {
                    PresetSettings[i] = GetCurrentPresetSettings();
                    found = true;
                    break;
                }
            }
            if (!found) PresetSettings.Add(GetCurrentPresetSettings());
            SavePresetSettingsToFile();
            LoadPresetSettingsFromFile();
        }

        public static void RemovePresetSettings(int nodeId)
        {
            LoadPresetSettingsFromFile();
            for (int i = 0; i < PresetSettings.Count; i++)
            {
                if(PresetSettings[i].NodeId == nodeId)
                {
                    PresetSettings.RemoveAt(i);
                    break;
                }
            }
            SavePresetSettingsToFile();
        }


        private static void SavePresetSettingsToFile()
        {
            if (!File.Exists(PresetsSettingsSavePath)) File.WriteAllText(PresetsSettingsSavePath, String.Empty);
            string savedText = JsonConvert.SerializeObject(PresetSettings);
            File.WriteAllText(PresetsSettingsSavePath, savedText);
        }


        private static void LoadPresetSettingsFromFile()
        {
            if (!File.Exists(PresetsSettingsSavePath)) File.WriteAllText(PresetsSettingsSavePath, String.Empty);
            var fileText = File.ReadAllText(PresetsSettingsSavePath);
            var newItems = JsonConvert.DeserializeObject<List<PresetItem>>(fileText);
            if (newItems is not null) PresetSettings = newItems;
        }
    }

    [Serializable]
    public class PresetItem
    {
        public int NodeId { get; set; }
        public List<UploadedFile> Files { get; set; } = [];
        public string GameDirectoryPath { get; set; }
        public string ConfigPath { get; set; }
        public int SkillLevel { get; set; }
        public int Addon { get; set; }
        public int RespawnMode { get; set; }
        public bool DisableStartup { get; set; }
        public bool DisableMonsters { get; set; }
        public bool DisableLogo { get; set; }
        public string AdditionalCommands { get; set; }
        public string CustomExePath { get; set; }
        public bool DisableInstance {  get; set; }
    }

}