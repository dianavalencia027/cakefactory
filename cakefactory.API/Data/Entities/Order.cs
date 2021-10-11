using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cakefactory.API.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Precio del producto")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Cost { get; set; }

        [Display(Name = "Cantidad")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Quantity { get; set; }

        [Display(Name = "Valor a pagar")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price => Quantity * Cost;

        [Display(Name = "Descripción del pedido")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string OrderDescription { get; set; }

        //[Display(Name = "Foto")]
        //public Guid OrderImage { get; set; }

        //TODO: insertar foto OrderImage

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime DateLocal => OrderDate.ToLocalTime();

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

    }
}
