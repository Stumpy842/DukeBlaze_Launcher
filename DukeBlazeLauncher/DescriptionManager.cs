using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace DragDukeLauncher
{
    public static class DescriptionManager
    {

        private const string DescriptionFilePath = "LauncherData\\Description.dat";
        private const string TextIfButtonHasDescription = "Description ✔";
        private const string TextIfButtonHasNotDescription = "Description ✘";
        private static List<DescriptionItem> DescriptionItems = new List<DescriptionItem>();

        public static string LastDescriptionText { get; set; } = string.Empty;

        private static FileStream _descriptionFile = null;
        public static FileStream DescriptionFile
        {
            get
            {
                _descriptionFile = File.Open(DescriptionFilePath, FileMode.OpenOrCreate);
                return _descriptionFile;
            }
        }

   
        public static bool IsDescriptionExist(int nodeId)
        {
            if (DescriptionItems.Count == 0) return false;
            return DescriptionItems.Find(x => x.NodeId == nodeId) != null ? true : false;
        }

        public static string GetDescriptionByNodeId(int nodeId)
        {
            if (IsDescriptionExist(nodeId) == false) return string.Empty;
            return DescriptionItems.Find(x => x.NodeId == nodeId).Description;
        }

        public static void SaveDescriptionByNodeId(int nodeId, string descriptionText, bool isFolder = true)
        {
            LastDescriptionText = descriptionText;
            if (isFolder) return;
            if (IsDescriptionExist(nodeId))
            {
                DescriptionItems.Find(x => x.NodeId == nodeId).Description = descriptionText;
            }
            else
            {
                DescriptionItems.Add(new DescriptionItem(nodeId, descriptionText));
            }
        }

        public static void ClearLastDescription()
        {
            LastDescriptionText = string.Empty;
        }

        public static void Remove(int nodeId)
        {
            List<DescriptionItem> newDescriptionItems = new List<DescriptionItem>();
            for(int i=0; i< DescriptionItems.Count; i++)
            {
                if(DescriptionItems[i].NodeId != nodeId)
                {
                    newDescriptionItems.Add(DescriptionItems[i]);
                }
            }
            DescriptionItems = newDescriptionItems;
        }

        public static void SaveLastDescription(int nodeId)
        {
            if (string.IsNullOrEmpty(LastDescriptionText)) return;
            SaveDescriptionByNodeId(nodeId, LastDescriptionText, false);
        }

        public static void SaveDescriptionToFile()
        {
            string newFileContent = JsonConvert.SerializeObject(DescriptionItems);
            File.WriteAllText(DescriptionFilePath, newFileContent);
        }


        public static void LoadDescriptionFromFile()
        {
            using (StreamReader fs = new StreamReader(DescriptionFile))
            {
                var newItems = JsonConvert.DeserializeObject<List<DescriptionItem>>(fs.ReadToEnd());
                if(newItems!=null) DescriptionItems = newItems;
            }
        }

        public static string GetFolderNameByDescription(bool haveDesciption)
        {
            if (haveDesciption)
            {
                return TextIfButtonHasDescription;
            }
            else
            {
                return TextIfButtonHasNotDescription;
            }
        }

    }

    [System.Serializable]
    public class DescriptionItem
    {
        public int NodeId { get; set; }
        public string Description { get; set; }

        public DescriptionItem(int nodeId, string description)
        {
            NodeId = nodeId;
            Description = description;
        }
    }


}
