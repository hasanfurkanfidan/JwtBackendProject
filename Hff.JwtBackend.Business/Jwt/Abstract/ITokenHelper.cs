using Business.Jwt.Utilities;
using Hff.JwtBackend.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Jwt.Abstract
{
    //Kullanıcıya token tanımlanacak bu token değerini refresh yapılcak
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUser user, List<AppRole> operationClaims);
    }
}
