namespace GUI
{
    interface IPuzzleDaySolution
    {
        string InputFile { get; }
        string SolvePartOne();
        string SolvePartTwo();
    }
}
