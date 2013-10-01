using System;

namespace Api.Getty.Exceptions
{
    public class SecurityTokenExpiredException : Exception
    {
        public override string Message
        {
            get
            {
                return "The security token has expired.";
            }
        }
    }
}
