using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class SearchForVideosRequestBody
    {
        public VideoSearchFilter Filter { get; set; }

        public string Language { get; set; }

        public Query Query { get; set; }

        public ResultOptions ResultOptions { get; set; }
    }
}
