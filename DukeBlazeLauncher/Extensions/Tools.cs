using System;
using System.Threading.Tasks;

namespace DragDukeLauncher.Extensions
{
    public static class Tools
    {

        public const string FolderIcon = "📁";
        public const string Slash = "\\";
              
        public static async void WaitSomeTime(int delayTime, Action action)
        {
            await Task.Delay(delayTime);
            action?.Invoke();
        }

        public static string GetRelativePath(string path)
        {
            return path.Replace(AppDomain.CurrentDomain.BaseDirectory, String.Empty);
        }

        public static string GetPathWithAppDomain(string path)
        {
            return AppDomain.CurrentDomain.BaseDirectory + path;
        }

    }
}
