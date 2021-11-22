using GUI.Helpers;

namespace GUI.Output
{
    internal class OutputViewModel : ObservableObject
    {
        private string _outputText;
        private string _logText;

        public OutputViewModel()
        {
            LogText = Logger.ReadLog();
            OutputSink.WriteLineEvent += (sender, text) => AppendOutput(text);
        }

        public string LogText
        {
            get => _logText;
            set => RaiseAndSetIfChanged(ref _logText, value);
        }
        public string OutputText
        {
            get => _outputText;
            set => RaiseAndSetIfChanged(ref _outputText, value);
        }

        internal void ClearOutputText()
        {
            OutputText = string.Empty;
        }

        private void AppendOutput(string text)
        {
            OutputText += text;
            LogText += Logger.WriteToLog(text.Trim()) + "\n";
        }
    }
}
