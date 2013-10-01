using System;
using RestSharp;
using Api.Getty.Requests;
using Api.Getty.Responses;

namespace Api.Getty
{
    public partial class Client
    {
        #region RenewSession
        /// <summary>
        /// Renew client authorization token
        /// </summary>
        public void RenewSession()
        {
            RestRequest request = CreateRequest();
            request.Resource = "session/RenewSession";

            var renewSessionRequest = new RenewSessionRequest
            {
                RequestHeader = GetHeader(useSecure: true),
                RenewSessionRequestBody = new RenewSessionRequestBody
                {
                    SystemId = _authInfo.SystemId,
                    SystemPassword = _authInfo.SystemPassword
                }
            };

            // populate date renewed before sending request to make sure
            // that the 30 minutes token duration is earlier than the request
            var dateRenewed = DateTime.Now;

            request.AddBody(renewSessionRequest);
            var response = ExecutePost<RenewSessionResponse>(request);

            if (response.RenewSessionResult == null)
                throw new Exception("");

            _authToken = response.RenewSessionResult.ToAuthToken();
            _authToken.DateRenewed = dateRenewed;
        } 
        #endregion

        #region CreateSession
        /// <summary>
        /// Requests an authorization token
        /// </summary>
        public void CreateSession()
        {
            _authToken = ExecuteCreateSession(_authInfo);
        }
        #endregion

        #region ExecuteCreateSession
        /// <summary>
        /// Executes a CreateSession Request
        /// </summary>
        /// <param name="authInfo">Authorization Info</param>
        /// <returns>AuthToken</returns>
        private AuthToken ExecuteCreateSession(AuthInfo authInfo)
        {
            RestRequest request = CreateRequest();
            request.RequestFormat = DataFormat.Json;
            
            request.Resource = "session/CreateSession";

            var sessionRequest = new CreateSessionRequest
            {
                RequestHeader = new RequestHeader(),
                CreateSessionRequestBody = authInfo.ToCreateSessionRequestBody()
            };

            // populate date renewed before sending request to make sure
            // that the 30 minutes token duration is earlier than the request
            var dateRenewed = DateTime.Now; 
            request.AddBody(sessionRequest);
            
            var response = ExecutePost<CreateSessionResponse>(request);

            AuthToken token = response.CreateSessionResult.ToAuthToken();
            token.DateRenewed = dateRenewed;
            return token;
        }
        #endregion
    }
}
