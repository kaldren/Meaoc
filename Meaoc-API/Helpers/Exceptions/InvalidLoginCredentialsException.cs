using System;

namespace Meaoc_API.Helpers.Exceptions
{
    public class InvalidLoginCredentialsException : Exception
    {
        public InvalidLoginCredentialsException()
        {
        }

        public InvalidLoginCredentialsException(string message) : base(message)
        {
        }

        public InvalidLoginCredentialsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}