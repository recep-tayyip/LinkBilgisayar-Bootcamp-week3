using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<List<Product>>> GetAllAsync();
        Task<IDataResult<List<Product>>> GetAllByCategoryIdAsync(int categoryId);
        Task<IDataResult<List<ProductDetailDto>>> GetAllProductDetailsAsync();
        Task<IDataResult<Product>> GetByIdAsync(int id);
        Task<IResult> AddAsync(Product product);
        Task<IResult> UpdateAsync(Product product);
        Task<IResult> DeleteAsync(Product product);
    }
}