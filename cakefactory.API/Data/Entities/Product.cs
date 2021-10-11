using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace cakefactory.API.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de producto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public ProductType ProductType { get; set; }

        [Display(Name = "Línea de producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Line { get; set; }

        [Display(Name = "Nombre del producto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ProductName { get; set; }

        [Display(Name = "Número de porciones")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(8, 80, ErrorMessage = "Número de porciones inválido")]
        public int Portion { get; set; }

        [Display(Name = "Precio del producto")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Cost { get; set; }

        [Display(Name = "Sabor")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Flavor { get; set; }

        [Display(Name = "Descripción del producto")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        public ICollection<PhotoCatalog> PhotoCatalogs { get; set; }

        [Display(Name = "# Fotos")]
        public int PhotoCatalogsCount => PhotoCatalogs == null ? 0 : PhotoCatalogs.Count;

        //TODO: Fix the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => PhotoCatalogs == null || PhotoCatalogs.Count == 0
            ? $"https://localhost:44306/images/noimage.png"
            : PhotoCatalogs.FirstOrDefault().ImageFullPath;
    }
}

