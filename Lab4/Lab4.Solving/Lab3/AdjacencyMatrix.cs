using System.Diagnostics.CodeAnalysis;

namespace Lab4.Solving.Lab3;

public readonly struct AdjacencyMatrix
{
    private readonly float[,]? _values;


    public AdjacencyMatrix(float[,] values)
    {
        var size = values.GetLength(0);
        if (size != values.GetLength(1))
        {
            throw new ArgumentException("The matrix must be square.", nameof(values));
        }

        for (var i = 0; i < size; ++i)
        {
            for (var j = 0; j < size; ++j)
            {
                var value = values[i, j];

                if (i == j && value != 0F)
                {
                    ThrowValueArgumentException("The value on the main diagonal must be zero.");
                }
                if (i > j && value != values[j, i])
                {
                    ThrowValueArgumentException("Values symmetrical about the main diagonal must be equal.");
                }
                continue;


                [DoesNotReturn]
                void ThrowValueArgumentException(string message)
                {
                    throw new ArgumentException(
                        $"Row {i}, column {j}. {message}",
                        nameof(values)
                    );
                }
            }
        }

        _values = (float[,])values.Clone();
    }


    public int Size => Values.GetLength(0);


    private float[,] Values => _values ?? Array2DExtended<float>.Empty;

    public float this[int i, int j] => Values[i, j];


    public float[,] ToArray()
    {
        return _values is null ? Array2DExtended<float>.Empty : (float[,])_values.Clone();
    }
}
