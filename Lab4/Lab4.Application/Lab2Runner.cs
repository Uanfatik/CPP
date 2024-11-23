using Lab4.Solving.Lab2;

namespace Lab4.Application;

internal static class Lab2Runner
{
    public static string Run(IEnumerator<string> lines)
    {
        Input input;
        try
        {
            input = Input.Parse(lines);
        }
        catch (InputException exception)
        {
            return exception.Message;
        }

        var result = ChocolateSplitter.Split(input.N);
        return $"{result}";
    }
}

file class Input
{
    private Input(int n)
    {
        N = n;
    }


    public int N { get; }


    public static Input Parse(IEnumerator<string> lines)
    {
        if (!lines.MoveNext())
        {
            throw new InputException("The input data contains nothing.");
        }
        var line = lines.Current;

        if (!(int.TryParse(line, out var n) && n is >= 0 and < 33))
        {
            throw new InputException("The input data is invalid.");
        }

        return new Input(n);
    }
}
