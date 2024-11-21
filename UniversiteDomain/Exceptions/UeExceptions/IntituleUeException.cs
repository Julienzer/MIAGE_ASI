namespace UniversiteDomain.Exceptions.UeExceptions;

public class IntituleUeException : Exception
{
    public IntituleUeException() : base() { }
    public IntituleUeException(string message) : base(message) { }
    public IntituleUeException(string message, Exception inner) : base(message, inner) { }   
}