using System;
using System.ComponentModel.DataAnnotations;

namespace cakefactory.API.Data.Entities
{
    public class PhotoCatalog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public Product Product { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44306/images/noimage.png"
            : $"https://cakefactory1.blob.core.windows.net/products/{ImageId}";
    }
}
