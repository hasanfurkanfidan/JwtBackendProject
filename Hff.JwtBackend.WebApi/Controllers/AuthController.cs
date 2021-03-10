using Business.Jwt.Abstract;
using Business.Jwt.Concrete;
using Business.Jwt.Utilities;
using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using Hff.JwtBackend.Entities.Dtos.AppUserDtos;
using Hff.JwtBackend.WebApi.CustomFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.JwtBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly ITokenHelper _tokenHelper;
        public AuthController(IAppUserService appUserService, ITokenHelper tokenHelper)
        {
            _appUserService = appUserService;
            _tokenHelper = tokenHelper;
        }
        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.GetUserWithUserName(appUserLoginDto.UserName);
            if (user == null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
            else
            {
                if (await _appUserService.CheckUserWithUserNameAndPassword(appUserLoginDto.UserName, appUserLoginDto.Password))
                {
                    var roles = await _appUserService.GetUserRolesWithUserName(user.Username);
                    var token = _tokenHelper.CreateToken(user, roles);
                    return Created("", token);
                }
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserRegisterDto appUserRegisterDto)
        {
            var user = await _appUserService.GetUserWithUserName(appUserRegisterDto.UserName);
            if (user == null)
            {
                await _appUserService.AddAsync(new AppUser { Fullname = appUserRegisterDto.Fullname,
                    Password = appUserRegisterDto.Password, Username = appUserRegisterDto.UserName });


                return Created("", "Kayıt başarı ile eklendi");
            }
            return BadRequest("Kullanıcı adı alınmış");
        }
    }
}
