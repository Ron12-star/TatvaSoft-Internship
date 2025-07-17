using Mission.Entities.Entities;
using Mission.Entities.Models;
using System.Collections.Generic;

namespace Mission.Repositories.IRepositiories
{
    public interface ILoginRepository
    {
        LoginUserResponseModel Login(LoginUserRequestModel model);
        ResponseResult CreateUser(User user);

    }
}
