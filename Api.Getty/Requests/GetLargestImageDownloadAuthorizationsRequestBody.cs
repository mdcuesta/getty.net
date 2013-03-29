using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class GetLargestImageDownloadAuthorizationsRequestBody
    {
        public List<Image> Images { get; set; }
    }
}
