using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICategoryService
   {
       Task<IDataResult<List<Category>>> GetAllAsync();
       Task<IDataResult<Category>> GetByIdAsync(int categoryId); 
       Task<IResult> AddAsync(Category category);
       Task<IResult> UpdateAsync(Category category);
       Task<IResult> DeleteAsync(Category category);

    }
}
