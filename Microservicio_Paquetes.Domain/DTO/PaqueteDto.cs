using System;
using System.Collections.Generic;
using System.Text;


namespace Microservicio_Paquetes.Domain.DTO
{
    public class PaqueteDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaSalida { get; set; }
        public string FechaVuelta { get; set; }
        //public int totalnoches { get; set; }
        //no se necesita, se calcular automaticamente
        public int Precio { get; set; }
        public int Descuento { get; set; }
        public int PaqueteEstadoId { get; set; }
        public int Prioridad { get; set; }

        //Lista de listas con 4 elementos: (destino, hotel, cantidad de noches, tipodepension)
        public List<List<int>> ListaDestinoHotelNochesPension { get; set; }
    }
}
