using System.Numerics;
using Lab1.Solving;

namespace Lab1.Tests;

using static Statics;

public class Tests
{
    [Test]
    [TestCase(3, 1, 2, 16, 4, 12)]
    [TestCase(4, 1, 1, 2, 1, 1)]
    [TestCase(5, 1, 4, 32, 2, 30)]
    public void SuccessfulSolving(int n, int k1, int k2, int s, int expectedS1Int, int expectedS2Int)
    {
        var expectedS1 = (BigInteger)expectedS1Int;
        var expectedS2 = (BigInteger)expectedS2Int;
        var distributor = new PrizeDistributor(n, s);
        var (s1, s2) = distributor.Distribute(k1, k2);

        WriteInput(n, k1, k2, s);
        Console.WriteLine($"The result should be '{expectedS1} {expectedS2}', received '{s1} {s2}'.");
        Assert.Multiple(() =>
        {
            Assert.That(expectedS1, Is.EqualTo(s1));
            Assert.That(expectedS2, Is.EqualTo(s2));
        });
    }


    [Test]
    [TestCase(-1, 1, 1, 1)]
    [TestCase(1, -1, 1, 1)]
    [TestCase(1, 1, -1, 1)]
    [TestCase(1, 1, 1, -1)]
    public void ArgumentOutOfRangeExceptionInput(int n, int k1, int k2, int s)
    {
        WriteInput(n, k1, k2, s);
        Console.WriteLine($"An '{nameof(ArgumentOutOfRangeException)}' should be thrown.");
        Assert.Throws<ArgumentOutOfRangeException>(() => new PrizeDistributor(n, s).Distribute(k1, k2));
    }


    [Test]
    [TestCase(10, 11, 1, 1)]
    [TestCase(10, 1, 11, 1)]
    public void InvalidOperationExceptionInput(int n, int k1, int k2, int s)
    {
        WriteInput(n, k1, k2, s);
        Console.WriteLine($"An '{nameof(InvalidOperationExceptionInput)}' should be thrown.");
        Assert.Throws<InvalidOperationException>(() => new PrizeDistributor(n, s).Distribute(k1, k2));
    }
}

file static class Statics
{
    public static void WriteInput(int n, int k1, int k2, int s)
    {
        Console.WriteLine(
            $"""
             Checking with:
             n = '{n}'
             k1 = '{k1}'
             k2 = '{k2}'
             s = '{s}'
             """
        );
    }
}
