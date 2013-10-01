namespace Api.Getty.Requests
{
    class CreateSessionRequestBody
    {
        public string SystemId { get; set; }

        public string SystemPassword { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }
    }
}
