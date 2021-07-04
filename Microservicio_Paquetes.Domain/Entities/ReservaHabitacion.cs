using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class ReservaHabitacion
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [Required]
        public int TipoHabitacionId { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
    }
}
