using System.Windows.Input;
using GUI.Constants;
using GUI.Helpers;
using GUI.Output;

namespace GUI
{
    internal class MainViewModel : ObservableObject
    {
        private string _outputText = string.Empty;
        private PuzzleDays _selectedPuzzleDay;

        public ICommand SolvePartCommand { get; }
        public MainViewModel(OutputViewModel outputViewModel)
        {
            OutputViewModel = outputViewModel;
            SelectedPuzzleDay = PuzzleDays.None;
            SolvePartCommand = new SimpleCommand(partNumber => OnSolvePartPressed(partNumber));
        }

        public OutputViewModel OutputViewModel { get; }

        public PuzzleDays SelectedPuzzleDay 
        { 
            get => _selectedPuzzleDay; 
            set => RaiseAndSetIfChanged(ref _selectedPuzzleDay, value); 
        }

       
        

        
        private void OnSolvePartPressed(object args)
        {
            OutputViewModel.ClearOuputText();
            if (SelectedPuzzleDay == PuzzleDays.None)
            {
                OutputSink.WriteLine($"{SelectedPuzzleDay}");
            }
            else
                OutputSink.WriteLine($"{SelectedPuzzleDay} Part {args}");
        }


    }
}
