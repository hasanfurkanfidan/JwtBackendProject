using FluentValidation;
using Hff.JwtBackend.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.ValidationRules
{
   public class AppUserRegisterDtoValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterDtoValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(p => p.Fullname).NotEmpty().WithMessage("İsim boş geçilmemez");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");
        }
    }
}
