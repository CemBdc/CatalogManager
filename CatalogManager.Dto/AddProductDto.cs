using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogManager.Dto
{
    public class AddProductDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$")]
        public string Picture { get; set; }

        [Required]
        [Range(1, 999)]
        public decimal Price { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
