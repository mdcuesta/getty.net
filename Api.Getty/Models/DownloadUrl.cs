using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Models
{
    public class DownloadUrl
    {
        public string ImageId { get; set; }

        public string SizeName { get; set; }

        public string Status { get; set; }

        public string UrlAttachment { get; set; } 
    }
}
