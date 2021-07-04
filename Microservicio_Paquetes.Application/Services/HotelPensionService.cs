using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquetes.Domain.Entities;
using Microservicio_Paquetes.Domain.DTO;
using Microservicio_Paquetes.Domain.Queries;
using Microservicio_Paquetes.Domain.Commands;
using Microservicio_Paquetes.Domain.Responses;

namespace Microservicio_Paquetes.Application.Services
{
    public interface IHotelPensionService
    {
        public object GetHotelPensionId(int id);
        public object GetHotelPensiones();
    }

    public class HotelPensionService : IHotelPensionService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public HotelPensionService(ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public object GetHotelPensionId(int id)
        {
            var hotelPension = _queries.EncontrarPor<HotelPension>(id);

            if (hotelPension == null)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "Pensión de hotel con el id: " + id + " no encontrada."
                };
            }

            var output = new HotelPensionOutDto()
            {
                Id = hotelPension.Id,
                Descripcion = hotelPension.Descripcion,
            };

            return output;
        }

        public object GetHotelPensiones()
        {
            var hotelPensiones = _queries.Traer<HotelPension>();

            if (hotelPensiones.Count == 0)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "No hay pensiones de hotel."
                };
            }

            var listaOutput = new List<HotelPensionOutDto>();

            foreach (HotelPension x in _queries.Traer<HotelPension>())
            {
                listaOutput.Add(new HotelPensionOutDto { Id = x.Id, Descripcion = x.Descripcion });
            }

            return listaOutput;
        }
    }
}
