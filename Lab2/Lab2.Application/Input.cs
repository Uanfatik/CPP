namespace Lab2.Application;

internal class Input
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
