using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class Destino
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Lugar { get; set; }
        [Required, MaxLength(50)]
        public string Descripcion { get; set; }
        [Required, MaxLength(255)]
        public string Atractivo { get; set; }
        [Required, MaxLength(255)]
        public string Historia { get; set; }
        public string Imagen { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<PaqueteDestino> PaqueteDestinos { get; set; }
        public ICollection<Hotel> Hoteles { get; set; }
    }
}
