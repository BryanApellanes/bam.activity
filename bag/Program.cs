using Bam.Console;

[Serializable]
class Program
{
    static void Main(string[] args)
    {
        BamConsoleContext.Current.AddValidArgument("outputDirectory", "The directory to output to");
        BamConsoleContext.Current.AddValidArgument("inputFile", false, false, "Read input from the specified file");
        BamConsoleContext.StaticMain(args);
    }
}