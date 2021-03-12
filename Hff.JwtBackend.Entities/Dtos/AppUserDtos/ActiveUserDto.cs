using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Entities.Dtos.AppUserDtos
{
    public class ActiveUserDto
    {
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
