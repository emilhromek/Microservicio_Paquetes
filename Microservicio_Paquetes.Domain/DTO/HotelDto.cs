using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquetes.Domain.DTO
{
    public class HotelDto
    {
        public string Marca { get; set; }
        public string Sucursal { get; set; }
        public int Estrellas { get; set; }
        public bool Bloqueado { get; set; }
        public int DireccionId { get; set; }
        public int DestinoId { get; set; }
    }
}
