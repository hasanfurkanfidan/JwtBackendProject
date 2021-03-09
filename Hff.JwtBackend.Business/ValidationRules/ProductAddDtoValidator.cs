using FluentValidation;
using Hff.JwtBackend.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.ValidationRules
{
    public class ProductAddDtoValidator:AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim alanı gerekli");
        }
    }
}
