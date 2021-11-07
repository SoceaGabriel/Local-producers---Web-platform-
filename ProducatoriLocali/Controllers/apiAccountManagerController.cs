using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProducatoriLocali.Models;
using ProducatoriLocali.Repositories;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ProducatoriLocali.Controllers
{
    public class apiAccountManagerController : ApiController
    {
        public IAccountManagerRepository _accountManagerRepo = new AccountManagerRepo();
        public string schema = "http://";
        public string host = "localhost";
        public string port = "64103";

        /*public apiAccountManagerController(IAccountManagerRepository accountManagerRepo)
        {
            _accountManagerRepo = accountManagerRepo;
        }*/

        [Route("api/apiaccountmanager/login")]
        [HttpGet]
        public HttpResponseMessage Login(string Email, string Parola)
        {
            ApiAccountResponse response = _accountManagerRepo.Login(Email, Parola);
            if (response == ApiAccountResponse.LOGIN_ERROR)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else if (response == ApiAccountResponse.LOGIN_EXCEPTION)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [Route("api/apiaccountmanager/register")]
        [HttpPost]
        public HttpResponseMessage Register(User user)
        {
            ApiAccountResponse response = _accountManagerRepo.Register(user);
            if (response == ApiAccountResponse.REGISTER_ERROR)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else if (response == ApiAccountResponse.REGISTER_EXCEPTION)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [Route("api/apiaccountmanager/modifyaccountinfo")]
        [HttpPut]
        public HttpResponseMessage AccountInfo(User user)
        {
            ApiAccountResponse response = _accountManagerRepo.ModifyAccountInfo(user);
            if (response == ApiAccountResponse.MODIFYACCOUNTINFO_ERROR)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else if (response == ApiAccountResponse.MODIFYACCOUNTINFO_EXCEPTION)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
