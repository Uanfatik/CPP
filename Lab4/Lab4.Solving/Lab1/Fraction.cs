using System.Diagnostics;
using System.Numerics;

namespace Lab4.Solving.Lab1;

internal readonly struct Fraction
{
    private readonly BigInteger _denominator;


    public Fraction(BigInteger numerator, BigInteger denominator)
    {
        Debug.Assert(denominator != BigInteger.Zero);

        var greatestCommonDivisor = BigInteger.GreatestCommonDivisor(numerator, denominator);
        Numerator = denominator.Sign * numerator / greatestCommonDivisor;
        _denominator = denominator.Sign * denominator / greatestCommonDivisor;
    }


    public BigInteger Numerator { get; }

    public BigInteger Denominator => _denominator.IsZero ? BigInteger.One : _denominator;


    public static Fraction operator +(Fraction left, Fraction right)
    {
        return new Fraction(
            left.Numerator * right.Denominator + right.Numerator * left.Denominator,
            left.Denominator * right.Denominator
        );
    }


    public static Fraction operator *(Fraction left, Fraction right)
    {
        return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
    }


    public static implicit operator Fraction((BigInteger Numerator, BigInteger Denominator) tuple)
    {
        Debug.Assert(tuple.Denominator != BigInteger.Zero);

        return new Fraction(tuple.Numerator, tuple.Denominator);
    }
}
