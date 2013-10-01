using System;

namespace Api.Getty.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public override string Message
        {
            get
            {
                return "Invalid Request";
            }
        }
    }
}
