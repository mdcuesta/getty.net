using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Getty.Models;
using Api.Getty.Requests;
using Api.Getty.Responses;
using RestSharp;

namespace Api.Getty
{
    public partial class Client
    {
        #region GetImageDownloadAuthorizations
        /// <summary>
        /// Get Image Download Authorizations
        /// </summary>
        /// <param name="downloadAuthorizationRequest">Download Authorization Request</param>
        /// <returns>GetImageDownloadAuthorizationsResult</returns>
        public GetImageDownloadAuthorizationsResult GetImageDownloadAuthorizations(GetImageDownloadAuthorizationsRequestBody downloadAuthorizationRequest)
        {
            RestRequest request = CreateRequest();
            request.Resource = "download/GetImageDownloadAuthorizations";

            var getDownloadAuthorizationsRequest = new GetImageDownloadAuthorizationsRequest
            {
                RequestHeader = GetHeader(),
                GetImageDownloadAuthorizationsRequestBody = downloadAuthorizationRequest
            };

            request.AddBody(getDownloadAuthorizationsRequest);
            GetImageDownloadAuthorizationsResponse response = ExecutePost<GetImageDownloadAuthorizationsResponse>(request);
            return (response == null) ? null : response.GetImageDownloadAuthorizationsResult;
        }
        #endregion

        #region GetLargestImageDownloadAuthorizations
        /// <summary>
        /// Get Largest Image Download Authorizations
        /// </summary>
        /// <param name="downloadAuthorizationRequest">Largest Image Download Authorization Request</param>
        /// <returns>GetImageDownloadAuthorizationsResult</returns>
        public GetImageDownloadAuthorizationsResult GetLargestImageDownloadAuthorizations(GetLargestImageDownloadAuthorizationsRequestBody downloadAuthorizationRequest)
        {
            RestRequest request = CreateRequest();
            request.Resource = "download/GetLargestImageDownloadAuthorizations";

            var getLargestImageDownloadAuthorizationsRequest = new GetLargestImageDownloadAuthorizationsRequest 
            { 
                RequestHeader = GetHeader(),
                GetLargestImageDownloadAuthorizationsRequestBody = downloadAuthorizationRequest
            };

            request.AddBody(getLargestImageDownloadAuthorizationsRequest);
            GetImageDownloadAuthorizationsResponse response = ExecutePost<GetImageDownloadAuthorizationsResponse>(request);
            return (response == null) ? null : response.GetImageDownloadAuthorizationsResult;
        }
        #endregion

        #region RequestDownload
        /// <summary>
        /// Request for Download
        /// </summary>
        /// <param name="downloadRequest">Image Download Request</param>
        /// <returns>CreateDownloadRequestResult</returns>
        public CreateDownloadRequestResult RequestDownload(CreateDownloadRequestBody downloadRequest)
        {
            RestRequest request = CreateRequest();
            request.Resource = "download/CreateDownloadRequest";

            var createDownloadRequest = new CreateDownloadRequest 
            {
                RequestHeader = GetHeader(useSecure: true),
                CreateDownloadRequestBody = downloadRequest            
            };

            request.AddBody(createDownloadRequest);
            CreateDownloadResponse response = ExecutePost<CreateDownloadResponse>(request);
            return (response == null) ? null : response.CreateDownloadRequestResult;
        }
        #endregion
    }
}
