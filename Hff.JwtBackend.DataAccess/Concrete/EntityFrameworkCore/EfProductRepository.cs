using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfProductRepository:EfGenericRepository<Product>,IProductRepository
    {
    }
}
