using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Getty.Models;

namespace Api.Getty.Responses
{
    public class GetImageDownloadAuthorizationsResult
    {
        public List<ImageDownloadAuthorizations> Images { get; set; }
    }
}
