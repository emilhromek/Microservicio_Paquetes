using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class Comentario
    {
        [Required]
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime), Column(TypeName = "DateTime")]
        public DateTime Fecha { get; set; }
        [Required, MaxLength(255)] // Ver esto
        public string Mensaje { get; set; }
        [Required]
        public int DestinoId { get; set; }
        public Destino Destino { get; set; }
        [Required]
        public int PasajeroId { get; set; }
    }
}
