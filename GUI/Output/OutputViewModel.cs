using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using GUI.Helpers;

namespace GUI.Output
{
    internal class OutputViewModel : ObservableObject
    {
        private string _outputText;
        private string _logText;
        private bool _shouldWriteToLogFile;

        public OutputViewModel()
        {
            LogText = Logger.ReadLog();
            OutputSink.WriteLineEvent += (sender, text) => AppendOutput(text);
            OpenLogsInExplorerCommand = new SimpleCommand(_ => OnOpenLogsInExplorer());
            ClearLogsCommand = new SimpleCommand(_ => OnClearLogs());
            ShouldWriteToLogFile = true;
        }

        private void OnClearLogs()
        {
            LogText = string.Empty;
            Logger.ClearLogFile();
        }

        public ICommand OpenLogsInExplorerCommand { get; }
        public ICommand ClearLogsCommand { get; }

        public bool ShouldWriteToLogFile
        {
            get => _shouldWriteToLogFile;
            set => RaiseAndSetIfChanged(ref _shouldWriteToLogFile, value);
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
            
            if (ShouldWriteToLogFile)
                LogText += Logger.WriteToLog(text.Trim()) + "\n";
        }

        private void OnOpenLogsInExplorer()
        {
            var folderPath = Logger.GetLogFolderPath();

            if (Directory.Exists(folderPath))
            {
                var startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
            else
            {
                AppendOutput("No output file exists yet!");
            }
        }
    }
}
