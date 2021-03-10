using FluentValidation;
using Hff.JwtBackend.Entities.Dtos.AppUserDtos;
using Hff.JwtBackend.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.ValidationRules
{
    public class AppUserLoginDtoValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password değeri boş geçilemez.");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("UserName alanı boş geçilemez.");
        }
    }
}
