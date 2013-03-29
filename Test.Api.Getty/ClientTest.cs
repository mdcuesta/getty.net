using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Getty;
using Api.Getty.Models;
using Api.Getty.Responses;
using Api.Getty.Requests;

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
            searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1};
            SearchForImagesResult result = apiClient.Search(searchRequest);
            Assert.IsTrue(result.Images.Count == 1);            
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
                SystemId = "",
                SystemPassword = "",
                UserName = "",
                Password = "",
                ConnectionMode = ConnectionMode.Production
            };
        }
    }
}
