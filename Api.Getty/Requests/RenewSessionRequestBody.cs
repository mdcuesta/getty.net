namespace Api.Getty.Requests
{
    class RenewSessionRequestBody
    {
        public string SystemId { get; set; }

        public string SystemPassword { get; set; }

        public string UserId { get; set; }

        public string UserPassword { get; set; }
    }
}
