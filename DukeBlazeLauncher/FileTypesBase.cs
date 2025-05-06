using System.Collections.Generic;

namespace DukeBlazeLauncher
{
    public static class FileTypesBase
    {

        public enum DukeFiles
        {
            none,
            GRP,
            CON,
            DEF,
            ZIP,
            PK3,
            MAP
        }


        public static Dictionary<DukeFiles, DukeFileType> Files = new Dictionary<DukeFiles, DukeFileType>()
        {
            { DukeFiles.GRP,    new DukeFileType(0, "GRP",  true)  },
            { DukeFiles.CON,    new DukeFileType(1, "CON",  true)  },
            { DukeFiles.DEF,    new DukeFileType(2, "DEF",  true)  },
            { DukeFiles.ZIP,    new DukeFileType(3, "ZIP")         },
            { DukeFiles.PK3,    new DukeFileType(4, "PK3")         },
            { DukeFiles.MAP,    new DukeFileType(5, "MAP")         },
        };



        public static DukeFileType GetFileType(string fileExtension)
        {
            DukeFileType fileType = null;
            foreach (var type in Files)
            {
                if(type.Value.Extension.ToLower() == fileExtension.ToLower())
                {
                    fileType = type.Value;
                    break;
                }
            }
            return fileType;
        }


        public static DukeFiles GetDukeFileTypeByExtension(string fileExtension)
        {
            var dukeFileType = GetFileType(fileExtension);

            foreach(var item in Files.Keys)
            {
                if (Files[item] == dukeFileType) return item;
            }

            return DukeFiles.none;
        }

    }



    public class DukeFileType
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public bool HasAdditionalParameters { get; set; }

        public DukeFileType(int id, string extension, bool hasAdditionalParameters = false)
        {
            Id = id;
            Extension = extension;
            HasAdditionalParameters = hasAdditionalParameters;
        }
    }

}