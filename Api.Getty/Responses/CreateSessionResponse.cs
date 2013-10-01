namespace Api.Getty.Responses
{
    class CreateSessionResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public CreateSessionResult CreateSessionResult { get; set; }
    }
}
