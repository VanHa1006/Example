﻿using Azure;
using MilkShop.Data;
using MilkShop.Data.Models;
using MilkShopBusiness.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkShopBusiness.ProductBrandBusiness
{
    public interface IProductBrandBusiness
    {
        Task<IBusinessResult> GetPagingList(int page, int size);
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> FindId(int id);
        Task<IBusinessResult> UpdateAsync(ProductBrand productBrand);
        Task<IBusinessResult> Save(ProductBrand productBrand);
        Task<IBusinessResult> DeleteAsync(int id);
        Task<IBusinessResult> Search(string searchTerm, int page, int size);

    }
    public class ProductBrandBusiness : IProductBrandBusiness
    {
        //private readonly ProductBrandDAO _DAO;
        private readonly UnitOfWork _unitOfWork;

        public ProductBrandBusiness()
        {
            //_DAO = new ProductBrandDAO();
            _unitOfWork ??= new UnitOfWork();
        }
       
        public Task<IBusinessResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> GetPagingList(int page, int size)
        {
            try
            {
                var productBrands = await _unitOfWork.ProductBrandRepository.GetPagingListAsync(
                    selector: x => x,
                    page: page,
                    size: size
                    );
                if (productBrands != null)
                {
                    return new BusinessResult(1, "Get all product brands successfully", productBrands);
                }
                else
                {
                    return new BusinessResult(-1, "Get all product brands fail");
                }
            }catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            

            try
            {
                var productBrand = await _unitOfWork.ProductBrandRepository.SingleOrDefaultAsync(
                    selector: x => x,
                    predicate: x => x.ProductBrandId == id
                    );
                if (productBrand != null)
                {
                    return new BusinessResult(1, "Get product brand successfully", productBrand);
                }
                else
                {
                    return new BusinessResult(-1, "Get product brand fail");
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }
        public async Task<IBusinessResult> FindId(int id)
        {
            

            try
            {
                var productBrand = await _unitOfWork.ProductBrandRepository.GetByIdAsync(id);
                if (productBrand != null)
                {
                    return new BusinessResult(1, "Get product brand successfully", productBrand);
                }
                else
                {
                    return new BusinessResult(-1, "Get product brand fail");
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(ProductBrand productBrand)
        {
            

            try
            {
                var newProductBrand = await _unitOfWork.ProductBrandRepository.CreateAsync(productBrand);
                if (newProductBrand > 1)
                {
                    return new BusinessResult(1, "Create successfully");
                }
                else
                {
                    return new BusinessResult(1, "Create fail");
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }

        public async Task<IBusinessResult> Search(string searchTerm, int page, int size)
        {
            try
            {
                var productBrands = await _unitOfWork.ProductBrandRepository.GetPagingListAsync(
                    selector: x => x,
                    predicate: x => x.ProductBrandName.Contains(searchTerm),
                    page: page,
                    size: size
                    );

                if (productBrands != null)
                {
                    return new BusinessResult(1, "Create successfully", productBrands);
                }
                else
                {
                    return new BusinessResult(1, "Create fail");
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }

        public async Task<IBusinessResult> UpdateAsync(ProductBrand productBrand)
        {
            try
            {
                var productBrandForUpdate = await _unitOfWork.ProductBrandRepository.UpdateAsync(productBrand);

                if (productBrandForUpdate > 1)
                {
                    return new BusinessResult(1, "Create successfully");
                }
                else
                {
                    return new BusinessResult(1, "Create fail");
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var productBrands = await _unitOfWork.ProductBrandRepository.GetAllAsync();
                if (productBrands != null)
                {
                    return new BusinessResult(1, "Get all product brands successfully", productBrands);
                }
                else
                {
                    return new BusinessResult(-1, "Get all product brands fail");
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }
    }
}
