using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.Concrete
{
   public class AppUserManager:GenericManager<AppUser>,IAppUserService
    {
        public AppUserManager(IGenericRepository<AppUser>genericRepository):base(genericRepository)
        {
                
        }
    }
}
