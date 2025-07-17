using Mission.Entities.Entities;
using Mission.Entities.Models;

namespace Mission.Services.IServices
{
    public interface ILoginService
    {
        // Login
        ResponseResult Login(LoginUserRequestModel model);

        // Create

    }
}
