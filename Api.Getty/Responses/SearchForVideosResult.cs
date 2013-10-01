using System.Collections.Generic;
using Api.Getty.Models;

namespace Api.Getty.Responses
{
    public class SearchForVideosResult
    {
        public List<Video> Videos { get; set; }

        public int ItemCount { get; set; }

        public int ItemStartNumber { get; set; }

        public int ItemTotalCount { get; set; }
    }
}
