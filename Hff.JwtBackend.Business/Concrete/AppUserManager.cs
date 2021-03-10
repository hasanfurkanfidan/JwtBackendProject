using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.JwtBackend.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IAppRoleRepository _appRoleRepository;
        private readonly IAppUserRoleRepository _appUserRoleRepository;
        public AppUserManager(IGenericRepository<AppUser> genericRepository, IAppRoleRepository appRoleRepository, IAppUserRoleRepository appUserRoleRepository, IAppUserRepository appUserRepository) : base(genericRepository)
        {
            _appUserRepository = appUserRepository;
            _appUserRoleRepository = appUserRoleRepository;
            _appRoleRepository = appRoleRepository;
        }

        public Task<bool> CheckUserWithUserNameAndPasswod(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckUserWithUserNameAndPassword(string username, string password)
        {
            var user = await _appUserRepository.GetAsync(p => p.Username == username && p.Password == password);
            if (user != null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<AppRole>> GetUserRolesWithUserName(string userName)
        {
            var user = await _appUserRepository.GetAsync(p => p.Username == userName);

            var userRoles = await _appUserRoleRepository.GetListAsync(p => p.AppUserId == user.Id);
            var roles = new List<AppRole>();
            foreach (var item in userRoles)
            {
                var role = await _appRoleRepository.GetAsync(p => p.Id == item.AppRoleId);
                roles.Add(role);
            }
            return roles;
          
        }

        public async Task<AppUser> GetUserWithUserName(string userName)
        {
            var user = await _appUserRepository.GetAsync(p => p.Username == userName);
            return user;
        }
    }
}
