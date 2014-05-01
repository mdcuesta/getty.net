using System;
using System.Collections.Generic;

namespace Api.Getty.Models
{
    public class Image
    {
        public string ImageId { get; set; }

        public List<string> ApplicableProductOfferings { get; set; }

        public string Artist { get; set; }

        public string ArtistTitle { get; set; }

        public List<string> AuthorizationConstraints { get; set; }

        public string Caption { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string StateProvince { get; set; }

        public string CreditLine { get; set; }

        public string CollectionId { get; set; }    

        public string ColorType { get; set; }      

        public string Copyright { get; set; }

        public string Title { get; set; }

        public string ImageFamily { get; set; }

        public string CollectionName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateSubmitted { get; set; }

        public List<string> EditorialSegments { get; set; }

        public string EditorialSourceId { get; set; }

        public string EditorialSourceName { get; set; }

        public int EventId { get; set; }

        public List<int> EventIds { get; set; }

        public string GraphicStyle { get; set; }

        public string LicensingModel { get; set; }

        public List<Keyword> Keywords { get; set; }

        public List<string> Orientations { get; set; }

        public int QualityRank { get; set; }

        public string UrlThumb { get; set; }

        public string UrlPreview { get; set; }

        public string UrlComp { get; set; }

        public string UrlEmbed { get; set; }

        public string UrlWatermarkComp { get; set; }

        public string UrlWatermarkPreview { get; set; }

        public List<ReferralDestination> ReferralDestinations { get; set; }

        public List<SizesDownloadableImage> SizesDownloadableImages { get; set; }

        public string ReleaseMessage { get; set; }

        public List<string> Restrictions { get; set; }
    }
}
