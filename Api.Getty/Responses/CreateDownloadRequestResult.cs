using System.Collections.Generic;
using Api.Getty.Models;

namespace Api.Getty.Responses
{
    public class CreateDownloadRequestResult
    {
        public List<DownloadUrl> DownloadUrls { get; set; }
    }
}
