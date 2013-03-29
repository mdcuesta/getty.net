using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
