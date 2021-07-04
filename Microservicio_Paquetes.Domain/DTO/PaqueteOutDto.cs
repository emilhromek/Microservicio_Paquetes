using System;
using System.Collections.Generic;
using System.Text;


namespace Microservicio_Paquetes.Domain.DTO
{
    public class PaqueteOutDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaSalida { get; set; }
        public string FechaVuelta { get; set; }
        public int TotalNoches { get; set; }
        public int Precio { get; set; }
        public int Descuento { get; set; }
        public int PaqueteEstadoId { get; set; }
        public int Prioridad { get; set; }

        //Lista de listas con 4 elementos: (destino, hotel, cantidad de noches, tipodepension)
        public List<object> ListaDestinosDetalles { get; set; }
    }
}
