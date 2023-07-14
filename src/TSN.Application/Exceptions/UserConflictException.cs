namespace TSN.Application.Exceptions;


[Serializable]
public class UserConflictException : Exception
{
    public UserConflictException() { }
    public UserConflictException(string message) : base(message) { }
    public UserConflictException(string message, Exception inner) : base(message, inner) { }
    protected UserConflictException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
