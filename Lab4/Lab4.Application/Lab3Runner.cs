using System.Diagnostics.CodeAnalysis;
using Lab4.Solving.Lab3;

namespace Lab4.Application;

using static Statics;

internal static class Lab3Runner
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

        var result = NegativeCycleIdentifier.HasNegativeCycle(input.Matrix);
        return result ? "YES" : "NO";
    }
}

internal class Input
{
    private Input(AdjacencyMatrix matrix)
    {
        Matrix = matrix;
    }


    public AdjacencyMatrix Matrix { get; }


    public static Input Parse(IEnumerator<string> lines)
    {
        if (!lines.MoveNext())
        {
            throw new InputException("The input does not contain the number of nodes in the graph.");
        }
        if (!(int.TryParse(lines.Current, out var size) && size > 0))
        {
            throw new InputException("Invalid number of graph nodes.");
        }

        var matrix = new float[size, size];
        for (var i = 0; i < size; ++i)
        {
            if (!lines.MoveNext())
            {
                ThrowRowInputException("The input does not contain row.");
            }
            var valueStrings = lines.Current.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (valueStrings.Length != size)
            {
                ThrowRowInputException($"Expected {size} values, but received {valueStrings.Length}.");
            }

            for (var j = 0; j < size; ++j)
            {
                if (!float.TryParse(valueStrings[j], out var value))
                {
                    ThrowValueInputException("Invalid value.");
                }
                if (i == j && value != 0F)
                {
                    ThrowValueInputException("The value on the main diagonal must be zero.");
                }
                if (value == WithoutPathValue)
                {
                    matrix[i, j] = value = float.PositiveInfinity;
                }
                else if (float.Abs(value) > MaxValue)
                {
                    ThrowValueInputException($"The value cannot be greater than '{MaxValue}' in modulus.");
                }
                else
                {
                    matrix[i, j] = value;
                }
                if (i > j && value != matrix[j, i])
                {
                    ThrowValueInputException("Values symmetrical about the main diagonal must be equal.");
                }
                continue;


                [DoesNotReturn]
                void ThrowValueInputException(string message)
                {
                    throw new InputException($"Row {i + 1}, column {j + 1}. {message}");
                }
            }
            continue;


            [DoesNotReturn]
            void ThrowRowInputException(string message)
            {
                throw new InputException($"Row {i + 1}. {message}");
            }
        }

        return new Input(new AdjacencyMatrix(matrix));
    }
}

file static class Statics
{
    public const float
        WithoutPathValue = 100_000F,
        MaxValue = 10_000F;
}
