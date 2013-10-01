using System.Collections.Generic;
using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class GetImageDownloadAuthorizationsRequestBody
    {
        public List<ImageSize> ImageSizes { get; set; }
    }
}
