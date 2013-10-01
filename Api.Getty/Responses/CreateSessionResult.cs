namespace Api.Getty.Responses
{
    class CreateSessionResult
    {   
        public string SecureToken { get; set; }

        public string Token { get; set; }

        public int TokenDurationMinutes { get; set; }

        public AuthToken ToAuthToken()
        {
            return new AuthToken
            {
                SecureToken = SecureToken,
                Token = Token,
                TokenDurationMinutes = TokenDurationMinutes
            };
        }
    }
}
