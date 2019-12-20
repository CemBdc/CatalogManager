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

        [Key, Column(Order = 1)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
        
    }
}
