using Hff.JwtBackend.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Entities.Concrete
{
    public class AppUser:ITable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
