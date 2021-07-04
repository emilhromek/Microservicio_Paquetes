using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquetes.Domain.DTO
{
    public class HabitacionHotelDto
    {
        public int Disponibles { get; set; }
        public int TipoHabitacionId { get; set; }
        public int HotelId { get; set; }
    }
}
