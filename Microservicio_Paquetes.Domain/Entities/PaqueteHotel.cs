using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class PaqueteHotel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Noches { get; set; }
        [Required]
        public int PaqueteId { get; set; }
        public Paquete Paquete { get; set; }
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [Required]
        public int HotelPensionId { get; set; }
        public HotelPension HotelPension { get; set; }

    }
}
