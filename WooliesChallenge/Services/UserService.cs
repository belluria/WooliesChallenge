using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WooliesChallenge.Contracts;
using WooliesChallenge.Models;

namespace WooliesChallenge.Services
{
    public class UserService : IUserService
    {
        private UserConfig _user;
        public UserService(IOptions<UserConfig> userConfig)
        {
            _user = userConfig.Value;
        }
        public UserConfig GetUserDetails()
        {
            return _user;
        }
    }
}
