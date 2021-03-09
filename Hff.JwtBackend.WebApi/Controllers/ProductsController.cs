using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using Hff.JwtBackend.Entities.Dtos.ProductDtos;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(new Product { Name = productAddDto.Name });
                return Created("", productAddDto);
            }
            return BadRequest(productAddDto);
        }
    }
}
