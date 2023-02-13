using Microsoft.AspNetCore.Mvc;
using MvcTask.Models.DtoModels;
using MvcTask.Services;

namespace MvcTask.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBaseService<CategoryDto> _categoryService;

        public CategoryController(IBaseService<CategoryDto> categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();

            return View(categories);
        }
    }
}
