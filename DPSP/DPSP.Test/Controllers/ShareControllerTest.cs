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
using System.Collections.Generic;

namespace DPSP.Test.Controllers
{
    /// <summary>
    /// Summary description for AccountControllerTest
    /// </summary>
    [TestClass]
    public class ShareControllerTest
    {
        //private readonly IUserService _userService;
        private readonly IShareService _shareService;
        private readonly ShareController _shareController;
        private readonly UnityContainer _container;
        private readonly Mock<IOwinContext> _owinContext;
        private readonly Mock<IUserStore<ApplicationUser>> _userStoreMock;
        private readonly ApplicationUserManager _applicationUserManager;

        public ShareControllerTest()
        {
            _container = new UnityContainer();
            new UnityConfig().Configure(_container);

            _shareService = _container.Resolve<IShareService>();
            //_accountService = _container.Resolve<IAccountService>();


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

            _shareController = new ShareController(_shareService);
            _shareController.Request = new HttpRequestMessage { RequestUri = new Uri("http://testingUri.com") };
            _shareController.Request.SetOwinContext(_owinContext.Object);

        }

        [TestMethod]
        public async Task ShareProjectTest()
        {
            var guids = new List<Guid>();
            guids.Add(new Guid());
            var model = new EmailViewModel
            {
                Email = "a@b.cz",
                ProjectIds = guids
            };
            model = null;
            var result = await _shareController.ShareProject(model);
        }


    }
}
