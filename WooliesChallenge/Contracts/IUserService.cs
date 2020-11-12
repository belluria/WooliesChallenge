using System;
using System.Collections.Generic;
using System.Text;
using WooliesChallenge.Models;

namespace WooliesChallenge.Contracts
{
    public interface IUserService
    {
        UserConfig GetUserDetails();   
    }
}
