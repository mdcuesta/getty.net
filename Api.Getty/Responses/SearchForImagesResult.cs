using System.Collections.Generic;
using Api.Getty.Models;

namespace Api.Getty.Responses
{
    public class SearchForImagesResult
    {
        public int ItemStartNumber { get; set; }

        public int ItemTotalCount { get; set; }

        public List<Image> Images { get; set; }
    }
}
