namespace Lab3.Solving;

internal static class FloydWarshallAlgorithm
{
    public static float[,] Calculate(AdjacencyMatrix matrix)
    {
        var values = matrix.ToArray();

        for (var k = 1; k < matrix.Size; ++k)
        {
            for (var i = 0; i < matrix.Size; ++i)
            {
                for (var j = 0; j < matrix.Size; ++j)
                {
                    values[i, j] = Math.Min(values[i, j], values[i, k] + values[k, j]);
                }
            }
        }

        return values;
    }
}
