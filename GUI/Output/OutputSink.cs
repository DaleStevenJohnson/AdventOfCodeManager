using System;

namespace GUI.Output
{
    public static class OutputSink
    {
        internal static event EventHandler<string> WriteLineEvent;

        public static void WriteLine(string text)
        {
            WriteLineEvent.Invoke(null, $"{text}\n");
        }

        public static void Write(string text)
        {
            WriteLineEvent.Invoke(null, text);
        }
    }
}
