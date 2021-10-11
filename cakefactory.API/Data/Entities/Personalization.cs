using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cakefactory.API.Data.Entities
{
    public class Personalization
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del producto personalizado")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
