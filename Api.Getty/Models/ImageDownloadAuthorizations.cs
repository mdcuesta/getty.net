using System.Collections.Generic;

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
