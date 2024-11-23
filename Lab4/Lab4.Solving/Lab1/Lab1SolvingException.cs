using System.Diagnostics;

namespace Lab4.Solving.Lab1;

public class Lab1SolvingException : Exception
{
    internal Lab1SolvingException(
        Lab1SolvingError error,
        string? message = null,
        Exception? innerException = null
    ) : base(message, innerException)
    {
        Debug.Assert(Enum.IsDefined(error));

        Error = error;
    }


    public Lab1SolvingError Error { get; }
}
