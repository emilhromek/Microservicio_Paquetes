using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.DTO
{
    public class PaqueteEstadoOutDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
