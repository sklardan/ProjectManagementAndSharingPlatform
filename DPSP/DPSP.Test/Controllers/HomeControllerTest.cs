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
using System.Web;

namespace DPSP.Test.Controllers
{
    /// <summary>
    /// Summary description for AccountControllerTest
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        private readonly IAccountService _accountService;
        private readonly HomeController _homeController;
        private readonly UnityContainer _container;
        private readonly Mock<IOwinContext> _owinContext;
        private readonly Mock<IUserStore<ApplicationUser>> _userStoreMock;
        private readonly ApplicationUserManager _applicationUserManager;

        public HomeControllerTest()
        {
            _container = new UnityContainer();
            new UnityConfig().Configure(_container);

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

            _homeController = new HomeController(_accountService);
            //_homeController.Request.SetOwinContext(_owinContext.Object);


        }

        [TestMethod]
        public void ResetPasswordTest()
        {
            var model = new ResetPasswordViewModel
            {
                Email = "a@b.cz",
                Password = "Random1.",
                ConfirmPassword = "Random1.",
                Code = "wrongCode",
                NameAlready = true,
            };
            var result = _homeController.ResetPassword(model);
            //Assert.IsNull(result, "Result for non existing user should be null.");
        }

        //[TestMethod]
        //public void ResetPassword2Test()
        //{
        //    var model = new ResetPasswordViewModel { };
        //    model = null;
        //    var result = _homeController.ResetPassword(model);
        //    Assert.AreEqual(, "Result for non existing model should be null.");
        //}

        //[TestMethod]
        //public void ResetPasswordTest()
        //{
        //    var result = _projectService.GetUserProjects("NotExistingUserId");
        //    Assert.IsNull(result, "Result for non existing user should be null.");
        //}
    }
}
