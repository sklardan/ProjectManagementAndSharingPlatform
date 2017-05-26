using DPSP_BLL.Models;
using DPSP_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSP_BLL
{
    public interface IProjectService
    {
        /// <summary>
        /// GetUserProjects will get user his projects from database. 
        /// </summary>
        /// <param name="asUserId">String aspUserId.</param>
        /// <returns>Returns user's projects from database.</returns>
        IEnumerable<Project> GetUserProjects(string aspUserId);

        /// <summary>
        /// RetypeToProjectModel will retype user's projects to ProjectViewModels depending on role - not everything will be returned.
        /// </summary>
        /// <param name="userProjects">All user's projects from database.</param>
        /// <param name="roleType">RoleType of user. Client or Employee.</param>
        /// <returns>Returns IEnumerable<ProjectModel> depending on user's role.</returns>
        IEnumerable<ProjectModel> RetypeToProjectModel(IEnumerable<Project> userProjects, IEnumerable<Role> roleType);

        /// <summary>
        /// GetProjectModels call GetUserProject and RetypeToProjectModel and returns ProjectViewModels.
        /// </summary>
        /// <param name="userManager">User manager for microsoft identity.</param>
        /// <param name="userName">String user name.</param>
        /// <returns>Returns all ProjectViewModels depended on role - not everything will be returned.</returns>
        IEnumerable<ProjectModel> GetProjectModels(ApplicationUserManager userManager, string userName);
    }
}
