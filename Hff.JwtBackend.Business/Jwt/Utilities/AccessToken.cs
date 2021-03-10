using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Jwt.Utilities
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
