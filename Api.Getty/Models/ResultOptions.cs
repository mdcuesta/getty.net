namespace Api.Getty.Models
{
    public class ResultOptions
    {
        public bool IncludeKeywords { get; set; }

        public int ItemCount { get; set; }

        public int ItemStartNumber { get; set; }

        public int ItemTotalCount { get; set; }

        public string RefinementOptionsSet { get; set; }

        public string SortOrder { get; set; }
    }
}
