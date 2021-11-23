using GUI.Constants;
using GUI.Helpers;

namespace GUI.DatePicker
{
    internal class DatePickerViewModel : ObservableObject
    {
        private PuzzleDays _selectedPuzzleDay;
        private PuzzleYears _selectedPuzzleYear;

        public DatePickerViewModel()
        {
            SelectedPuzzleDay = PuzzleDays.None;
            SelectedPuzzleYear = PuzzleYears.None;
        }

        public PuzzleDays SelectedPuzzleDay
        {
            get => _selectedPuzzleDay;
            set => RaiseAndSetIfChanged(ref _selectedPuzzleDay, value);
        }

        public PuzzleYears SelectedPuzzleYear
        {
            get => _selectedPuzzleYear;
            set => RaiseAndSetIfChanged(ref _selectedPuzzleYear, value);
        }
    }
}
