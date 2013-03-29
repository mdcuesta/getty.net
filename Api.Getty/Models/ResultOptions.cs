using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Getty.Models
{
    public class ResultOptions
    {
        public bool IncludeKeywords { get; set; }

        public int ItemCount { get; set; }

        public int ItemStartNumber { get; set; }

        public int ItemTotalCount { get; set; }

        public string RefinementOptionsSet { get; set; }
    }
}
