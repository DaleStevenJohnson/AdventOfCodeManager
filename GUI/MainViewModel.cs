using System.Windows.Input;
using GUI.Constants;
using GUI.DatePicker;
using GUI.Helpers;
using GUI.Output;

namespace GUI
{
    internal class MainViewModel : ObservableObject
    {
        public ICommand SolvePartCommand { get; }
        public MainViewModel(OutputViewModel outputViewModel, DatePickerViewModel datepickerViewModel)
        {
            DatePickerViewModel = datepickerViewModel;
            OutputViewModel = outputViewModel;
            SolvePartCommand = new SimpleCommand(partNumber => OnSolvePartPressed(partNumber));
        }

        public OutputViewModel OutputViewModel { get; }
        public DatePickerViewModel DatePickerViewModel { get; }        
        
        private void OnSolvePartPressed(object args)
        {
            OutputViewModel.ClearOutputText();
            if (DatePickerViewModel.SelectedPuzzleDay == PuzzleDays.None)
            {
                OutputSink.WriteLine($"{DatePickerViewModel.SelectedPuzzleDay}");
            }
            else
                OutputSink.WriteLine($"{DatePickerViewModel.SelectedPuzzleDay} Part {args}");
        }


    }
}
