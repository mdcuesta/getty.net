using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Getty.Requests;

namespace Api.Getty.Requests
{
    class GetImageDetailsRequest
    {
        public RequestHeader RequestHeader { get; set; }

        public GetImageDetailsRequestBody GetImageDetailsRequestBody { get; set; }
    }
}
