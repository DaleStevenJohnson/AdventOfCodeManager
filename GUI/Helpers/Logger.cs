using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GUI.Helpers
{
    internal class Logger
    {
        private string _filename = "log.txt";
        internal Logger()
        {

        }

        internal void Log(string message)
        {
            if (!File.Exists(_filename))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(_filename))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                File.WriteAllText(_filename, message);
            }
        }


    }
}
