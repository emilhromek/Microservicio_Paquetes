using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.Entities
{
    public class Reserva
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PrecioTotal { get; set; }
        [Required]
        public int Pasajeros { get; set; }
        [Required]
        public bool Pagado { get; set; }
        [Required]
        public int PasajeroId { get; set; }
        [Required]
        public int FormaPagoId { get; set; }
        public FormaPago FormaPago { get; set; }
        [Required]
        public int IdPaquete { get; set; }
        public Paquete Paquete { get; set; }
        public ICollection<ReservaExcursion> ReservaExcursiones { get; set; }
        public ICollection<ReservaHabitacion> ReservaHabitaciones { get; set; }

    }
}
