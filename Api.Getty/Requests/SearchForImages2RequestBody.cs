using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class SearchForImages2RequestBody
    {
        public Filter Filter { get; set; }

        public string Language { get; set; }

        public Query Query { get; set; }

        public ResultOptions ResultOptions { get; set; }
    }
}
