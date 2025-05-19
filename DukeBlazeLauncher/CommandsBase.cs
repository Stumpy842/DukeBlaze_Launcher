using System;
using System.Collections.Generic;
using static DukeBlazeLauncher.FileTypesBase;

namespace DukeBlazeLauncher
{

    public static class CommandsBase
    {

        public enum CommandNames
        {
            none,
            gamegrp,
            grp,
            x,
            mx,
            h,
            mh,
            g,
            map,
            game_dir,
            cfg,
            s,
            addon,
            t,
            nosetup,
            m,
            nologo,
            quick,
            nosteam,
            ns,
            nm,
            noinst
        }

        public static readonly Dictionary<CommandNames, Command> AllCommands = new()
        {
            { CommandNames.gamegrp,  new Command("-gamegrp",  DukeFiles.GRP,                                         hasValue: true,      loadAsMain: true)           },
            { CommandNames.grp,      new Command("-grp",      DukeFiles.GRP,                                         hasValue: true)                                  },
            { CommandNames.x,        new Command("-x",        DukeFiles.CON,                                         hasValue: true,      loadAsMain: true)           },
            { CommandNames.mx,       new Command("-mx",       DukeFiles.CON,                                         hasValue: true)                                  },
            { CommandNames.h,        new Command("-h",        DukeFiles.DEF,                                         hasValue: true,      loadAsMain: true)           },
            { CommandNames.mh,       new Command("-mh",       DukeFiles.DEF,                                         hasValue: true)                                  },
            { CommandNames.g,        new Command("-g",        [DukeFiles.ZIP, DukeFiles.PK3],                        hasValue: true)                                  },
            { CommandNames.map,      new Command("-map",      DukeFiles.MAP,                                         hasValue: true)                                  },
            { CommandNames.game_dir, new Command("-game_dir", DukeFiles.none,                                        hasValue: true)                                  },
            { CommandNames.cfg,      new Command("-cfg",      DukeFiles.none,                                        hasValue: true)                                  },
            { CommandNames.s,        new Command("-s",        DukeFiles.none,                                        hasValue: true)                                  },
            { CommandNames.addon,    new Command("-addon",    DukeFiles.none,                                        hasValue: true)                                  },
            { CommandNames.t,        new Command("-t",        DukeFiles.none,                                        hasValue: true)                                  },
            { CommandNames.nosetup,  new Command("-nosetup",  DukeFiles.none,                                        hasValue: false)                                 },
            { CommandNames.m,        new Command("-m",        DukeFiles.none,                                        hasValue: false)                                 },
            { CommandNames.nologo,   new Command("-nologo",   DukeFiles.none,                                        hasValue: false)                                 },
            { CommandNames.quick,    new Command("-quick",    DukeFiles.none,                                        hasValue: false)                                 },
            { CommandNames.nosteam,  new Command("-nosteam",  DukeFiles.none,                                        hasValue: false)                                 },
            { CommandNames.ns,       new Command("-ns",       DukeFiles.none,                                        hasValue: false)                                 },
            { CommandNames.nm,       new Command("-nm",       DukeFiles.none,                                        hasValue: false)                                 },
            { CommandNames.noinst,   new Command("-noinstancechecking", DukeFiles.none,                              hasValue: false)                                 }
        };


        public static Command GetCommandByDukeFileType(DukeFiles dukeFileType, bool loadAsMain)
        {
            foreach(var value in AllCommands.Values)
            {
                foreach(var type in value.FileType)
                {
                    if (type == dukeFileType && value.LoadAsMain == loadAsMain)
                    {
                        return value;
                    }
                }
            }
            return null;
        }
        
    }


    public class Command
    {
        public string CommandName { get; set; }
        public List<DukeFiles> FileType { get; set; } = [];
        public bool HasValue { get; set; }
        public List<string> FileTypes { get; set; } = [];
        public bool LoadAsMain { get; set; }

        public Command(string commandName, DukeFiles fileType, bool hasValue, bool loadAsMain = false)
        {
            CommandName = commandName;
            FileType.Add(fileType);
            HasValue = hasValue;
            LoadAsMain = loadAsMain;
        }

        public Command(string commandName, List<DukeFiles> fileType, bool hasValue, bool loadAsMain = false)
        {
            CommandName = commandName;
            FileType = fileType;
            HasValue = hasValue;
            LoadAsMain = loadAsMain;
        }
    }

}
