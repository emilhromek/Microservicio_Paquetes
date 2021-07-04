using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquetes.Domain.DTO
{
    public class ExcursionDto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public bool Bloqueada { get; set; }
        public int DestinoId { get; set; }
    }
}
