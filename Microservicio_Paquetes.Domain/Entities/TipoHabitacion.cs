using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class TipoHabitacion
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Tipo { get; set; }
        [Required, MaxLength(255)]
        public string Descripcion { get; set; }
        [Required]
        public int Plazas { get; set; }
        public ICollection<HabitacionHotel> HabitacionesHotel { get; set; }
    }
}
