using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Shared
{
    public class Product
    {
        public Product()
        {
            Nombre = "";
            Descripcion = "";
            RutaImagen = "/images/NotFound.png";
            Precio = new Price();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "* El campo nombre es obligatorio")]
        public string Nombre { get; set; }
        public string RutaImagen { get; set; }
        [Required(ErrorMessage = "* El campo fecha de Alta es obligatorio")]
        public DateTime FechaAlta { get; set; }
        [Required(ErrorMessage = "* El campo fecha de baja es obligatorio")]
        public DateTime FechaBaja { get; set; }
        public Price Precio { get; set; }
        public string Descripcion { get; set; }

    }
}
