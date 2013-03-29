using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
