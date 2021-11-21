using System.Windows.Input;
using GUI.Constants;
using GUI.Helpers;
using TeacherPlanner.Helpers;

namespace GUI
{
    internal class MainViewModel : ObservableObject
    {
        private string _outputText = string.Empty;
        private PuzzleDays _selectedPuzzleDay;

        public ICommand SolvePartCommand { get; }
        public MainViewModel()
        {
            SelectedPuzzleDay = PuzzleDays.None;
            SolvePartCommand = new SimpleCommand(partNumber => OnSolvePartPressed(partNumber));
            OutputSink.WriteLineEvent += (sender, text) => AppendOutput(text);
        }
        public PuzzleDays SelectedPuzzleDay 
        { 
            get => _selectedPuzzleDay; 
            set => RaiseAndSetIfChanged(ref _selectedPuzzleDay, value); 
        }

        public string OutputText
        {
            get => _outputText;
            set => RaiseAndSetIfChanged(ref _outputText, value);
        }
        private void AppendOutput(string text)
        {
            OutputText += text;
        }

        private void OnSolvePartPressed(object args)
        {
            if (SelectedPuzzleDay == PuzzleDays.None)
            {
                OutputSink.WriteLine($"{SelectedPuzzleDay}");
            }
            else
                OutputSink.WriteLine($"{SelectedPuzzleDay} Part {args}");
        }


    }
}
