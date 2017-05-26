using System;
using System.Net.Http;
using System.Threading.Tasks;
using DPSP_API;
using DPSP_API.Controllers;
using DPSP_BLL;
using DPSP_BLL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DPSP.Test.Controllers
{
    /// <summary>
    /// Summary description for AccountControllerTest
    /// </summary>
    [TestClass]
    public class AccountControllerTest
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly AccountController _accountController;
        private readonly UnityContainer _container;
        private readonly Mock<IOwinContext> _owinContext;
        private readonly Mock<IUserStore<ApplicationUser>> _userStoreMock;
        private readonly ApplicationUserManager _applicationUserManager;

        public AccountControllerTest()
        {
            _container = new UnityContainer();
            new UnityConfig().Configure(_container);
            
            _userService = _container.Resolve<IUserService>();
            _accountService = _container.Resolve<IAccountService>();
            
            
            _userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userStoreMock.Setup(s => s.FindByIdAsync("testId")).ReturnsAsync(new ApplicationUser
            {
                Id = "testId",
                Email = "test@email.com"
            });
            _userStoreMock.Setup(s => s.FindByNameAsync("testId")).ReturnsAsync(new ApplicationUser
            {
                Id = "testId",
                Email = "test@email.com"
            });

            _applicationUserManager = _applicationUserManager = new ApplicationUserManager(_userStoreMock.Object);
            _applicationUserManager.UserTokenProvider = new EmailTokenProvider<ApplicationUser>();

            _owinContext = new Mock<IOwinContext>();
            _owinContext.Setup(o => o.Get<ApplicationUserManager>(It.IsAny<string>())).Returns(_applicationUserManager);

            _accountController = new AccountController(_userService, _accountService);
            _accountController.Request = new HttpRequestMessage { RequestUri = new Uri("http://testingUri.com") };
            _accountController.Request.SetOwinContext(_owinContext.Object);

        }

        [TestMethod]
        public async Task CreationTest()
        {
            var model = new CreateUserBindingModel
            {
                Email = "a@b.cz",
                FirstName = "A",
                LastName = "B",
                Role = "Employee"
            };

            var result = await _accountController.Creation(model);
        }
    }
}
