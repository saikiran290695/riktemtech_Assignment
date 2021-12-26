using RiktamTech.DTO;
using RiktamTech.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RiktamTech.Controllers
{
    public class MessagesController : ApiController
    {
        [HttpPost]
        [Route("api/messages/sendtouser")]
        public IHttpActionResult sendMessage(Message mgs)
        {
            MessageServices services = new MessageServices();
            AuthServices authServices = new AuthServices();

            if (!services.sendMessages(mgs, authServices.getCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0])))
                return BadRequest("Error in sending messgae");

            return Ok("Success");
        }

        [HttpGet]
        [Route("api/messages/getmessages")]
        public MessagesDTO getMessages() {

            MessageServices services = new MessageServices();
            
            AuthServices authServices = new AuthServices();

            return services.retriveMessages(authServices.getCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]));
        }

        [HttpPost]
        [Route("api/messages/senttogroup")]
        public IHttpActionResult sendMessage(groupDTO group)
        {
            MessageServices services = new MessageServices();

            AuthServices authServices = new AuthServices();

            group.currentUserId = authServices.getCurrentUserId(HttpContext.Current.Request.Headers.GetValues("token")[0]);

            if (!services.sendMessage(group))
                return BadRequest("Error");

            return Ok("Success");
        }


    }
}
