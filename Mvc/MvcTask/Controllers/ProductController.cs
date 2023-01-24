using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcTask.Models.DtoModels;
using MvcTask.Services;
using MvcTask.Settings;
using MvcTask.ViewModels;

namespace MvcTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBaseService<SupplierDto> _supplierService;
        private readonly IBaseService<CategoryDto> _categoryService;
        private readonly IMapper _mapper;
        private readonly ProductViewOptions _options;

        public ProductController(
            IProductService productService,
            IBaseService<SupplierDto> supplierService,
            IBaseService<CategoryDto> categoryService,
            IMapper mapper,
            IOptions<ProductViewOptions> options)
        {
            _productService = productService;
            _supplierService = supplierService;
            _categoryService = categoryService;
            _mapper = mapper;
            _options = options.Value;
        }
 
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetByAsync(_options.MaxProductsPageCount);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProductCreateUpdateViewModel
            {
                Categories = await _categoryService.GetAllAsync(),
                Suppliers= await _supplierService.GetAllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateUpdateViewModel model)
        {
            if (ValidateModel(model))
            {
				var product = _mapper.Map<ProductCreateUpdateViewModel, ProductDto>(model);
				await _productService.CreateAsync(product);

				return RedirectToAction(nameof(Index));
			}

			model.Categories = await _categoryService.GetAllAsync();
			model.Suppliers = await _supplierService.GetAllAsync();

			return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetAsync(id);
            var productModel = _mapper.Map<ProductDto, ProductCreateUpdateViewModel>(product);

            productModel.Categories = await _categoryService.GetAllAsync();
            productModel.Suppliers = await _supplierService.GetAllAsync();

			return View(productModel);
		}

        [HttpPost]
        public async Task<IActionResult> Update(ProductCreateUpdateViewModel model)
        {
            if (ValidateModel(model))
            {
				var product = _mapper.Map<ProductCreateUpdateViewModel, ProductDto>(model);
				await _productService.UpdateAsync(product);

				return RedirectToAction(nameof(Index));
			}

			model.Categories = await _categoryService.GetAllAsync();
			model.Suppliers = await _supplierService.GetAllAsync();

			return View(model);
		}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);

			return RedirectToAction(nameof(Index));
		}

        private bool ValidateModel(ProductCreateUpdateViewModel model)
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(model.ProductName))
            {
                ModelState.AddModelError(nameof(model.ProductName), "ProductName is required!");
                isValid = false;
			}
            if (string.IsNullOrWhiteSpace(model.QuantityPerUnit))
            {
				ModelState.AddModelError(nameof(model.QuantityPerUnit), "QuantityPerUnit is required!");
				isValid = false;
			}
			if (model.ReorderLevel < 0)
            {
				ModelState.AddModelError(nameof(model.ReorderLevel), "ReorderLevel can not be less than 0");
				isValid = false;
			}
			if (model.UnitsOnOrder < 0)
            {
				ModelState.AddModelError(nameof(model.UnitsOnOrder), "UnitsOnOrder can not be less than 0");
				isValid = false;
			}

            return isValid;
		}
	}
}