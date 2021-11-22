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
            string timestamp = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss");
            var text = $"{timestamp} | {message}";
            if (!File.Exists(_filename))
            {
                // Create a file to write to.
                File.Create(_filename).Close();
            }
            
            using (StreamWriter sw = File.AppendText(_filename))
            {
                sw.WriteLine(text);
            }
            
            return text;
        }

        internal static string ReadLog()
        {
            var text = string.Empty;
            if (File.Exists(_filename))
            {
                using (StreamReader sr = new StreamReader(_filename))
                {
                    text = sr.ReadToEnd();
                }
            }
            return text;
        }
    }
}
