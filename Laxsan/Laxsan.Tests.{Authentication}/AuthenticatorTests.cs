
namespace Laxsan.Tests._Authentication_
{
    using Laxsan.DataAccess;
    using Laxsan.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuthenticatorTests
    {
        [TestMethod]
        public void ShouldLogin_UserIsAuthorized_ReturnTrue()
        {
            //Arrangement
            IUnitOfWork unitOfWork = new UnitOfWork();
            Authenticator authenticator = new Authenticator(unitOfWork);
            var user = new User()
            {
                UserName = "admin",
                Password = "admin"
            };

            //Action
            var result = authenticator.Authenticate(user);

            //Assertion
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldLogin_UserIsUnAuthorized_ReturnFalse()
        {
            //Arrangement
            IUnitOfWork unitOfWork = new UnitOfWork();
            Authenticator authenticator = new Authenticator(unitOfWork);
            var user = new User()
            {
                UserName = "admin",
                Password = "admin2"
            };

            //Action
            var result = authenticator.Authenticate(user);

            //Assertion
            Assert.IsFalse(result);
        }
    }
}
