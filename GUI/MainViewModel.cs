using System.Text;
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
            SolvePartCommand = new SimpleCommand(OnSolvePartPressed);
        }

        public OutputViewModel OutputViewModel { get; }
        public DatePickerViewModel DatePickerViewModel { get; }

        private void OnSolvePartPressed(object args)
        {
            OutputViewModel.ClearOutputText();
            var sb = new StringBuilder("Selected ");

            sb.Append(DatePickerViewModel.SelectedPuzzleYear == PuzzleYears.None
                ? "No Year, "
                : $"{DatePickerViewModel.SelectedPuzzleYear}, ");

            sb.Append(DatePickerViewModel.SelectedPuzzleDay == PuzzleDays.None
                ? "No Day, "
                : $"{DatePickerViewModel.SelectedPuzzleDay}, ");

            sb.Append($"Part {args}");

            OutputSink.WriteLine(sb.ToString());

            if (DatePickerViewModel.SelectedPuzzleDay == PuzzleDays.None ||
                DatePickerViewModel.SelectedPuzzleYear == PuzzleYears.None)
            {
                OutputSink.WriteLine("You need to select both a year and a day to solve a puzzle!");
                return;
            }
            
            // TODO: Actually hook in to solve the puzzle I guess
            OutputSink.WriteLine("Puzzle solution is: \n ~Answer~");
        }
    }
}
