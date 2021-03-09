using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfAppUserRepository:EfGenericRepository<AppUser>,IAppUserRepository
    {
    }
}
