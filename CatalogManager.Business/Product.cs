using CatalogManager.Business.Contracts;
using CatalogManager.Data.UnitOfWork;
using CatalogManager.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogManager.Business
{
    public class Product: IProduct
    {
        private readonly IUnitOfWork _uow;

        public Product(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Add(AddProductDto product)
        {
            try
            {
                var entity = await _uow.Product.Get(p => p.Code == product.Code);

                if (entity != null)
                    return false;

                await _uow.Product.Add(new Data.Models.Product
                {
                    Code = product.Code,
                    Name = product.Name,
                    Picture = product.Picture,
                    Price = product.Price,
                    UpdatedAt = product.UpdatedAt
                });

                return await _uow.CompleteAsync();
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<GetProductDto> GetProductByCode(string code)
        {
            var product = await _uow.Product.Get(p => p.Code == code);

            if (product == null)
                return null;

            return new GetProductDto
            {
                Code = product.Code,
                Name = product.Name,
                Picture = product.Picture,
                Price = product.Price,
                UpdatedAt = product.UpdatedAt
            };
        }

        public async Task<List<GetProductDto>> GetAll()
        {
            var list = await _uow.Product.All();

            List<GetProductDto> result = new List<GetProductDto>();

            if (list != null)
            {
                foreach (var item in list)
                {
                    result.Add(new GetProductDto
                    {
                        Code = item.Code,
                        Name = item.Name,
                        Picture = item.Picture,
                        Price = item.Price,
                        UpdatedAt = item.UpdatedAt
                    });
                }

            }

            return result;
        }

        public async Task<bool> Update(AddProductDto product)
        {
            try
            {
                var entity = await _uow.Product.Get(p => p.Code == product.Code);

                if (entity == null)
                    return false;
                
                entity.Name = product.Name;
                entity.Picture = product.Picture;
                entity.Price = product.Price;
                entity.UpdatedAt = DateTime.Now;

                await _uow.Product.Update(entity);

                return await _uow.CompleteAsync();

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(DeleteProductDto product)
        {
            try
            {
                var entity = await _uow.Product.Get(p => p.Code == product.Code);

                if (entity == null)
                    return false;

                await _uow.Product.Delete(entity);

                return await _uow.CompleteAsync();

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
