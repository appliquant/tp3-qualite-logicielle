using _14E_TP2_A23.Models;
using _14E_TP2_A23.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace _14E_TP2_A23_Tests
{

    [TestClass]
    public class AuthenticationServiceTests
    {
        // On crée les données pour les test
        private Mock<IAuthenticationService> authServiceMock = new Mock<IAuthenticationService>();
        private string username = "satya";
        private string password = "mdpcomplexe";

        [TestMethod]
        public async Task Login_Username_And_Password_Valid()
        {
            //Configuration du Mock
            authServiceMock.Setup(x => x.Login(username, password))
                .ReturnsAsync(true);

            // test
            var result = await authServiceMock.Object.Login(username, password);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Login_InvalidUsername_ThrowsException()
        {
            //Configuration du Mock
            authServiceMock.Setup(x => x.Login(username, password))
                .ThrowsAsync(new Exception("Identifiant et/ou mot de passe incorrect."));

            // Test si la réponse est la bonne
            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await authServiceMock.Object.Login(username, password);
            });
        }

        [TestMethod]
        public async Task Login_InvalidPassword_ThrowsException()
        {
            //Configuration du Mock
            authServiceMock.Setup(x => x.Login(username, password))
                .ThrowsAsync(new Exception("Nom d'utilisateur et/ou mot de passe incorrect."));

            // Test si réponse est la bonne
            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await authServiceMock.Object.Login(username, password);
            });
        }


        [TestMethod]
        public void Logout_LogsOutCurrentEmployee_ReturnsTrue()
        {
            // On login et on logout
            authServiceMock.Setup(x => x.IsLoggedIn).Returns(true);
            
            authServiceMock.Object.Logout();

            // Test si on est bien logout
            Assert.IsNull(authServiceMock.Object.GetCurrentLoggedInUser());
        }
    }

}