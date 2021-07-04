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
    public interface IDestinoService
    {
        public Response PostDestino(DestinoDto destino);
        public object GetDestinoId(int id);
        public object GetDestinos();

    }

    public class DestinoService : IDestinoService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public DestinoService(ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public Response PostDestino(DestinoDto destino)
        {
            if (destino.Lugar.Length > 50)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "El nombre de lugar supera los 50 caracteres."
                };
            }

            if (destino.Descripcion.Length > 255)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "La descripcion supera los 255 caracteres."
                };
            }

            if (destino.Atractivo.Length > 255)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "El atractivo supera los 255 caracteres."
                };
            }

            if (destino.Historia.Length > 255)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "La historia supera los 255 caracteres."
                };
            }

            Destino nuevoDestino = new Destino()
            {
                Lugar = destino.Lugar,
                Descripcion = destino.Descripcion,
                Atractivo = destino.Atractivo,
                Historia = destino.Historia,
                Imagen = destino.Imagen,
            };

            _commands.Agregar<Destino>(nuevoDestino);

            return new Response()
            {
                Code = "CREATED",
                Message = "Destino con el id: " + nuevoDestino.Id + " y nombre de lugar: '" + nuevoDestino.Lugar + "' creado."
            };
        }
        public object GetDestinoId(int id)
        {
            var destino = _queries.EncontrarPor<Destino>(id);

            if (destino == null)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "Destino con el id: " + id + " no encontrado."
                };
            }

            var output = new DestinoOutDto()
            {
                Id = destino.Id,
                Lugar = destino.Lugar,
                Descripcion = destino.Descripcion,
                Atractivo = destino.Atractivo,
                Historia = destino.Historia,
                Imagen = destino.Imagen,
            };

            return output;
        }

        public object GetDestinos()
        {
            var destinos = _queries.Traer<Destino>();

            if (destinos.Count == 0)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "No hay destinos."
                };
            }

            var listaOutput = new List<DestinoOutDto>();

            foreach (Destino x in destinos)
            {
                var output = new DestinoOutDto()
                {
                    Id = x.Id,
                    Lugar = x.Lugar,
                    Descripcion = x.Descripcion,
                    Atractivo = x.Atractivo,
                    Historia = x.Historia,
                    Imagen = x.Imagen,
                };

                listaOutput.Add(output);
            }

            return listaOutput;
        }
    }
}
