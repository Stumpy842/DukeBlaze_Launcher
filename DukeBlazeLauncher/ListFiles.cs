using DragDukeLauncher.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    public static class ListFiles
    {
        public static List<UploadedFile> Files { get; set; } = [];
        private static ListBox _listBox;
        private static Form _form;

        public static void Init(ListBox listBox, Form Form)
        {
            _listBox = listBox;
            _form = Form;
        }

        public static void AddFile(string filePath)
        {
            Console.WriteLine($"> {Tools.GetRelativePath(filePath)}");
            Files.Add(new UploadedFile(Tools.GetRelativePath(filePath), false));
        }

        public static void AddFile(string filePath, bool loadAsMain)
        {
            Console.WriteLine($"> {Tools.GetRelativePath(filePath)}");
            Files.Add(new UploadedFile(Tools.GetRelativePath(filePath), loadAsMain));
        }

        public static void RemoveFile()
        {
            if (_listBox.SelectedIndex == -1) return;
            Files.RemoveAt(_listBox.SelectedIndex);
        }

        public static void MoveUp()
        {
            if (_listBox.SelectedIndex == -1) return;
            if (Files.Count > 1)
            {
                if (_listBox.SelectedIndex > 0)
                {

                    var upper = Files[_listBox.SelectedIndex - 1];
                    var selected = Files[_listBox.SelectedIndex];

                    Files[_listBox.SelectedIndex] = upper;
                    Files[_listBox.SelectedIndex - 1] = selected;

                    _listBox.SelectedIndex -= 1;
                }
            }
        }

        public static void MoveDown()
        {
            if (_listBox.SelectedIndex == -1) return;
            if (Files.Count > 1)
            {
                if (_listBox.SelectedIndex < Files.Count - 1)
                {

                    var selected = Files[_listBox.SelectedIndex];
                    var lower = Files[_listBox.SelectedIndex + 1];

                    Files[_listBox.SelectedIndex] = lower;
                    Files[_listBox.SelectedIndex + 1] = selected;

                    _listBox.SelectedIndex += 1;
                }
            }
        }

        public static bool IsSelectedFileAsMain()
        {
            return Files[_listBox.SelectedIndex].LoadAsMain;
        }

        public static void SetSelectedFileAsMain(bool active)
        {
            Files[_listBox.SelectedIndex].LoadAsMain = active;
        }

        public static void Refresh(bool saveSelection = false)
        {
            int oldSelectedIndex = _listBox.SelectedIndex;
            _listBox.Items.Clear();
            for (int i = 0; i < Files.Count; i++)
            {
                _listBox.Items.Add(Path.GetFileName(Files[i].FilePath));
            }
            if (saveSelection && oldSelectedIndex < Files.Count)  _listBox.SelectedIndex = oldSelectedIndex;
        }

        public static void ClearSelection()
        {
            _listBox.SelectedIndex = -1;
        }

        public static void SetFirstSelection()
        {
            try
            {
                _listBox.SelectedIndex = 0;
            }
            catch { }
        }

        public static void Clear()
        {
            Files.Clear();
        }

    }

    [Serializable]
    public class UploadedFile
    {
        public string FilePath { get; set; }
        public bool LoadAsMain { get; set; }
        [NonSerialized]
        public FileTypesBase.DukeFiles DukeFileType = FileTypesBase.DukeFiles.none;
        [NonSerialized]
        public Command Command = null;

        public UploadedFile(string filePath, bool loadAsMain)
        {
            FilePath = filePath;
            LoadAsMain = loadAsMain;
            DukeFileType = FileTypesBase.GetDukeFileTypeByExtension(GetExtension());
            Refresh();
        }

        public void Refresh()
        {
            Command = CommandsBase.GetCommandByDukeFileType(DukeFileType, LoadAsMain);
        }

        public string GetExtension()
        {
            return FilePath.Split('.').Last();
        }

        public string GetRunString()
        {
            Refresh();
            return $"{Command.CommandName} \"{GetRelativePath()}\" ";
        }

        public string GetRelativePath()
        {
            return FilePath.Replace(AppDomain.CurrentDomain.BaseDirectory, String.Empty); 
        }
    }
}
