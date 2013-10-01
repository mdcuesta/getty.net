using System.Collections.Generic;

namespace Api.Getty.Requests
{
    public class GetImageDetailsRequestBody
    {
        public string CountryCode { get; set; }

        public string Language { get; set; }

        public List<string> ImageIds { get; set; }
    }
}
