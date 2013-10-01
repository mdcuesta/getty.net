using System.Collections.Generic;
using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class CreateDownloadRequestBody
    {
        public List<DownloadItem> DownloadItems { get; set; }
    }
}
