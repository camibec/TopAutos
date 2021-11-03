using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TopAutos.Models
{
    public class VotosUsuario
    {
        //Para que no puedan volver a votar el mismo auto, registro lo que ya votaron

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int Voto { get; set; }



    }
}
