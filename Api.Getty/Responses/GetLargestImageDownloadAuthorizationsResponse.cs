namespace Api.Getty.Responses
{
    class GetLargestImageDownloadAuthorizationsResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public GetImageDownloadAuthorizationsResult GetLargestImageDownloadAuthorizationsResult { get; set; }
    }
}
