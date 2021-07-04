using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class HotelPension
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Descripcion { get; set; }
        public ICollection<PaqueteHotel> PaqueteHoteles { get; set; }
    }
}
