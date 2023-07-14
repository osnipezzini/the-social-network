using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSN.Application.Exceptions;


[Serializable]
public class AuthenticationServiceException : Exception
{
	public AuthenticationServiceException() { }
	public AuthenticationServiceException(string message) : base(message) { }
    public AuthenticationServiceException(string message, IEnumerable<IdentityError> errors)
        : base(message)
    {
        Errors = errors;
    }
    public AuthenticationServiceException(IEnumerable<IdentityError> errors)
    {
        Errors = errors;
    }

    public AuthenticationServiceException(string message, Exception inner) : base(message, inner) { }
	protected AuthenticationServiceException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    public IEnumerable<IdentityError> Errors { get; } = Array.Empty<IdentityError>();
}
