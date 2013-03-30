using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Models
{
    public class Video
    {
        public List<string> AspectRatios { get; set; }

        public string AssetFamily { get; set; }

        public string AssetId { get; set; }

        public List<string> AuthorizationConstraints { get; set; }

        public string Caption { get; set; }

        public string ClipLength { get; set; }

        public string CollectionId { get; set; }

        public string CollectionName { get; set; }

        public string Color { get; set; }

        public string Copyright { get; set; }

        public DateTime DateCreated { get; set; }

        public List<SizesDownloadableVideo> DownloadSizes { get; set; }

        public string Era { get; set; }

        public string FilmMaker { get; set; }

        public List<Keyword> Keywords { get; set; }

        public string LicenseType { get; set; }

        public string MasteredTo { get; set; }

        public string OriginallyShotOn { get; set; }

        public string Release { get; set; }

        public List<string> Restrictions { get; set; }

        public string ShotSpeed { get; set; }

        public string Source { get; set; }

        public Urls Urls { get; set; }

    }

    public class Keyword
    {  
        public string KeywordId { get; set; }

        public int KeywordWeight { get; set; }

        public string Text { get; set; }

        public string Type { get; set; } 
    }

    public class Urls
    {
        public string Comp { get; set; }

        public string FlashPreview { get; set; }

        public string Thumb { get; set; }

        public List<StoryBoard> StoryBoard { get; set; }
    }

    public class StoryBoard
    {
        public string ImageUrl { get; set; }

        public int SequenceNumber { get; set; }
    }
}
