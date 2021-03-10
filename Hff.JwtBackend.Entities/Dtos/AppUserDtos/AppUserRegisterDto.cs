using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Entities.Dtos.AppUserDtos
{
    public class AppUserRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
    }
}
