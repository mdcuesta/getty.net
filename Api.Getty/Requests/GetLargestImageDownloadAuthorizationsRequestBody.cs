using System.Collections.Generic;
using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class GetLargestImageDownloadAuthorizationsRequestBody
    {
        public List<Image> Images { get; set; }
    }
}
