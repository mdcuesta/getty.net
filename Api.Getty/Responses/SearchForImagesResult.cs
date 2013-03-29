using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
