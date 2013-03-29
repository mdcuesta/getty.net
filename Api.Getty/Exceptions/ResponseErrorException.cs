using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Getty.Responses;

namespace Api.Getty.Exceptions
{
    public class ResponseErrorException : Exception
    {
        public string Status { get; set; }

        public List<StatusEntry> StatusList { get; set; }

        public string CoordinationId { get; set; }
    }
}
