using Business.Jwt.Abstract;
using Business.Jwt.Concrete;
using Business.Jwt.Utilities;
using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.Business.StringInfos;
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
        private readonly IAppRoleService _appRoleService;
        private readonly IAppUserRoleService _appUserRoleService;
        public AuthController(IAppUserService appUserService,IAppUserRoleService appUserRoleService, ITokenHelper tokenHelper,IAppRoleService appRoleService)
        {
            _appUserService = appUserService;
            _appRoleService = appRoleService;
            _appUserRoleService = appUserRoleService;
            _tokenHelper = tokenHelper;
        }
        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.GetUserWithUserName(appUserLoginDto.UserName);
            if (user == null)
            {
                return BadRequest(Messages.FalseUserNameOrPassword);
            }
            else
            {
                if (await _appUserService.CheckUserWithUserNameAndPassword(appUserLoginDto.UserName, appUserLoginDto.Password))
                {
                    var roles = await _appUserService.GetUserRolesWithUserName(user.Username);
                    var token = _tokenHelper.CreateToken(user, roles);
                    return Created("", token);
                }
                return BadRequest(Messages.FalseUserNameOrPassword);
            }
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserRegisterDto appUserRegisterDto)
        {
            var user = await _appUserService.GetUserWithUserName(appUserRegisterDto.UserName);
            if (user == null)
            {
                var newUser = new AppUser
                {
                    Fullname = appUserRegisterDto.Fullname,
                    Password = appUserRegisterDto.Password,
                    Username = appUserRegisterDto.UserName
                };
                await _appUserService.AddAsync(newUser);
                var ourUser = await _appUserService.GetUserWithUserName(appUserRegisterDto.UserName);
                var role = await _appRoleService.GetAppRoleWithNameAsync(RoleInfos.Member);
                await _appUserRoleService.AddAsync(new AppUserRole
                {
                    AppRoleId = role.Id,
                    AppUserId = ourUser.Id
                });
                return Created("", Messages.SignUpSuccessful);
            }
            return BadRequest(Messages.UserAlreadyExist);
        }
    }
}
