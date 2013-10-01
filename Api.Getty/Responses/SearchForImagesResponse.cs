namespace Api.Getty.Responses
{
    class SearchForImagesResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public SearchForImagesResult SearchForImagesResult { get; set; }
    }
}
