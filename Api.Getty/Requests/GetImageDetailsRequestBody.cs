using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Requests
{
    public class GetImageDetailsRequestBody
    {
        public string CountryCode { get; set; }

        public string Language { get; set; }

        public List<string> ImageIds { get; set; }
    }
}
