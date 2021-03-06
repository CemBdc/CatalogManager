﻿using CatalogManager.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManager.Business.Contracts
{
    public interface IProduct
    {
        Task<bool> Add(AddProductDto entity);
        Task<bool> Update(AddProductDto entity);
        Task<bool> Delete(DeleteProductDto entity);
        Task<List<GetProductDto>> GetAll();
        Task<GetProductDto> GetProductByCode(string code);
    }
}
