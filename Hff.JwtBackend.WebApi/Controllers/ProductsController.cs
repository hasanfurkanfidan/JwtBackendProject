using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.Entities.Concrete;
using Hff.JwtBackend.Entities.Dtos.ProductDtos;
using Hff.JwtBackend.WebApi.CustomFilters;
using Microsoft.AspNetCore.Diagnostics;
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
        [ValidModel]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
            await _productService.AddAsync(new Product { Name = productAddDto.Name });
            return Created("", productAddDto);
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(product);
            return NoContent();
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult>GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpPut("id")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult>Update(int id,ProductUpdateDto model)
        {
            var product = await _productService.GetByIdAsync(id);
            product.Name = model.Name;
            await _productService.UpdateAsync(product);
            return NoContent();
        }
        [Route("/error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //Loglama
            return Problem(detail:"Sunucuda hata oluştu en kısa zamanda düzeltilecek.");
        }
    }
}
