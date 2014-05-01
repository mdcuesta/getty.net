using System.Collections.Generic;
using Api.Getty.Models;

namespace Api.Getty.Responses
{
    public class SearchForImagesResult
    {
        public int ItemStartNumber { get; set; }

        public int ItemTotalCount { get; set; }

        public int ItemCount { get; set; }

        public string EditorialSortOrder { get; set; }

        public string CreativeSortOrder { get; set; }

        public List<Image> Images { get; set; }

        public List<RefinementOption> RefinementOptions { get; set; }
    }
}
