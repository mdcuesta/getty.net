using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Getty;
using Api.Getty.Models;
using Api.Getty.Responses;
using Api.Getty.Requests;
using System.Collections.Generic;

namespace Test.Api.Getty
{
    [TestClass]
    public class ClientTest
    {
        private AuthToken _authToken;

        [TestMethod]
        public void TestCreateSession()
        {
            AuthInfo authInfo = GetAuthInfo();

            var apiClient = new Client(authInfo);
            apiClient.CreateSession();
            _authToken = apiClient.AuthToken;

            Assert.IsTrue(_authToken != null);
        }

        [TestMethod]
        public void TestRenewSession()
        {
            AuthInfo authInfo = GetAuthInfo();
            AuthToken authToken = GetAuthToken();
            
            DateTime dateRenewed = authToken.DateRenewed;

            var apiClient = new Client(authInfo, authToken);
            apiClient.RenewSession();

            DateTime newDateRenewed = apiClient.AuthToken.DateRenewed;

            Assert.IsTrue(newDateRenewed.CompareTo(dateRenewed) > 0);
        }

        [TestMethod]
        public void TestSearch()
        {
            AuthInfo authInfo = GetAuthInfo();
            AuthToken authToken = GetAuthToken();

            var apiClient = new Client(authInfo, authToken);

            var searchRequest = new SearchForImages2RequestBody();
            searchRequest.Query = new Query{ SearchPhrase ="sand" };
            searchRequest.ResultOptions = new ResultOptions { ItemCount = 50, ItemStartNumber = 1};
            searchRequest.Filter = new Filter
            {
                ImageFamilies = new List<string> { "Creative", "Editorial" },
                LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
            };

            SearchForImagesResult result = apiClient.Search(searchRequest);
            Assert.IsTrue(result.Images.Count == 50);            
        }

        [TestMethod]
        public void TestSearchPaging()
        {
            AuthInfo authInfo = GetAuthInfo();
            AuthToken authToken = GetAuthToken();

            int pageSize = 50;
            int page = 2;

            int startNumber = pageSize * (page - 1) + 1;

            var apiClient = new Client(authInfo, authToken);

            var searchRequest = new SearchForImages2RequestBody();
            searchRequest.Query = new Query 
            { 
                SearchPhrase = "sun" 
            };
            
            searchRequest.ResultOptions = new ResultOptions 
            { 
                ItemCount = pageSize, 
                ItemStartNumber = startNumber 
            };

            searchRequest.Filter = new Filter
            {
                ImageFamilies = new List<string> { "Creative", "Editorial" },
                LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
            };

            SearchForImagesResult result = apiClient.Search(searchRequest);

            Console.WriteLine(string.Format("Result Item Total Count: {0}", result.ItemTotalCount));
            Console.WriteLine(string.Format("Result Start Number: {0}", result.ItemStartNumber));
            Assert.IsTrue(result.Images.Count == 50);   
        }

        [TestMethod]
        public void TestSearchVideo()
        {
            AuthInfo authInfo = GetAuthInfo();
            AuthToken authToken = GetAuthToken();

            var apiClient = new Client(authInfo, authToken);

            var searchRequest = new SearchForVideosRequestBody();
            searchRequest.Query = new Query { SearchPhrase = "Man jumps onto rock" };
            searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1 };
            searchRequest.Filter = new VideoSearchFilter 
            { 
                AssetFamilies = new List<string> 
                { 
                    "Creative",
                    "Editorial"
                }
            };

            SearchForVideosResult result = apiClient.SearchForVideos(searchRequest);
            Assert.IsTrue(result.Videos.Count == 1); 
        }

        [TestMethod]
        public void TestGetImageDetails()
        {
            AuthInfo authInfo = GetAuthInfo();
            AuthToken authToken = GetAuthToken();

            var apiClient = new Client(authInfo, authToken);

            var searchRequest = new SearchForImages2RequestBody();
            searchRequest.Query = new Query { SearchPhrase = "sand" };
            searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1 };
            searchRequest.Filter = new Filter
            {
                ImageFamilies = new List<string> { "Creative", "Editorial" },
                LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
            };

            SearchForImagesResult searchResult = apiClient.Search(searchRequest);

            var imageIds = new List<string> { searchResult.Images[0].ImageId };

            var imageDetailRequestBody = new GetImageDetailsRequestBody
            {
                ImageIds = imageIds
            };

            GetImageDetailsResult imageDetailResult = apiClient.GetDetails(imageDetailRequestBody);

            Image image = imageDetailResult.Images[0];
            foreach (var size in image.SizesDownloadableImages)
            {
                Console.WriteLine(string.Format("Resolution/DPI: {0}", size.ResolutionDpi));
                Console.WriteLine(string.Format("Size Key: {0}", size.SizeKey));
            }  

