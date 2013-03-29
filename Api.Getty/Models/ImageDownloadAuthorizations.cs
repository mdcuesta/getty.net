using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Models
{
    public class ImageDownloadAuthorizations
    {
        public List<Authorization> Authorizations { get; set; }

        public string ImageId { get; set; }

        public string SizeKey { get; set; }

        public string Status { get; set; }
    }
}
