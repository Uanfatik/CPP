namespace Lab3.Solving;

public static class NegativeCycleIdentifier
{
    public static bool HasNegativeCycle(AdjacencyMatrix matrix)
    {
        var values = FloydWarshallAlgorithm.Calculate(matrix);
        for (var i = 0; i < matrix.Size; ++i)
        {
            if (values[i, i] < 0F)
            {
                return true;
            }
        }

        return false;
    }
}
