using Api.Getty.Models;

namespace Api.Getty.Requests
{
    public class SearchForImagesRequestBody
    {
        public Filter Filter { get; set; }

        public string Language { get; set; }

        public Query Query { get; set; }

        public ResultOptions ResultOptions { get; set; }
    }
}
