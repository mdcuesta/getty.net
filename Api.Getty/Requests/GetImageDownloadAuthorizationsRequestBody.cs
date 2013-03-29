using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class GetImageDownloadAuthorizationsRequestBody
    {
        public List<ImageSize> ImageSizes { get; set; }
    }
}
