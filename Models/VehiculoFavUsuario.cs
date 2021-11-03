using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TopAutos.Models
{
    public class VehiculoFavUsuario
        // Los vehiculos que el usuario agrego a favorito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}
