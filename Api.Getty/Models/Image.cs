using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Getty.Models
{
    public class Image
    {
        public string ImageId { get; set; }

        public string Title { get; set; }

        public string ImageFamily { get; set; }

        public string CollectionName { get; set; }

        public DateTime DateCreated { get; set; }

        public string LicensingModel { get; set; }

        public string UrlThumb { get; set; }

        public string UrlPreview { get; set; }

        public List<SizesDownloadableImage> SizesDownloadableImages { get; set; }
    }
}
