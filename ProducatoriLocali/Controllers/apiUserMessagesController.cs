using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProducatoriLocali.Models;
using ProducatoriLocali.Repositories;

namespace ProducatoriLocali.Controllers
{
    public class apiUserMessagesController : ApiController
    {
        private IUserMessagesRepository _userMessageRepo = new UserMessagesRepo();

        [HttpPost]
        [Route("api/apiusermessages/insertmessage")]
        public HttpResponseMessage InsertUserMessagesInDb(SendUserMessagesDTO sum)
        {
            var response = _userMessageRepo.InsertUserMessagesInDb(sum);
            if(response == ApiMessagesResponse.INSERT_SUCCESS)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
