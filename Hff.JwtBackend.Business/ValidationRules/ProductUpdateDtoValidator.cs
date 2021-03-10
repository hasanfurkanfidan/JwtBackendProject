using FluentValidation;
using Hff.JwtBackend.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.ValidationRules
{
    public class ProductUpdateDtoValidator:AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("Id değeri boş geçilemez.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
        }
    }
}
