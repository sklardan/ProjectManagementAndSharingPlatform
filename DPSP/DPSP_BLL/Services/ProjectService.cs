using DPSP_BLL.Models;
using DPSP_DAL;
using System.Collections.Generic;
using System.Linq;


namespace DPSP_BLL
{
    public class ProjectService : IProjectService
    {
        protected readonly IRoleService roleService;

        public ProjectService(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public IEnumerable<Project> GetUserProjects(string aspUserId)
        {
            using (var db = new DboContext())
            {
                var dbUser = db.Users.FirstOrDefault(x => x.AspNetUsersId == aspUserId);
                if (dbUser == null) return null;

                var projects = db.Projects.Where(x => x.Users.Any(y => y.Id == dbUser.Id)).ToList();
                return projects;
            }
        }

        public IEnumerable<ProjectModel> RetypeToProjectModel(IEnumerable<Project> userProjects, IEnumerable<Role> role)
        {
            var roleType = role.FirstOrDefault().Enum;
            IEnumerable<ProjectModel> projects;
            projects = userProjects.Select(x => new ProjectModel()
            {
                ProjectId = x.Id,
                Name = x.Name,
                Department = x.Department,
                Client = x.Client,
                Manager = x.Manager,
                Employees = x.Employees,
                Introduction = x.Introduction,
                Content = x.Content,
                Conclusion = x.Conclusion,
                OpenDate = x.OpenDate,
                CloseDate = x.CloseDate
            }).ToList();
            switch (roleType)
            {      
                case RoleType.Employee:
                    foreach (var item in projects)
                    {
                        item.Budget = userProjects.FirstOrDefault(x => x.Id == item.ProjectId).Budget;
                    }
                    break;
                default:
                    break;
            }
            return projects;
        }

        public IEnumerable<ProjectModel> GetProjectModels(ApplicationUserManager userManager, string userName)
        {
            var aspUser = userManager.Users.FirstOrDefault(x => x.UserName == userName);
            var userProjects = GetUserProjects(aspUser.Id);
            var projectViewModels = RetypeToProjectModel(userProjects, roleService.GetRole(aspUser.Id));
            return projectViewModels;
        }
    }
}
