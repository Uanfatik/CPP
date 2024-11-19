using System.Diagnostics;
using System.Numerics;
using Lab1.Application;
using Lab1.Solving;

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

    var distributor = new PrizeDistributor(input.N, input.S);
    BigInteger s1, s2;
    try
    {
        (s1, s2) = distributor.Distribute(input.K1, input.K2);
    }
    catch (SolvingException exception)
    {
        var message = exception.Error switch
        {
            SolvingError.ImposibleDividePrize => "It is not possible to divide the prize into whole parts.",
            _ => throw new UnreachableException()
        };
        File.WriteAllLines(outputPath, [message]);
        return;
    }

    File.WriteAllLines(outputPath, [$"{s1} {s2}"]);
}
