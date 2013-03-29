using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Getty.Responses
{
    class SearchForImagesResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public SearchForImagesResult SearchForImagesResult { get; set; }
    }
}
