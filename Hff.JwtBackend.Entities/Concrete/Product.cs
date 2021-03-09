using Hff.JwtBackend.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Entities.Concrete
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
