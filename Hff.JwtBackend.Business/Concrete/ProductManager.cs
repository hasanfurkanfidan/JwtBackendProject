using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.Concrete
{
    public class ProductManager:GenericManager<Product>,IProductService
    {
      
        public ProductManager(IGenericRepository<Product> genericRepository) :base(genericRepository)
        {

        }
    }
}
