using System;
using System.IO;

namespace GUI.Output
{
    internal static class Logger
    {
        private static string _filename = "log.txt";
        /// <summary>
        /// Writes a string to the log file (creates if doesn't exist)
        /// </summary>
        /// <returns>Line that was written with accompanying timestamp</returns>
        internal static string WriteToLog(string message)
        {
            var folderPath = GetLogFolderPath();
            var filePath = Path.Combine(folderPath, _filename);
            
            var timestamp = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss");
            var text = $"{timestamp} | {message}";
            
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            
            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                File.Create(filePath).Close();
            }
            
            using (var sw = File.AppendText(filePath))
            {
                sw.WriteLine(text);
            }
            
            return text;
        }

        internal static void ClearLogFile()
        {
            var folderPath = GetLogFolderPath();
            var filePath = Path.Combine(folderPath, _filename);
            if (File.Exists(filePath))
                File.WriteAllText(filePath, string.Empty);
        }

        internal static string ReadLog()
        {
            var folderPath = GetLogFolderPath();
            var filePath = Path.Combine(folderPath, _filename);
            
            var text = string.Empty;
            if (File.Exists(filePath))
            {
                using (var sr = new StreamReader(filePath))
                {
                    text = sr.ReadToEnd();
                }
            }
            return text;
        }

        internal static string GetLogFolderPath()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appDataPath, "AoCManager", "Logs");
        }
    }
}
