﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Models
{
    public class LoginSuccessResponseModel
{
    public string Token { get; set; }
    public string Role { get; set; }
    public LoginUserResponseModel User { get; set; }
}

}
