using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository Repo;
        
        public ProductsController(IProductRepository Repo)
        {
            this.Repo = Repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {       
            var products = await Repo.GetProductsAsync();

            return Ok(products);
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {   
            return await Repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await Repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await Repo.GetProductTypesAsync());
        }
    }
}