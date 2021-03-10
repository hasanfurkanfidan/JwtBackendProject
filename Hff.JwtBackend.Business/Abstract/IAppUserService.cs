using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.JwtBackend.Business.Abstract
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        Task<AppUser> GetUserWithUserName(string userName);
        Task<bool> CheckUserWithUserNameAndPasswod(string username, string password);
        Task<List<AppRole>> GetUserRolesWithUserName(string userName);
    }
}
