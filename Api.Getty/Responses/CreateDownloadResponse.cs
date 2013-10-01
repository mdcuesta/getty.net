namespace Api.Getty.Responses
{
    class CreateDownloadResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public CreateDownloadRequestResult CreateDownloadRequestResult { get; set; }
    }
}
