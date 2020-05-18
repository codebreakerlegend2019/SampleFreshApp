using System;
using System.Collections.Generic;
using System.Text;

namespace SampleFreshApp.Models.AuthRelated
{
    public class LoginResult
    {
        public string Token { get; set; }
        public string LogginedUser { get; set; }
        public string Role { get; set; }
        public string SystemVersion { get; set; }
    }
}
