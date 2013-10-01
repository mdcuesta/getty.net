namespace Api.Getty.Responses
{
    class RenewSessionResult
    {
        public string SecureToken { get; set; }

        public string Token { get; set; }

        public int TokenDurationMinutes { get; set; }

        public AuthToken ToAuthToken()
        {
            return new AuthToken 
            { 
                SecureToken = SecureToken,
                TokenDurationMinutes = TokenDurationMinutes,
                Token = Token
            };
        }
    }
}
