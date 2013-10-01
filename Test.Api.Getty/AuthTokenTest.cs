using Api.Getty;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Api.Getty
{
    [TestClass]
    public class AuthTokenTest
    {
        [TestMethod]
        public void TokenNotExpiredTest()
        {
            var authToken = new AuthToken();
            authToken.TokenDurationMinutes = 30;
            Assert.IsTrue(!authToken.IsExpired);
        }
    }
}
