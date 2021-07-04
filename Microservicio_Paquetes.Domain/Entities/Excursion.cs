using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class Excursion
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Titulo { get; set; }
        [Required, MaxLength(255)]
        public string Descripcion { get; set; }
        [Required]
        public int Precio { get; set; }
        [Required]
        public bool Bloqueada { get; set; }
        [Required]
        public int DestinoId { get; set; }
        public Destino Destino { get; set; }
        public ICollection<ReservaExcursion> ReservaExcursiones { get; set; }

    }
}
