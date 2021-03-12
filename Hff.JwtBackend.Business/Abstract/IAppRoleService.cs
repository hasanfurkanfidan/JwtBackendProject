using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.JwtBackend.Business.Abstract
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> GetAppRoleWithNameAsync(string name);
    }
}
