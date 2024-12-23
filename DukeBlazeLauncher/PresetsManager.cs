using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DragDukeLauncher.Extensions;
using Newtonsoft.Json;

namespace DragDukeLauncher
{
    public static class PresetsManager
    {

        private const string PresetsSavePath = "LauncherData\\Presets.dat";
        private const string PresetsSettingsSavePath = "LauncherData\\PresetsSettings.dat";

        private static TreeView _presetTree = null;
        private static MainWindow _mainWindow = null;
        private static List<PresetItem> PresetSettings = new List<PresetItem>();
        public static bool IsPresetSelected { get; set; } = false;
        public static int LastNodeId { get; private set; } = 2;



        public static int GetNewId()
        {
            LastNodeId++;
            return LastNodeId;
        }

        private static int GetLastIdFromSave()
        {
            int id = 0;
            var allNodes = TreeViewTools.Collect(_presetTree.Nodes);
            foreach (var node in allNodes)
            {
                if (node.Tag != null)
                {
                    int tag = Int32.Parse(node.Tag.ToString());
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
                if (node.Tag.ToString() == nodeId.ToString()) return exist;
            }
            return exist;
        }


        public static TreeNode GetPresetByNodeId(int nodeId)
        {
            if (IsPresetExist(nodeId) == false) return null;
            var allNodes = TreeViewTools.Collect(_presetTree.Nodes);
            foreach (var node in allNodes)
            {
                if (node.Tag.ToString() == nodeId.ToString()) return node;
            }
            return null;
        }


        public static PresetItem GetCurrentPresetSettings()
        {
            PresetItem item = new PresetItem();
            item.NodeId = int.Parse(_presetTree.SelectedNode.Tag.ToString());
            item.Files = ListFiles.Files;
            item.GameDirectoryPath = AdditionalParameters.GameDirectory;
            item.ConfigPath = AdditionalParameters.ConfigPath;
            item.SkillLevel = AdditionalParameters.Skill;
            item.Addon = AdditionalParameters.Addon;
            item.RespawnMode = AdditionalParameters.RespawnMode;
            item.DisableStartup = AdditionalParameters.DisableStartupWindow;
            item.DisableMonsters = AdditionalParameters.DisableMonstersWindow;
            item.DisableLogo = AdditionalParameters.DisableStartupAnimationsAndLogos;
            item.AdditionalCommands = _mainWindow.AdditionalCommandsTextBox.Text;
            item.CustomExePath = AdditionalParameters.CustomExe;
            return item;
        }


        public static void SetCurrentPresetSettings()
        {
            var item = PresetSettings.Find(x => x.NodeId.ToString() == _presetTree.SelectedNode.Tag.ToString());
            if (item != null)
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

                IsPresetSelected = true;
            }
        }


        public static void AddCurrentPresetSettings()
        {
            bool found = false;

            for (int i = 0; i < PresetSettings.Count; i++)
            {
                if (PresetSettings[i].NodeId.ToString() == _presetTree.SelectedNode.Tag.ToString())
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
                if(PresetSettings[i].NodeId.ToString() == nodeId.ToString())
                {
                    PresetSettings.RemoveAt(i);
                    break;
                }
            }
            SavePresetSettingsToFile();
        }


        private static void SavePresetSettingsToFile()
        {
            if (File.Exists(PresetsSettingsSavePath) == false) File.WriteAllText(PresetsSettingsSavePath, String.Empty);
            string savedText = JsonConvert.SerializeObject(PresetSettings);
            File.WriteAllText(PresetsSettingsSavePath, savedText);
        }


        private static void LoadPresetSettingsFromFile()
        {
            if (File.Exists(PresetsSettingsSavePath) == false) File.WriteAllText(PresetsSettingsSavePath, String.Empty);
            var fileText = File.ReadAllText(PresetsSettingsSavePath);
            var newItems = JsonConvert.DeserializeObject<List<PresetItem>>(fileText);
            if (newItems != null) PresetSettings = newItems;
        }

    }



    [Serializable]
    public class PresetItem
    {
        public int NodeId { get; set; }
        public List<UploadedFile> Files { get; set; } = new List<UploadedFile>();
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
    }

}