using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class HabitacionHotel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TipoHabitacionId { get; set; }
        [Required]
        public int Disponibles { get; set; }
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
