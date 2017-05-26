using System;
using System.Text;
using System.Collections.Generic;
using DPSP_BLL;
using DPSP_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPSP_BLL.Models;

namespace DPSP.Test.Services
{
    /// <summary>
    /// Summary description for ProjectServiceTest
    /// </summary>
    [TestClass]
    public class ProjectServiceTest
    {
        private IRoleService _roleService;
        private IProjectService _projectService;

        public ProjectServiceTest()
        {
            _roleService = new RoleService();
            _projectService = new ProjectService(_roleService);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetUserProjectsTest()
        {
            var result = _projectService.GetUserProjects("NotExistingUserId");
            Assert.IsNull(result, "Result for non existing user should be null.");
        }

        [TestMethod]
        public void RetypeToProjectModelTest()
        {
            var projectFirst = new Project()
            {
                Name = "CSOB",
                Department = Department.Taxes,
                Client = "Johnny Cage",
                Manager = "Janek Ota",
                Employees = "John Doe, Don Ron",
                Introduction = "Few words",
                Content = "Much more words",
                Conclusion = "End of words",
                Budget = "145000",
                OpenDate = new DateTime(2014, 2, 12),
                CloseDate = new DateTime(2017, 11, 10)
            };
            var projects = new List<Project>();
            projects.Add(projectFirst);
            var role = new Role()
            {
                Name = "Name",
                Enum = RoleType.Client,
                Description = "Role employee"
            };
            var roles = new List<Role>();
            roles.Add(role);
            var result = _projectService.RetypeToProjectModel(projects, roles);
            Assert.AreNotEqual(projectFirst, result);
        }
    }
}
