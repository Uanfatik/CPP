using System.Numerics;

namespace Lab4.Solving.Lab1;

public class PrizeDistributor
{
    public PrizeDistributor(int n, BigInteger s)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(n);
        ArgumentOutOfRangeException.ThrowIfNegative(s);

        N = n;
        S = s;
    }


    public int N { get; }

    public BigInteger S { get; }


    public (BigInteger S1, BigInteger S2) Distribute(int k1, int k2)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(k1);
        if (k1 > N)
        {
            throw new InvalidOperationException($"'{nameof(k1)}' must be less than or equal to '{nameof(N)}'.");
        }
        ArgumentOutOfRangeException.ThrowIfNegative(k2);
        if (k2 > N)
        {
            throw new InvalidOperationException($"'{nameof(k2)}' must be less than or equal to '{nameof(N)}'.");
        }

        var baseProbability = new Fraction(1, 2);
        var probabilities = new Fraction[N + 1, N + 1];
        probabilities[k1, k2] = (1, 1);
        for (var i = k1; i < N; ++i)
        {
            for (var j = k2; j < N; ++j)
            {
                var probabilityHalf = probabilities[i, j] * baseProbability;
                probabilities[i + 1, j] += probabilityHalf;
                probabilities[i, j + 1] += probabilityHalf;
            }
        }

        var probability1 = (Fraction)default;
        for (var j = k2; j < N; ++j)
        {
            probability1 += probabilities[N, j];
        }

        var probability2 = (Fraction)default;
        for (var i = k1; i < N; ++i)
        {
            probability2 += probabilities[i, N];
        }

        if (
            S % probability1.Denominator != 0
            || S % probability2.Denominator != 0
        )
        {
            throw new Lab1SolvingException(Lab1SolvingError.ImpossibleDividePrize);
        }
        return (
            S * probability1.Numerator / probability1.Denominator,
            S * probability2.Numerator / probability2.Denominator
        );
    }
}
