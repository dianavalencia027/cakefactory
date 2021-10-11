using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cakefactory.API.Data.Entities
{
    public class Detail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Decoraciones aplicadas")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Decoration { get; set; }

        [Display(Name = "Adiciones para celebrar")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Additions { get; set; }

        [Display(Name = "Comentarios")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}
