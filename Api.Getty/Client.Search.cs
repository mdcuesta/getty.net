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
        public SearchForImagesResult Search(SearchForImagesRequestBody imageSearchRequest)
        {
            RestRequest request = CreateRequest();
            request.Resource = "search/SearchForImages";

            var searchRequest = new SearchForImagesRequest
            {
                RequestHeader = GetHeader(),
                SearchForImagesRequestBody = imageSearchRequest
            };

            request.AddBody(searchRequest);
            var response = ExecutePost<SearchForImagesResponse>(request);
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
            var response = ExecutePost<SearchForVideosResponse>(request);
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
            var response = ExecutePost<GetImageDetailsResponse>(request); 
            return (response == null) ? null : response.GetImageDetailsResult;
        }
        #endregion
    }
}
