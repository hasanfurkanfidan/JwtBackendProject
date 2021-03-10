using FluentValidation;
using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.Business.Concrete;
using Hff.JwtBackend.Business.ValidationRules;
using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.DataAccess.Concrete.EntityFrameworkCore;
using Hff.JwtBackend.Entities.Dtos.AppUserDtos;
using Hff.JwtBackend.Entities.Dtos.ProductDtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.JwtBackend.Business.IOC
{
    public static class DependencyResolver
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IAppUserRepository, EfAppUserRepository>();
            services.AddScoped<IAppUserRoleRepository, EfAppUserRoleRepository>();
            services.AddScoped<IAppRoleRepository, EfAppRoleRepository>();


            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

        }
    }
}
