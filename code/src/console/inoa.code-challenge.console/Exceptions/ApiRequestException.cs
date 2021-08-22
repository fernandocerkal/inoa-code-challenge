using System;

namespace inoa.code_challenge.console.Exceptions
{
    public class ApiRequestException : Exception
    {
        public ApiRequestException()
        {
        }

        public ApiRequestException(string message)
            : base(message)
        {
        }

        public ApiRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}