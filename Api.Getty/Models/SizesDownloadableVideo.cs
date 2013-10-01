using System.Collections.Generic;

namespace Api.Getty.Models
{
    public class SizesDownloadableVideo
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public List<Authorization> DownloadAuthorizations { get; set; }
    }
}
