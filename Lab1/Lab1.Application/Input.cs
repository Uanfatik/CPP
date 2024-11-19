using System.Numerics;

namespace Lab1.Application;

internal class Input
{
    private Input(int n, int k1, int k2, BigInteger s)
    {
        N = n;
        K1 = k1;
        K2 = k2;
        S = s;
    }


    public int N { get; }

    public int K1 { get; }

    public int K2 { get; }

    public BigInteger S { get; }


    public static Input Parse(IEnumerator<string> lines)
    {
        if (!lines.MoveNext())
        {
            throw new InputException("The input data contains nothing.");
        }
        var line = lines.Current;

        var values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (
            !(
                values is [var nText, var k1Text, var k2Text, var sText]
                && int.TryParse(nText, out var n) && n is >= 1 and <= 50
                && int.TryParse(k1Text, out var k1) && k1 >= 0 && k1 < n
                && int.TryParse(k2Text, out var k2) && k2 >= 0 && k2 < n
                && BigInteger.TryParse(sText, out var s) && s > 1 && s < BigInteger.Pow(10, 100)
            )
        )
        {
            throw new InputException("The input data is invalid.");
        }

        return new Input(n, k1, k2, s);
    }
}
