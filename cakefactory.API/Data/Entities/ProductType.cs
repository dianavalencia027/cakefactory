using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cakefactory.API.Data.Entities
{
    public class ProductType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de producto")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
