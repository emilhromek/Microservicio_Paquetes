using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class Paquete
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Nombre { get; set; }
        [Required, MaxLength(255)]
        public string Descripcion { get; set; }
        //[Required, DataType(DataType.Date), Column(TypeName = "Date")]
        public string FechaSalida { get; set; }
        //[Required, DataType(DataType.Date), Column(TypeName = "Date")]
        public string FechaVuelta { get; set; }
        [Required]
        public int TotalNoches { get; set; }
        [Required]
        public int Precio { get; set; }
        [Required]
        public int Descuento { get; set; }
        [Required]
        public int PaqueteEstadoId { get; set; }
        public PaqueteEstado PaqueteEstado { get; set; }
        [Required]
        public int EmpleadoId { get; set; }
        public int Prioridad { get; set; }
        public ICollection<PaqueteViaje> PaqueteViajes { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<PaqueteHotel> PaqueteHoteles { get; set; }
        public ICollection<PaqueteDestino> PaqueteDestinos { get; set; }

    }
}
