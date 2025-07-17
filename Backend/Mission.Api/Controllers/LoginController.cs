using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Services.IServices;
using Mission.Services.Services;

namespace Mission.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("Login")]
        public ResponseResult Login(LoginUserRequestModel model)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result = _loginService.Login(model);

            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;

        }
        [HttpGet]
        [Route("Authorization")]
        [Authorize(Roles ="admin")]
        public string Registration()
        {
            return "Registration api";
        }
        
       
        [HttpGet]
        [Route("getUser")]
        [Authorize(Roles = "User")]
        public string getUser()
        {
            return "getUser api";
        }

    }

}
