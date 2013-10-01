namespace Api.Getty.Responses
{
    class RenewSessionResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public RenewSessionResult RenewSessionResult { get; set; }
    }
}
