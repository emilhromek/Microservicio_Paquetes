using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class Hotel
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Marca { get; set; }
        [Required, MaxLength(50)]
        public string Sucursal { get; set; }
        [Required]
        public int Estrellas { get; set; }
        [Required]
        public bool Bloqueado { get; set; }
        [Required]
        public int DireccionId { get; set; }
        [Required]
        public int DestinoId { get; set; }
        public Destino Destino { get; set; }
        public ICollection<HabitacionHotel> HabitacionHoteles { get; set; }
    }
}
