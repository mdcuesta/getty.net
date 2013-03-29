using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class CreateDownloadRequestBody
    {
        public List<DownloadItem> DownloadItems { get; set; }
    }
}
