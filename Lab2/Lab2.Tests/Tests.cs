using System.Numerics;
using Lab2.Solving;

namespace Lab2.Tests;

using static Statics;

public class Tests
{
    [Test]
    [TestCase(0, 1)]
    [TestCase(1, 0)]
    [TestCase(2, 3)]
    [TestCase(3, 0)]
    [TestCase(4, 11)]
    [TestCase(5, 0)]
    [TestCase(6, 41)]
    public void SuccessfulSolving(int n, int expectedInt)
    {
        var expected = (BigInteger)expectedInt;
        var result = ChocolateSplitter.Split(n);

        WriteInput(n);
        Console.WriteLine($"The result should be '{expected}', received '{result}'.");
        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    [TestCase(-1)]
    public void ArgumentOutOfRangeExceptionInput(int n)
    {
        WriteInput(n);
        Console.WriteLine($"An '{nameof(ArgumentOutOfRangeException)}' should be thrown.");
        Assert.Throws<ArgumentOutOfRangeException>(() => ChocolateSplitter.Split(n));
    }
}

file static class Statics
{
    public static void WriteInput(int n)
    {
        Console.WriteLine(
            $"""
             Checking with:
             n = '{n}'
             """
        );
    }
}
