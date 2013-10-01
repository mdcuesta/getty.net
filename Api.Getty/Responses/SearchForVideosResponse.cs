namespace Api.Getty.Responses
{
    class SearchForVideosResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public SearchForVideosResult SearchForVideosResult { get; set; }
    }
}
