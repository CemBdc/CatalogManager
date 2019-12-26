using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture.DataAnnotations;
using CatalogManager.Data.Models;

namespace CatalogManager.UnitTest
{
    public class ProductRepositoryTest
    {
        [Theory, AutoMoqData]
        public void Create_Product_Should_Throw_Exception_When_Code_Is_Empty(string code, string name, string picture, decimal price, DateTime updatedAt)
        {
            Assert.Throws<Exception>(() => new Product(string.Empty, name, picture, price, updatedAt));
        }
    }
}
