using Microsoft.EntityFrameworkCore;
using Mission.Entities.Context;
using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositiories;
using System.Collections.Generic;
using System.Linq;

namespace Mission.Repositories.Repositories
{
    public class LoginRepositories : ILoginRepository
    {
        private readonly MissionDbContext _missionDbContext;
        public LoginRepositories(MissionDbContext missionDbContext)
        {
            _missionDbContext = missionDbContext;
        }
        public LoginUserResponseModel Login(LoginUserRequestModel model)
        {
            var existingUser = _missionDbContext.Users.Where(x => x.EmailAddress.ToLower() == model.EmailAddress.ToLower() && !x.IsDeleted).FirstOrDefault();
            if (existingUser == null)
            {
                return new LoginUserResponseModel() { Message = "Email not found address" };
            }
            if (existingUser.Password != model.Password)
            {
                return new LoginUserResponseModel() { Message = "Incorrect Password" };
            }
            return new LoginUserResponseModel()
            {
                Id = existingUser.Id,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                EmailAddress = existingUser.EmailAddress,
                PhoneNumber = existingUser.PhoneNumber,
                UserImage = existingUser.UserImage,
                UserType = existingUser.UserType,
                Message = "Login Successful"
            };
        }
        public ResponseResult CreateUser(User user)
        {
            _missionDbContext.Users.Add(user);
            _missionDbContext.SaveChanges();

            return new ResponseResult
            {
                Data = user,
                Message = "User registered successfully",
                Result = ResponseStatus.Success
            };
        }

      

       
    }
}
