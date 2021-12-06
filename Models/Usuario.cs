using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TopAutos.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El campo de email no puede estar vacio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El email ingresado no es valido")]
        public String Email { get; set; }
        public String Clave { get; set; }
        public int Rol { get; set; }
    }
}
