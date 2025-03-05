using DragDukeLauncher.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDukeLauncher
{
    internal static class Run
    {

        private static RichTextBox _customCommandsBox = null;


        internal static void Init(RichTextBox customCommandsBox)
        {
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
                        //string fileName = AdditionalParameters.CustomExe.ToString().Split('\\').Last();
                        string fileName = AdditionalParameters.CustomExe.Split('\\').Last();
                        string folderPath = AdditionalParameters.CustomExe.Replace(fileName, "");
                        string absolutePath = folderPath + fileName;

                        ProcessStartInfo processInfo = new ProcessStartInfo();
                        processInfo.WorkingDirectory = folderPath;
                        processInfo.Domain = folderPath;
                        processInfo.FileName = absolutePath;
                        processInfo.Arguments = GetCommands();

                        Process.Start(processInfo);
                    }
                    else
                    {
                        //string fileName = AdditionalParameters.CustomExe.ToString().Split('\\').Last();
                        string fileName = AdditionalParameters.CustomExe.Split('\\').Last();
                        string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string absolutePath = exeDirectory + AdditionalParameters.CustomExe;
                        string folderPath = absolutePath.Replace(fileName, "");

                        ProcessStartInfo processInfo = new ProcessStartInfo();
                        processInfo.WorkingDirectory = folderPath;
                        processInfo.Domain = folderPath;
                        processInfo.FileName = absolutePath;
                        processInfo.Arguments = GetCommands();

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
            var dialogResult = MessageBox.Show($"eduke32.exe not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (dialogResult == DialogResult.OK)
            {
                using SettingsWindow settingsWindow = new SettingsWindow() { KeyPreview = true };
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
