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
    public interface IComentarioService
    {
        public Response PostComentario(ComentarioDto comentario);
        public object GetComentarioId(int id);
        public object GetComentarios(string idDestino, string idPasajero);
    }

    public class ComentarioService : IComentarioService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public ComentarioService(ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public Response PostComentario(ComentarioDto comentario)
        {
            Destino getDestino = _queries.EncontrarPor<Destino>(comentario.DestinoId);

            if (getDestino == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Destino con el id: " + comentario.DestinoId + " no existe."
                };
            }

            if(comentario.Mensaje.Length > 255)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "El comentario supera los 255 caracteres."
                };
            }

            Comentario nuevoComentario = new Comentario()
            {
                Fecha = DateTime.Now,
                Mensaje = comentario.Mensaje,
                DestinoId = comentario.DestinoId,
                PasajeroId = comentario.PasajeroId,
            };            

            _commands.Agregar<Comentario>(nuevoComentario);

            return new Response()
            {
                Code = "CREATED",
                Message = "Comentario con el id: " + nuevoComentario.Id + " creado."
            };
        }

        public object GetComentarioId(int id)
        {
            var comentario = _queries.EncontrarPor<Comentario>(id);

            if (comentario == null)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "Comentario con el id: " + id + " no encontrado."
                };
            }

            var output = new ComentarioOutDto()
            {
                Id = comentario.Id,
                Fecha = comentario.Fecha.ToString(),
                DestinoId = comentario.DestinoId,
                PasajeroId = comentario.PasajeroId,
                Mensaje = comentario.Mensaje
            };

            return output;
        }

        public object GetComentarios(string idDestino, string idPasajero)
        {
            var comentarios = _queries.Traer<Comentario>();

            var output = new List<ComentarioOutDto>();

            if (idDestino.Equals("") && idPasajero.Equals(""))
            {
                if (comentarios.Count == 0)
                {
                    return new Response()
                    {
                        Code = "NOT_FOUND",
                        Message = "No hay comentarios."
                    };
                }

                foreach (Comentario x in comentarios)
                {
                    var comentarioOut = new ComentarioOutDto()
                    {
                        Id = x.Id,
                        Fecha = x.Fecha.ToString(),
                        Mensaje = x.Mensaje,
                        DestinoId = x.DestinoId,
                        PasajeroId = x.PasajeroId,
                    };

                    output.Add(comentarioOut);                    
                }                

                return output;
            }

            else if (!idDestino.Equals("") && _queries.EncontrarPor<Destino>(Int32.Parse(idDestino)) == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Destino con el id: " + idDestino + " no encontrado."
                };
            }

            // Falta validar pasajero

            if (idPasajero.Equals(""))
            {
                foreach (Comentario x in comentarios)
                {
                    if (x.DestinoId == Int32.Parse(idDestino))
                    {
                        var comentarioOut = new ComentarioOutDto()
                        {
                            Id = x.Id,
                            Fecha = x.Fecha.ToString(),
                            Mensaje = x.Mensaje,
                            DestinoId = x.DestinoId,
                            PasajeroId = x.PasajeroId,
                        };

                        output.Add(comentarioOut);
                    }
                }

                if (output.Count == 0)
                {
                    return new Response()
                    {
                        Code = "NOT_FOUND",
                        Message = "No hay comentarios."
                    };
                }

                return output;
            }


            if (idDestino.Equals(""))
            {
                foreach (Comentario x in comentarios)
                {
                    if (x.PasajeroId == Int32.Parse(idPasajero))
                    {
                        var comentarioOut = new ComentarioOutDto()
                        {
                            Id = x.Id,
                            Fecha = x.Fecha.ToString(),
                            Mensaje = x.Mensaje,
                            DestinoId = x.DestinoId,
                            PasajeroId = x.PasajeroId,
                        };

                        output.Add(comentarioOut);
                    }
                }

                if (output.Count == 0)
                {
                    return new Response()
                    {
                        Code = "NOT_FOUND",
                        Message = "No hay comentarios."
                    };
                }

                return output;
            }            

            foreach (Comentario x in comentarios)
            {
                if (x.DestinoId == Int32.Parse(idDestino) && x.PasajeroId == Int32.Parse(idPasajero))
                {
                    var comentarioOut = new ComentarioOutDto()
                    {
                        Id = x.Id,
                        Fecha = x.Fecha.ToString(),
                        Mensaje = x.Mensaje,
                        DestinoId = x.DestinoId,
                        PasajeroId = x.PasajeroId,
                    };

                    output.Add(comentarioOut);
                }
            }

            return output;
            
        }
    }
}
