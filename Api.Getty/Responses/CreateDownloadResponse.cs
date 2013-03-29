using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Responses
{
    class CreateDownloadResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public CreateDownloadRequestResult CreateDownloadRequestResult { get; set; }
    }
}
