using Microsoft.AspNetCore.Mvc;
using WebApiTask.Models.DbModels;
using WebApiTask.Services;

namespace WebApiTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseService<Category> _categoryService;

        public CategoryController(IBaseService<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetAsync(id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            await _categoryService.CreateAsync(category);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            await _categoryService.UpdateAsync(category);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);

            return Ok();
        }
    }
}
