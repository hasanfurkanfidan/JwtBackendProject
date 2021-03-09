using Hff.JwtBackend.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Entities.Concrete
{
    public class AppUserRole:ITable
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int AppRoleId { get; set; }
        public AppUser AppUser { get; set; }
        public AppRole AppRole { get; set; }
    }
}
