﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Responses
{
    class GetImageDownloadAuthorizationsResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public GetImageDownloadAuthorizationsResult GetImageDownloadAuthorizationsResult { get; set; }
    }
}
