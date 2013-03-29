using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Getty.Requests
{
    class RenewSessionRequest
    {
        public RequestHeader RequestHeader { get; set; }

        public RenewSessionRequestBody RenewSessionRequestBody { get; set; }
    }
}
