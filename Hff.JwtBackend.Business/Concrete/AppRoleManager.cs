using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.JwtBackend.Business.Concrete
{
   public class AppRoleManager:GenericManager<AppRole>,IAppRoleService
    {
        private readonly IAppRoleRepository _appRoleRepository;
        public AppRoleManager(IGenericRepository<AppRole>genericRepository,
            IAppRoleRepository appRoleRepository):base(genericRepository)
        {
            _appRoleRepository = appRoleRepository;
        }

        public async Task<AppRole> GetAppRoleWithNameAsync(string name)
        {
           return await _appRoleRepository.GetAsync(p => p.Name == name);
        }
    }
}
