using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TopAutos.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Modelo { get; set; }
        public String Marca { get; set; }
        public String Imagen { get; set; }
        public int Ano { get; set; }
        public int CantPuertas { get; set; }
        public double Precio { get; set; }
        public Boolean VieneAutomatico { get; set; }
        public TipoVehiculo Tipo { get; set; }

        public int Voto { get; set; } = 0;
        // de 1 al 5 o algo asi, califican en vez de poner solo voto 
    }
}
