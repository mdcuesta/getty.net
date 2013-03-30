using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Responses
{
    class SearchForVideosResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public SearchForVideosResult SearchForVideosResult { get; set; }
    }
}
