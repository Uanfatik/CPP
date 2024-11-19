using Lab3.Solving;

namespace Lab3.Tests;

using static Statics;

public class Tests
{
    [Test]
    public void SuccessfulSolving1()
    {
        var matrixValues = new float[,]
        {
            { 0, -1 },
            { -1, 0 }
        };
        var result = NegativeCycleIdentifier.HasNegativeCycle(new AdjacencyMatrix(matrixValues));

        WriteInput(matrixValues);
        Console.WriteLine($"The result should be '{true}', received '{result}'.");
        Assert.That(result, Is.True);
    }


    [Test]
    public void SuccessfulSolving2()
    {
        var matrixValues = new float[,]
        {
            { 0, 1 },
            { 1, 0 }
        };
        var result = NegativeCycleIdentifier.HasNegativeCycle(new AdjacencyMatrix(matrixValues));

        WriteInput(matrixValues);
        Console.WriteLine($"The result should be '{false}', received '{result}'.");
        Assert.That(result, Is.False);
    }


    [Test]
    public void NotSquareMatrix()
    {
        var matrixValues = new float[,]
        {
            { 0, 1, 5 },
            { 1, 0, 5 }
        };

        WriteInput(matrixValues);
        Console.WriteLine($"'{nameof(ArgumentException)}' should be thrown out because the matrix is not square.");
        Assert.Throws<ArgumentException>(() =>
            NegativeCycleIdentifier.HasNegativeCycle(new AdjacencyMatrix(matrixValues))
        );
    }


    [Test]
    public void NotZeroDiagonalValue()
    {
        var matrixValues = new float[,]
        {
            { 20, 1 },
            { 1, 0 }
        };

        WriteInput(matrixValues);
        Console.WriteLine(
            $"'{nameof(ArgumentException)}' should be thrown out because the matrix has non-zero elements."
        );
        Assert.Throws<ArgumentException>(() =>
            NegativeCycleIdentifier.HasNegativeCycle(new AdjacencyMatrix(matrixValues))
        );
    }


    [Test]
    public void NotSymmetricValues()
    {
        var matrixValues = new float[,]
        {
            { 0, 1 },
            { 2, 0 }
        };

        WriteInput(matrixValues);
        Console.WriteLine(
            $"'{nameof(ArgumentException)}' should be thrown out because the matrix has asymmetric elements relative" +
            $" to the main diagonal."
        );
        Assert.Throws<ArgumentException>(() =>
            NegativeCycleIdentifier.HasNegativeCycle(new AdjacencyMatrix(matrixValues))
        );
    }
}

file static class Statics
{
    public static void WriteInput(float[,] matrix)
    {
        var matrixText = "";
        for (var i = 0; i < matrix.GetLength(0); ++i)
        {
            if (i != 0)
            {
                matrixText += Environment.NewLine;
            }

            for (var j = 0; j < matrix.GetLength(1); ++j)
            {
                if (j != 0)
                {
                    matrixText += " ";
                }

                matrixText += matrix[i, j];
            }
        }

        Console.WriteLine(
            $"""
             Checking with:
             {matrix.GetLength(0)}x{matrix.GetLength(1)}
             {matrixText}
             """
        );
    }
}
