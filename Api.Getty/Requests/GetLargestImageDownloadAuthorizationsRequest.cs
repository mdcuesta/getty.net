using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Requests
{
    class GetLargestImageDownloadAuthorizationsRequest
    {
        public RequestHeader RequestHeader { get; set; }

        public GetLargestImageDownloadAuthorizationsRequestBody GetLargestImageDownloadAuthorizationsRequestBody { get; set; }
    }
}
