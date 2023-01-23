using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcTask.Models.DtoModels;
using MvcTask.Services;
using MvcTask.Settings;

namespace MvcTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ProductViewOptions _options;

        public ProductController(IProductService productService, IOptions<ProductViewOptions> options)
        {
            _productService = productService;
            _options = options.Value;
        }
 
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetByAsync(_options.MaxProductsPageCount);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var product = await _productService.GetAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto product)
        {
            await _productService.CreateAsync(product);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ProductDto product)
        {
            await _productService.UpdateAsync(product);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);

            return Ok();
        }
    }
}