using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Shared
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "* El campo nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "* El campo apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "* El campo email es obligatorio")]
        [EmailAddress(ErrorMessage = "* El formato de Email no es valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "* El campo password es obligatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "* El campo fecha de alta es obligatorio")]
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public List<Product> Productos { get; set; }
    }
}
