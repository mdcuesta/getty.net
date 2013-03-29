using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Responses
{
    class GetImageDetailsResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public GetImageDetailsResult GetImageDetailsResult { get; set; }
    }
}
