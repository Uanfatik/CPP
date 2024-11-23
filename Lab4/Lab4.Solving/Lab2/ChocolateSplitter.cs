using System.Numerics;

namespace Lab4.Solving.Lab2;

public static class ChocolateSplitter
{
    public static BigInteger Split(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        return n switch
        {
            _ when n % 2 == 1 => 0,
            0 => 1,
            2 => 3,
            _ => SplitCore(n)
        };
    }


    private static BigInteger SplitCore(int n)
    {
        var numberWays = new BigInteger[n + 1];
        numberWays[0] = 1;
        numberWays[2] = 3;
        for (var i = 4; i <= n; i += 2)
        {
            numberWays[i] = 4 * numberWays[i - 2] - numberWays[i - 4];
        }
        return numberWays[n];
    }
}
