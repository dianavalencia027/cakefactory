using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cakefactory.API.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la categoría")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string CategoryName { get; set; }

        [Display(Name = "Descripción del producto")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ICollection<Detail> Details { get; set; }
    }
}
