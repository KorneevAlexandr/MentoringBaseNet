﻿using MvcTask.Models.DtoModels;

namespace MvcTask.Services
{
    public interface IProductService : IBaseService<ProductDto>
    {
        Task<IEnumerable<ProductDto>> GetByAsync(int pageNumber, int pageSize, int? categoryId);
    }
}
