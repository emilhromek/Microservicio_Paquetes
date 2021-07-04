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
    public interface IPaqueteEstadoService
    {
        public object GetPaqueteEstadoId(int id);
        public object GetPaqueteEstados();
    }

    public class PaqueteEstadoService : IPaqueteEstadoService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public PaqueteEstadoService(ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }
        public object GetPaqueteEstadoId(int id)
        {
            var paqueteEstado = _queries.EncontrarPor<PaqueteEstado>(id);

            if (paqueteEstado == null)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "Estado de paquete con el id: " + id + " no encontrado."
                };
            }

            var output = new PaqueteEstadoOutDto()
            {
                Id = paqueteEstado.Id,
                Descripcion = paqueteEstado.Descripcion,
            };

            return output;
        }

        public object GetPaqueteEstados()
        {
            var paqueteEstados = _queries.Traer<PaqueteEstado>();

            if (paqueteEstados.Count == 0)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "No hay estados de paquete."
                };
            }

            var lista = new List<PaqueteEstadoOutDto>();

            foreach (PaqueteEstado x in _queries.Traer<PaqueteEstado>())
            {
                lista.Add(new PaqueteEstadoOutDto { Id = x.Id, Descripcion = x.Descripcion });
            }

            return lista;
        }
    }
}
