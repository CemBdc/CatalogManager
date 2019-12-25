using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogManager.Dto
{
    public class GetProductDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
