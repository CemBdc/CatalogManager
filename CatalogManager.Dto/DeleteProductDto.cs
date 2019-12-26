using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CatalogManager.Dto
{
    public class DeleteProductDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric codes accepted")]
        public string Code { get; set; }
    }
}
