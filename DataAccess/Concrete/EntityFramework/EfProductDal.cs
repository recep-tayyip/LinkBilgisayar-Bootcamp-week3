using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, WebAPIDbContext>, IProductDal
    {
        public EfProductDal(WebAPIDbContext context) : base(context)
        {

        }
        public async Task<List<ProductDetailDto>> GetAllProductDetailsAsync()
        {
            var result = from p in _context.Products
                         join c in _context.Categories on p.CategoryId equals c.Id
                         select new ProductDetailDto
                         {
                             ProductId = p.Id,
                             ProductName = p.ProductName,
                             CategoryName = c.CategoryName,
                             UnitsInStock = p.UnitsInStock
                         };
            return await result.ToListAsync();
        }
    }
}
