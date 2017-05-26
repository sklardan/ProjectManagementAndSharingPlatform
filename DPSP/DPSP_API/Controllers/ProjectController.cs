﻿using DPSP_BLL;
using DPSP_DAL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Data.OData;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace DPSP_API.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.
    */
    [Authorize]
    //[ODataRouting]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class ProjectController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private IProjectService projectService;

        private ApplicationUserManager _userManager;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: odata/Project
        /// <summary>
        /// GetProject will give projects to the user by his user name.
        /// Depands on type of role.
        /// </summary>
        /// <param name="userName">Wants user name.</param>
        /// <returns>Email whith instruction to finist the registration proces.</returns>
        [EnableQuery]
        public IHttpActionResult GetProject(ODataQueryOptions<Project> queryOptions,string userName)
        {
            return Ok(projectService.GetProjectModels(UserManager,userName));
        }

        // GET: odata/Project(5)
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult GetProject([FromODataUri] System.Guid key, ODataQueryOptions<Project> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Project>(project);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Project(5)
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Put([FromODataUri] System.Guid key, Delta<Project> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(project);

            // TODO: Save the patched entity.

            // return Updated(project);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Project
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Post(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(project);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Project(5)
        [AcceptVerbs("PATCH", "MERGE")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Patch([FromODataUri] System.Guid key, Delta<Project> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(project);

            // TODO: Save the patched entity.

            // return Updated(project);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Project(5)
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Delete([FromODataUri] System.Guid key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
