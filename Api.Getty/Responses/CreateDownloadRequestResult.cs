using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Getty.Models;

namespace Api.Getty.Responses
{
    public class CreateDownloadRequestResult
    {
        public List<DownloadUrl> DownloadUrls { get; set; }
    }
}
