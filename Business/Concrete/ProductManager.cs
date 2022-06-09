using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.UnitofWork;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IUnitofWork _unitofWork;
        public ProductManager(IProductDal productDal, IUnitofWork unitofWork)
        {
            _productDal = productDal;
            _unitofWork = unitofWork;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public async Task<IResult> AddAsync(Product product)
        {
            //validation codes
            await _productDal.AddAsync(product);
            await _unitofWork.CommitAsync();
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Product product)
        {
            _productDal.Delete(product);
            await _unitofWork.CommitAsync();
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync());
        }

        public async Task<IDataResult<List<Product>>> GetAllByCategoryIdAsync(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync(p => p.CategoryId == categoryId));
        }

        public async Task<IDataResult<List<ProductDetailDto>>> GetAllProductDetailsAsync()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(await _productDal.GetAllProductDetailsAsync());
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Product>(await _productDal.GetAsync(p => p.Id == id));
        }

        public async Task<IResult> UpdateAsync(Product product)
        {
            _productDal.Update(product);
            await _unitofWork.CommitAsync();
            return new SuccessResult();
        }
    }
}