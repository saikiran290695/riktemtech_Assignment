using RiktamTech.DTO;
using RiktamTech.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Web;
using System.Web.Http;

namespace RiktamTech.Controllers
{
    public class GroupsController : ApiController
    {
        [HttpPost]
        [Route("api/group/createGroup")]
        public IHttpActionResult createGroup(GroupDTO group) { 
            GroupServices services = new GroupServices();

            AuthServices authServices = new AuthServices();

            group.currentUserId = authServices.GetCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]);

            if (!services.CreateGroup(group))
                return BadRequest("Error");

            return Ok("Success");
        }

        [HttpPost]
        [Route("api/group/addMemebers")]
        public IHttpActionResult addMembers(GroupDTO group) {

            GroupServices services = new GroupServices();

            AuthServices authServices = new AuthServices();

            group.currentUserId = authServices.GetCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]);

            if (!services.AddUsersToGroup(group))
                return BadRequest("Error");

            return Ok();
        }       
    }
}
