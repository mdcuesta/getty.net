using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Responses
{
    class GetLargestImageDownloadAuthorizationsResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public GetImageDownloadAuthorizationsResult GetLargestImageDownloadAuthorizationsResult { get; set; }
    }
}
