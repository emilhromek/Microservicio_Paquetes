using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquetes.Domain.Entities;
using Microservicio_Paquetes.Domain.DTO;
using Microservicio_Paquetes.Domain.Commands;
using Microservicio_Paquetes.Domain.Queries;
using Microservicio_Paquetes.Domain.Responses;

namespace Microservicio_Paquetes.Application.Services
{
    public interface ITipoHabitacionService
    {
        public object GetTipoHabitacionId(int id);
        public object GetTiposHabitacion();
    }

    public class TipoHabitacionService : ITipoHabitacionService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public TipoHabitacionService(ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public object GetTipoHabitacionId(int id)
        {
            var tipoHabitacion = _queries.EncontrarPor<TipoHabitacion>(id);

            if (tipoHabitacion == null)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "Tipo de habitacion con el id: " + id + " no encontrada."
                };
            }

            var output = new TipoHabitacionOutDto()
            {
                Id = tipoHabitacion.Id,
                Tipo = tipoHabitacion.Tipo,
                Descripcion = tipoHabitacion.Descripcion,
                Plazas = tipoHabitacion.Plazas,
            };

            return output;
        }

        public object GetTiposHabitacion()
        {
            var tiposHabitacion= _queries.Traer<TipoHabitacion>();

            if (tiposHabitacion.Count == 0)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "No hay tipos de habitacion."
                };
            }

            var listaOutput = new List<TipoHabitacionOutDto>();

            foreach (TipoHabitacion x in _queries.Traer<TipoHabitacion>())
            {
                listaOutput.Add(new TipoHabitacionOutDto { Id = x.Id, Tipo = x.Tipo,
                          Descripcion = x.Descripcion, Plazas = x.Plazas });

            }

            return listaOutput;
        }
    }
}