            Assert.IsTrue(imageDetailResult.Images.Count == 1);   
        }

        [TestMethod]
        public void TestGetImageDownloadAuthorization()
        {
            AuthInfo authInfo = GetAuthInfo();
            AuthToken authToken = GetAuthToken();

            var apiClient = new Client(authInfo, authToken);

            var searchRequest = new SearchForImages2RequestBody();
            searchRequest.Query = new Query { SearchPhrase = "sand" };
            searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1 };
            searchRequest.Filter = new Filter
            {
                ImageFamilies = new List<string> { "Creative", "Editorial" },
                LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
            };

            SearchForImagesResult searchResult = apiClient.Search(searchRequest);

            var imageIds = new List<string> { searchResult.Images[0].ImageId };

            var imageDetailRequestBody = new GetImageDetailsRequestBody
            {
                ImageIds = imageIds
            };

            GetImageDetailsResult imageDetailResult = apiClient.GetDetails(imageDetailRequestBody);

            Image image = imageDetailResult.Images[0];
            SizesDownloadableImage imageSize = image.SizesDownloadableImages[0];              


            var downloadAuthorizationRequestBody = new GetImageDownloadAuthorizationsRequestBody
            {
                ImageSizes = new List<ImageSize> 
                { 
                    new ImageSize 
                    { 
                        ImageId = image.ImageId, 
                        SizeKey = imageSize.SizeKey 
                    }                
                }    
            };

            GetImageDownloadAuthorizationsResult result = 
                apiClient.GetImageDownloadAuthorizations(downloadAuthorizationRequestBody);

            Console.WriteLine(result.Images[0].Authorizations[0].DownloadToken);

            Assert.IsTrue(result.Images.Count == 1);
            Assert.IsFalse(string.IsNullOrEmpty(result.Images[0].Authorizations[0].DownloadToken)); 
        }

        [TestMethod]
        public void TestGetLargestImageDownloadAuthorization()
        {
            AuthInfo authInfo = GetAuthInfo();
            AuthToken authToken = GetAuthToken();

            var apiClient = new Client(authInfo, authToken);

            var searchRequest = new SearchForImages2RequestBody();
            searchRequest.Query = new Query { SearchPhrase = "sand" };
            searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1 };
            searchRequest.Filter = new Filter
            {
                ImageFamilies = new List<string> { "Creative", "Editorial" },
                LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
            };

            SearchForImagesResult searchResult = apiClient.Search(searchRequest);

            var imageIds = new List<string> { searchResult.Images[0].ImageId };

            var imageDetailRequestBody = new GetImageDetailsRequestBody
            {
                ImageIds = imageIds
            };

            GetImageDetailsResult imageDetailResult = apiClient.GetDetails(imageDetailRequestBody);

            Image image = imageDetailResult.Images[0];     

            var downloadAuthorizationRequestBody = new GetLargestImageDownloadAuthorizationsRequestBody
            {
                Images = new List<Image> { image }
            };

            GetImageDownloadAuthorizationsResult result =
                apiClient.GetLargestImageDownloadAuthorizations(downloadAuthorizationRequestBody);

            Console.WriteLine(result.Images[0].Authorizations[0].DownloadToken);

            Assert.IsTrue(result.Images.Count == 1);
            Assert.IsFalse(string.IsNullOrEmpty(result.Images[0].Authorizations[0].DownloadToken)); 
        }

        [TestMethod]
        public void TestRequestDownload()
        {
            AuthInfo authInfo = GetAuthInfo();
            AuthToken authToken = GetAuthToken();

            var apiClient = new Client(authInfo, authToken);

            var searchRequest = new SearchForImages2RequestBody();
            searchRequest.Query = new Query { SearchPhrase = "sand" };
            searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1 };
            searchRequest.Filter = new Filter
            {
                ImageFamilies = new List<string> { "Creative", "Editorial" },
                LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
            };

            SearchForImagesResult searchResult = apiClient.Search(searchRequest);

            var imageIds = new List<string> { searchResult.Images[0].ImageId };

            var imageDetailRequestBody = new GetImageDetailsRequestBody
            {
                ImageIds = imageIds
            };

            GetImageDetailsResult imageDetailResult = apiClient.GetDetails(imageDetailRequestBody);

            Image image = imageDetailResult.Images[0];
            SizesDownloadableImage imageSize = image.SizesDownloadableImages[0];


            var downloadAuthorizationRequestBody = new GetImageDownloadAuthorizationsRequestBody
            {
                ImageSizes = new List<ImageSize> 
                { 
                    new ImageSize 
                    { 
                        ImageId = image.ImageId, 
                        SizeKey = imageSize.SizeKey 
                    }                
                }
            };

            GetImageDownloadAuthorizationsResult authorizationResult =
                apiClient.GetImageDownloadAuthorizations(downloadAuthorizationRequestBody);

            string downloadToken = authorizationResult.Images[0].Authorizations[0].DownloadToken;

            var createDownloadRequestBody = new CreateDownloadRequestBody
            {
                DownloadItems = new List<DownloadItem> 
                {
                    new DownloadItem { DownloadToken = downloadToken }
                }
            };

            CreateDownloadRequestResult result = apiClient.RequestDownload(createDownloadRequestBody);

            Console.WriteLine(result.DownloadUrls[0].UrlAttachment);

            Assert.IsFalse(string.IsNullOrEmpty(result.DownloadUrls[0].UrlAttachment));
        }

        private AuthToken GetAuthToken()
        {
            if (_authToken == null)
            {
                var authInfo = GetAuthInfo();

                var apiClient = new Client(authInfo);
                _authToken = apiClient.AuthToken;
            }
            return _authToken;
        }

        private AuthInfo GetAuthInfo()
        {
            return new AuthInfo
            {
                SystemId = "your_system_id",
                SystemPassword = "your_system_password",
                UserName = "some_username",
                Password = "some_password",
                ConnectionMode = ConnectionMode.Production
            };
        }
    }
}
