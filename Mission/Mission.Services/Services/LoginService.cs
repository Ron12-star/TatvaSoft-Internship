using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositiories;
using Mission.Services.Helper;
using Mission.Services.IServices;
namespace Mission.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly JwtService jwtService;
        public LoginService(ILoginRepository loginRepository, JwtService jwtService )
        {
            _loginRepository = loginRepository;
            this.jwtService = jwtService;
        }

        public ResponseResult Login(LoginUserRequestModel model) { 
        var UserObj=this._loginRepository.Login(model);
            ResponseResult result = new ResponseResult();
            if (UserObj.Message == "Login Successful")
            {
                
                result.Message= UserObj.Message;
                result.Result=ResponseStatus.Success;
                result.Data = jwtService.GetToken(UserObj.FirstName,UserObj.EmailAddress,UserObj.UserType);
            }
            else
            {
               
                result.Message= UserObj.Message;
                result.Result=ResponseStatus.Success;
            }
            return result;



        }

      
    }
}
