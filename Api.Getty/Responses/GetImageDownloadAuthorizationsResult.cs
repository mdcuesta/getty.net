using System.Collections.Generic;
using Api.Getty.Models;

namespace Api.Getty.Responses
{
    public class GetImageDownloadAuthorizationsResult
    {
        public List<ImageDownloadAuthorizations> Images { get; set; }
    }
}
