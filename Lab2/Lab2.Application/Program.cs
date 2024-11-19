using Lab2.Application;
using Lab2.Solving;

const string
    inputPath = "INPUT.TXT",
    outputPath = "OUTPUT.TXT";

string[] linesArray;
try
{
    linesArray = File.ReadAllLines(inputPath);
}
catch (Exception exception)
{
    Console.WriteLine($"An error occurred while reading the file. {exception.Message}");
    return;
}

using (var lines = linesArray.AsEnumerable().GetEnumerator())
{
    Input input;
    try
    {
        input = Input.Parse(lines);
    }
    catch (InputException exception)
    {
        File.WriteAllLines(outputPath, [exception.Message]);
        return;
    }

    var result = ChocolateSplitter.Split(input.N);
    File.WriteAllLines(outputPath, [$"{result}"]);
}
