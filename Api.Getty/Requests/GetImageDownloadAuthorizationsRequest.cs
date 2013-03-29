using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Requests
{
    class GetImageDownloadAuthorizationsRequest
    {
        public RequestHeader RequestHeader { get; set; }

        public GetImageDownloadAuthorizationsRequestBody GetImageDownloadAuthorizationsRequestBody { get; set; }
    }
}
