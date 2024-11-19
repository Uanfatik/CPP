using System.Diagnostics;

namespace Lab1.Solving;

public class SolvingException : Exception
{
    internal SolvingException(
        SolvingError error,
        string? message = null,
        Exception? innerException = null
    ) : base(message, innerException)
    {
        Debug.Assert(Enum.IsDefined(error));

        Error = error;
    }


    public SolvingError Error { get; }
}
