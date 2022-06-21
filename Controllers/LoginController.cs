using MamjiAPI.Models.BLL;
using MamjiAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MamjiAPI.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        loginBLL service = new loginBLL();
        /// <returns></returns>
        [HttpGet]
        [Route("login/admin/{passcode}")]
        public RspAdminLogin GetLoginAdmin(string PassCode)
        {
            return service.login(PassCode);

        }
    }
}
