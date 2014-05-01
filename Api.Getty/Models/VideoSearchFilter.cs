using System.Collections.Generic;

namespace Api.Getty.Models
{
    public class VideoSearchFilter
    {
        public List<string> AssetFamilies { get; set; }

        public string ClipType { get; set; } 

        public Collection Collections { get; set; }

        public bool ExcludeNudity { get; set; }

        public List<string> Formats { get; set; }   

        public List<string> LicensingModels { get; set; }
    }
}
