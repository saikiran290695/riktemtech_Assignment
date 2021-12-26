using RiktamTech.DTO;
using RiktamTech.IServices;
using System.Web;
using System.Web.Http;
using Unity;

namespace RiktamTech.Controllers
{
    public class MessagesController : ApiController
    {
        IMessageServices _messageServices = DependencyInjection.Unity.container.Resolve<IMessageServices>();
        IAuthServices _authServices = DependencyInjection.Unity.container.Resolve<IAuthServices>();

        [HttpPost]
        [Route("api/messages/sendtouser")]
        public IHttpActionResult sendMessage(Message mgs)
        {

            if (!_messageServices.SendMessages(mgs, _authServices.GetCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0])))
                return BadRequest("Error in sending messgae");

            return Ok("Success");
        }

        [HttpGet]
        [Route("api/messages/getmessages")]
        public MessagesDTO getMessages() {

            return _messageServices.RetriveMessages(_authServices.GetCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]));
        }

        [HttpPost]
        [Route("api/messages/senttogroup")]
        public IHttpActionResult sendMessage(GroupDTO group)
        {            
            group.currentUserId = _authServices.GetCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]);

            if (!_messageServices.SendMessage(group))
                return BadRequest("Error");

            return Ok("Success");
        }


    }
}
