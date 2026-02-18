namespace HireHub.Shared.Common.Exceptions;

public class CommonException : Exception
{
    public CommonException() { }

    public CommonException(string? message) : base(message) { }

    public CommonException(string? message, Exception? innerException) 
        : base(message, innerException) { }
}
