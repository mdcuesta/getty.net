using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
