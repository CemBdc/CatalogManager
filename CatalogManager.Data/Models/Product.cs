using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CatalogManager.Data.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public Product(string code, string name, string picture, decimal price, DateTime updatedAt)
        {
            if (
                string.IsNullOrEmpty(code) ||
                string.IsNullOrEmpty(name) ||
                price <= 0 || price > 999)
            {
                throw new Exception("Fields are not valid to create a new product.");
            }

            Code = code;
            Name = name;
            Picture = picture;
            Price = price;
            UpdatedAt = updatedAt;
        }

        public Product()
        {

        }

        public void SetFields(string code, string name, string picture, decimal price, DateTime updatedAt)
        {
            if (
                string.IsNullOrEmpty(code) ||
                string.IsNullOrEmpty(name) ||
                price <= 0 || price > 999)
            {
                throw new Exception("Fields are not valid to update.");
            }

            Code = code;
            Name = name;
            Picture = picture;
            Price = price;
            UpdatedAt = updatedAt;
        }

    }
}
