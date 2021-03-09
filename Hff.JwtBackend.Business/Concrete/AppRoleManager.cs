using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.Concrete
{
   public class AppRoleManager:GenericManager<AppRole>,IAppRoleService
    {
        public AppRoleManager(IGenericRepository<AppRole>genericRepository):base(genericRepository)
        {

        }
    }
}
