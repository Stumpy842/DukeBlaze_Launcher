using DragDukeLauncher.Extensions;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DragDukeLauncher
{
    public static class Settings
    {

        private const string SettingsFilePath = "LauncherData\\Settings.dat";
        private static SettingsWindow _settingsWindow = null;
        public static SettingsData CurrentSettings { get; private set; } = new SettingsData();

        public static void Init(SettingsWindow settingsWindow)
        {
            _settingsWindow = settingsWindow;
        }

        public static void Save()
        {
            CurrentSettings.ExePath = _settingsWindow.ExePathTextBox.Text;

            if (File.Exists(SettingsFilePath) == false) File.WriteAllText(Tools.GetRelativePath(SettingsFilePath), String.Empty);
            string savedText = JsonConvert.SerializeObject(CurrentSettings);
            File.WriteAllText(SettingsFilePath, savedText);
        }

        public static void Load()
        {
            if (File.Exists(SettingsFilePath) == false) File.WriteAllText(SettingsFilePath, String.Empty);
            var fileText = File.ReadAllText(SettingsFilePath);
            var newItems = JsonConvert.DeserializeObject<SettingsData>(fileText);
            if (newItems != null) CurrentSettings = newItems;

            _settingsWindow.ExePathTextBox.Text = CurrentSettings.ExePath;
        }


        [Serializable]
        public class SettingsData
        {
            public string ExePath { get; set; } = "eduke32.exe";
            public int Language { get; set; }
        }

    }
}