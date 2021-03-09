using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.Concrete
{
    public class AppUserRoleManager:GenericManager<AppUserRole>,IAppUserRoleService
    {
        public AppUserRoleManager(IGenericRepository<AppUserRole>genericRepository):base(genericRepository)
        {
                
        }
    }
}
