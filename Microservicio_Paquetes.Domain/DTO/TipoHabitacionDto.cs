using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservicio_Paquetes.Domain.DTO
{
    public class TipoHabitacionDto
    {
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int Plazas { get; set; }
    }
}
