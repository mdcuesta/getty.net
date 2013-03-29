using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Api.Getty.Requests;
using RestSharp.Deserializers;
using Api.Getty.Responses;
using Api.Getty.Exceptions;

namespace Api.Getty
{
    /// <summary>
    /// Class which handles Getty Images REST API methods
    /// </summary>
    public partial class Client
    {
        #region Constants
        private const string STAGE_BASE_URL = "https://connect-stage.gettyimages.com/v1/";
        private const string PRODUCTION_BASE_URL = "https://connect.gettyimages.com/v1/";
        #endregion

        #region Variables
        private readonly RestClient _restClient;
        private readonly AuthInfo _authInfo;
        private AuthToken _authToken;
        #endregion

        #region Properties

        #region RestClient
        /// <summary>
        /// RestClient
        /// </summary>
        private RestClient RestClient 
        { 
            get 
            { 
                return _restClient; 
            } 
        }
        #endregion

        #region ConnectionMode
        /// <summary>
        /// Represents API client connection mode.
        /// </summary>
        public ConnectionMode ConnectionMode 
        {
            get
            {
                return _authInfo.ConnectionMode;
            }
            set 
            {
                _authInfo.ConnectionMode = value;
                if (_authInfo.ConnectionMode == Getty.ConnectionMode.Production)
                {
                    _restClient.BaseUrl = PRODUCTION_BASE_URL;
                }
                else if (_authInfo.ConnectionMode == Getty.ConnectionMode.Stage)
                {
                    _restClient.BaseUrl = STAGE_BASE_URL;
                }
            }    
        }
        #endregion

        #region AuthToken
        /// <summary>
        /// Authorization Token
        /// </summary>
        public AuthToken AuthToken
        {
            get
            {
                if (_authToken == null)
                {
                    CreateSession();
                }
                return _authToken;
            }
            set
            {
                _authToken = value;
            }
        }
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of an API client.
        /// </summary>
        /// <param name="authInfo">Authorization Info</param>
        public Client(AuthInfo authInfo)
            :this(authInfo, null)
        {          
        }

        /// <summary>
        /// Initializes a new instance of an API client.
        /// </summary>
        /// <param name="authInfo">Authorization Info</param>
        /// <param name="token">Existing Authorization Token</param>
        public Client(AuthInfo authInfo,
            AuthToken token)
        {
            if (authInfo == null)
                throw new ArgumentNullException("authInfo");

            _authInfo = authInfo;
            _restClient = new RestClient();
            ConnectionMode = authInfo.ConnectionMode; 
            _authToken = token;
        }
        #endregion

        #region Methods
        
        #region ExecuteRequests 

        #region ExecutePost
        /// <summary>
        /// Execute a POST request to Getty REST API
        /// </summary>
        /// <typeparam name="T">Generic Return Type</typeparam>
        /// <param name="request">RestRequest</param>
        /// <returns>T</returns>
        private T ExecutePost<T>(RestRequest request)
            where T : new()
        {
            if (request == null)
                throw new ArgumentNullException("request");

            request.Method = Method.POST;
            IRestResponse<T> response = RestClient.Execute<T>(request);

            if (response.Data == null || 
                response.StatusCode == HttpStatusCode.InternalServerError ||
                response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new InvalidRequestException();
            }
            if (typeof(IGettyResponse).IsAssignableFrom(response.Data.GetType()))
            {
                CheckStatus((response.Data as IGettyResponse).ResponseHeader);
            }
            
            return response.Data;
        }
        #endregion         

        #region GetHeader
        /// <summary>
        /// Returns a Request Header which will be used in sending request to Getty REST API
        /// </summary>
        /// <param name="coordinationId">Coordination Id</param>
        /// <param name="useSecure">Use Secure Token Flag</param>
        /// <returns>RequestHeader</returns>
        private RequestHeader GetHeader(string coordinationId = null, bool useSecure = false)
        {
            string token = useSecure ? 
                AuthToken.SecureToken : 
                AuthToken.Token;

            return new RequestHeader 
            { 
                CoordinationId = coordinationId,
                Token = token
            };
        }   
        #endregion

        #region CreateRequest
        /// <summary>
        /// Creates a RestRequest with default settings for Getty Images REST API
        /// </summary>
        /// <returns>RestRequest</returns>
        private static RestRequest CreateRequest()
        {
            var request = new RestRequest { RequestFormat = DataFormat.Json };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.OnBeforeDeserialization = response => { response.ContentType = "application/json"; };
            return request;
        }
        #endregion

        #region CheckStatus
        /// <summary>
        /// Checks the status of the ResponseHeader returned by the Getty Images REST API
        /// </summary>
        /// <param name="responseHeader">ResponseHeader</param>
        private void CheckStatus(ResponseHeader responseHeader)
        {
            if (responseHeader.Status.ToLower() == "error")
            {
                if (responseHeader.StatusList.Count > 0)
                {
                    StatusEntry status = responseHeader.StatusList[0];
                    if (status.Message == "The security token has expired.")
                        throw new SecurityTokenExpiredException();
                }
                throw responseHeader.ToResponseErrorException();
            }
        }
        #endregion

        #endregion

        #endregion
    }
}
