using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.UnitofWork;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUnitofWork _unitofWork;
        public CategoryManager(ICategoryDal categoryDal, IUnitofWork unitofWork)
        {
            _categoryDal = categoryDal;
            _unitofWork = unitofWork;
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResult> AddAsync(Category category)
        {
            await _categoryDal.AddAsync(category);
            await _unitofWork.CommitAsync();
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Category category)
        {
            _categoryDal.Delete(category);
            await _unitofWork.CommitAsync();
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Category>>>  GetAllAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetAllAsync());
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int categoryId)
        {
            return new SuccessDataResult<Category>(await _categoryDal.GetAsync(c => c.Id == categoryId));
        }

        public async Task<IResult> UpdateAsync(Category category)
        {
            _categoryDal.Update(category);
            await _unitofWork.CommitAsync();
            return new SuccessResult();
        }
    }
}
