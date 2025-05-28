using DukeBlazeLauncher.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DukeBlazeLauncher
{
    internal static class Run
    {
        private static RichTextBox _customCommandsBox = null;
        private static Form _main;

        internal static void Init(Form mainWindow, RichTextBox customCommandsBox)
        {
            _main = mainWindow;
            _customCommandsBox = customCommandsBox;
        }

        internal static void RunGame()
        {
            Console.WriteLine(GetCommands());

            if (File.Exists(Settings.CurrentSettings.ExePath))
            {
                if(AdditionalParameters.CustomExe != String.Empty)
                {
                    if (AdditionalParameters.CustomExe.Contains(@":\"))
                    {
                        string fileName = AdditionalParameters.CustomExe.Split('\\').Last();
                        string folderPath = AdditionalParameters.CustomExe.Replace(fileName, "");
                        string absolutePath = folderPath + fileName;

                        ProcessStartInfo processInfo = new()
                        {
                            WorkingDirectory = folderPath,
                            Domain = folderPath,
                            FileName = absolutePath,
                            Arguments = GetCommands()
                        };

                        Process.Start(processInfo);
                    }
                    else
                    {
                        string fileName = AdditionalParameters.CustomExe.Split('\\').Last();
                        string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string absolutePath = exeDirectory + AdditionalParameters.CustomExe;
                        string folderPath = absolutePath.Replace(fileName, "");

                        ProcessStartInfo processInfo = new()
                        {
                            WorkingDirectory = folderPath,
                            Domain = folderPath,
                            FileName = absolutePath,
                            Arguments = GetCommands()
                        };

                        Process.Start(processInfo);
                    }
                }
                else
                {
                    Process.Start(Settings.CurrentSettings.ExePath, GetCommands());
                }

                Console.WriteLine(GetCommands());
            }
            else
            {
                ExeNotFoundErrorShow();
            }         
        }

        internal static void ExeNotFoundErrorShow()
        {
            if (Tools.ShowTaskDlg(_main, "Error", "eduke32.exe not found", "Enter the correct path to eduke32.exe in the Settings window",
                "", null, -1, TaskDialogIcon.Error) == TaskDialogButton.OK)
            {
                using SettingsWindow settingsWindow = new() { KeyPreview = true };
                settingsWindow.ShowDialog();
            }
        }

        static string GetCommands()
        {

            string commandsFromFiles = String.Empty;

            for(int i=0; i<ListFiles.Files.Count; i++)
            {
                commandsFromFiles += ListFiles.Files[i].GetRunString();
            }

            Console.WriteLine(commandsFromFiles + AdditionalParameters.GetCommands() + _customCommandsBox.Text);
            return commandsFromFiles + AdditionalParameters.GetCommands() + _customCommandsBox.Text;
        }

    }
}
