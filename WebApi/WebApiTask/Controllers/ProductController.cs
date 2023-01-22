using Microsoft.AspNetCore.Mvc;
using WebApiTask.Models.DbModels;
using WebApiTask.Models.QueryModels;
using WebApiTask.Services;

namespace WebApiTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getBy")]
        public async Task<IActionResult> GetBy([FromQuery] ProductPaginationModel model)
        {
            var products = await _productService.GetByAsync(model.PageNumber, model.PageSize, model.CategoryId);

            return Ok(products);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetAsync(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            await _productService.CreateAsync(product);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            await _productService.UpdateAsync(product);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);

            return Ok();
        }
    }
}