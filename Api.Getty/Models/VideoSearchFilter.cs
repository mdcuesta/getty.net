using System.Collections.Generic;

namespace Api.Getty.Models
{
    public class VideoSearchFilter
    {
        public List<string> AssetFamilies { get; set; }

        public Collections Collections { get; set; }

        public bool ExcludeNudity { get; set; }

        public List<string> Formats { get; set; }   
    }
}
