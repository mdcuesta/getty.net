using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Requests
{
    class CreateDownloadRequest
    {
        public RequestHeader RequestHeader { get; set; }

        public CreateDownloadRequestBody CreateDownloadRequestBody { get; set; }
    }
}
