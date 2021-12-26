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
        public IHttpActionResult createGroup(groupDTO group) { 
            groupServices services = new groupServices();

            AuthServices authServices = new AuthServices();

            group.currentUserId = authServices.getCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]);

            if (!services.createGroup(group))
                return BadRequest("Error");

            return Ok("Success");
        }

        [HttpPost]
        [Route("api/group/addMemebers")]
        public IHttpActionResult addMembers(groupDTO group) {

            groupServices services = new groupServices();

            AuthServices authServices = new AuthServices();

            group.currentUserId = authServices.getCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]);

            if (!services.addUsersToGroup(group))
                return BadRequest("Error");

            return Ok();
        }
        
    }
}
