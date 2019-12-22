using CatalogManager.Business.Contracts;
using CatalogManager.Data.UnitOfWork;
using CatalogManager.Dto;
using System;
using System.Collections.Generic;
using System.Text;
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
                if (product.Price <= default(int) || product.Price > 999)
                    throw new ArgumentException("Invalid Price");

                //if Code is alphanumeric
                //if product.Picture is URL

                var result = _uow.Product.Add(new Data.Models.Product
                {
                    Code = product.Code,
                    Name = product.Name,
                    Picture = product.Picture,
                    Price = product.Price,
                    UpdatedAt = product.UpdatedAt
                });

                await _uow.CompleteAsync();

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<IEnumerable<AddProductDto>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(AddProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AddProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
