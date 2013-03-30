using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Getty.Responses;
using Api.Getty.Requests;
using RestSharp;

namespace Api.Getty
{
    public partial class Client
    {  
        #region Search
        /// <summary>
        /// Search for Images
        /// </summary>
        /// <param name="imageSearchRequest">Search for Images Request</param>
        /// <returns>SearchForImagesResult</returns>
        public SearchForImagesResult Search(SearchForImages2RequestBody imageSearchRequest)
        {
            RestRequest request = CreateRequest();
            request.Resource = "search/SearchForImages";

            var searchRequest = new SearchForImagesRequest
            {
                RequestHeader = GetHeader(),
                SearchForImages2RequestBody = imageSearchRequest
            };

            request.AddBody(searchRequest);
            SearchForImagesResponse response = ExecutePost<SearchForImagesResponse>(request);
            return (response == null) ? null : response.SearchForImagesResult;
        }
        #endregion

        #region SearchForVideos
        /// <summary>
        /// Search for Videos
        /// </summary>
        /// <param name="videoSearchRequest">Search for Videos Request</param>
        /// <returns>SearchForVideosResult</returns>
        public SearchForVideosResult SearchForVideos(SearchForVideosRequestBody videoSearchRequest)
        {
            RestRequest request = CreateRequest();               
            request.Resource = "search/SearchForVideos";

            var searchRequest = new SearchForVideosRequest
            {
                RequestHeader = GetHeader(),
                SearchForVideosRequestBody = videoSearchRequest
            };

            request.AddBody(searchRequest);
            SearchForVideosResponse response = ExecutePost<SearchForVideosResponse>(request);
            return (response == null) ? null : response.SearchForVideosResult;
        }
        #endregion

        #region GetDetails
        /// <summary>
        /// Get Images Details
        /// </summary>
        /// <param name="imageDetailsRequest">Get Image Details Request Body</param>
        /// <returns>GetImageDetailsResult</returns>
        public GetImageDetailsResult GetDetails(GetImageDetailsRequestBody imageDetailsRequest)
        {
            RestRequest request = CreateRequest();
            request.Resource = "search/GetImageDetails";

            var getImageDetailsRequest = new GetImageDetailsRequest
            {
                RequestHeader = GetHeader(),
                GetImageDetailsRequestBody = imageDetailsRequest
            };

            request.AddBody(getImageDetailsRequest);
            GetImageDetailsResponse response = ExecutePost<GetImageDetailsResponse>(request); 
            return (response == null) ? null : response.GetImageDetailsResult;
        }
        #endregion
    }
}
