using RiktamTech.DTO;
using RiktamTech.IServices;
using RiktamTech.Services;
using System.Web;
using System.Web.Http;
using Unity;

namespace RiktamTech.Controllers
{
    public class GroupsController : ApiController
    {
        IGroupServices _groupServices = DependencyInjection.Unity.container.Resolve<IGroupServices>();
        IAuthServices _authServices = DependencyInjection.Unity.container.Resolve<IAuthServices>();

        [HttpPost]
        [Route("api/group/createGroup")]
        public IHttpActionResult createGroup(GroupDTO group) {             

            group.currentUserId = _authServices.GetCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]);

            if (!_groupServices.CreateGroup(group))
                return BadRequest("Error");

            return Ok("Success");
        }

        [HttpPost]
        [Route("api/group/addMemebers")]
        public IHttpActionResult addMembers(GroupDTO group) {
            
            group.currentUserId = _authServices.GetCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]);

            if (!_groupServices.AddUsersToGroup(group))
                return BadRequest("Error");

            return Ok();
        }       
    }
}
