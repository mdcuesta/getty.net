﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Getty.Requests
{
    class SearchForImagesRequest
    {
        public RequestHeader RequestHeader { get; set; }

        public SearchForImages2RequestBody SearchForImages2RequestBody { get; set; }
    }
}
