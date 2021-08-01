using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Shared
{
    public class Price
    {
        public int Id { get; set; }
        [Range(0, 999999999)]
        public double PrecioVenta  { get; set; }
        [Required(ErrorMessage ="* El campo fecha de inicio es obligatorio")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage ="* El campo fecha fin es obligatorio")]
        public DateTime FechaFin { get; set; }
    }
}
