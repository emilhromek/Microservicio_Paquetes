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
    public interface IReservaService
    {
        public Response PostReserva(ReservaDto reserva);
        public object GetReservaId(int id);

        public Response PatchPago(int id);

        public object GetReservas(string idPaquete);

    }

    public class ReservaService : IReservaService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public ReservaService(ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public Response PostReserva(ReservaDto reserva)
        {
            FormaPago getFormaPago = _queries.EncontrarPor<FormaPago>(reserva.FormaPagoId);

            if (getFormaPago == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Forma de pago con el id: " + reserva.FormaPagoId + " no existe."
                };
            }

            Paquete getPaquete = _queries.EncontrarPor<Paquete>(reserva.PaqueteId);

            if (getPaquete == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Paquete con el id: " + reserva.PaqueteId + " no existe."
                };
            }

            int precioTotalReserva = 0;

            Reserva nuevaReserva = new Reserva()
            {
                Pasajeros = reserva.Pasajeros,
                Pagado = false,
                PasajeroId = reserva.PasajeroId,
                FormaPagoId = reserva.FormaPagoId,
                IdPaquete = reserva.PaqueteId,
            };

            var listaReservaExcursion = new List<ReservaExcursion>();

            // Sumar el precio total pasajeros * paquete

            precioTotalReserva = precioTotalReserva + nuevaReserva.Pasajeros * _queries.EncontrarPor<Paquete>(reserva.PaqueteId).Precio;

            foreach (int x in reserva.ListaExcursiones)
            {
                // Sumar el precio total pasajeros * cada una de las excursiones

                precioTotalReserva = precioTotalReserva + nuevaReserva.Pasajeros * _queries.EncontrarPor<Excursion>(x).Precio;

                ReservaExcursion reservaExcursion = new ReservaExcursion()
                {
                    ReservaId = nuevaReserva.Id,
                    ExcursionId = x,
                };

                listaReservaExcursion.Add(reservaExcursion);
            }

            nuevaReserva.PrecioTotal = precioTotalReserva;

            nuevaReserva.ReservaExcursiones = listaReservaExcursion;

            _commands.Agregar<Reserva>(nuevaReserva);

            return new Response()
            {
                Code = "OK",
                Message = "Reserva con el id: " + nuevaReserva.Id + " creada."
            };
        }

        public object GetReservaId(int id)
        {
            var reserva = _queries.EncontrarPor<Reserva>(id);

            if (reserva == null)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "Reserva con el id: " + id + " no encontrada."
                };
            }

            List<object> listaExcursiones = new List<object>();

            foreach(ReservaExcursion x in _queries.Traer<ReservaExcursion>())
            {
                if (x.ReservaId == id)
                {
                    var excursion = _queries.EncontrarPor<Excursion>(x.ExcursionId);

                    listaExcursiones.Add(new {Id = x.ExcursionId, Título = excursion.Titulo, Destino = excursion.DestinoId});
                }
            }

            var output = new ReservaOutDto()
            {
                Id = reserva.Id,
                Pasajeros = reserva.Pasajeros,
                Pagado = reserva.Pagado,
                PasajeroId = reserva.PasajeroId,
                FormaPagoId = reserva.FormaPagoId,
                PaqueteId = reserva.IdPaquete,
                Excursiones = listaExcursiones,
            };

            return output;
        }

        public Response PatchPago(int id)
        {
            var reserva = _queries.EncontrarPor<Reserva>(id);
            if(reserva == null)
            {
                return new Response
                {
                    Code = "NOT_FOUND",
                    Message = $"La reserva id:{id} no se encontró"
                };
            }
            reserva.Pagado = true;
            
            return new Response
            {
                Code = "Ok",
                Message = $"Se registró el pago de la reserva id:{id}"
            };
        }

        public object GetReservas(string idPaquete)
        {
            var paquetes = _queries.Traer<Paquete>();

            var reservasARenderizar = new List<Reserva>();

            var listaOutput = new List<object>();

            if (idPaquete.Equals(""))
            {
                foreach (Reserva x in _queries.Traer<Reserva>())
                {
                    reservasARenderizar.Add(x);
                }
            }

            if (!idPaquete.Equals(""))
            {
                foreach (Reserva x in _queries.Traer<Reserva>())
                {
                    if (x.IdPaquete == Int32.Parse(idPaquete))
                    {
                        if (!reservasARenderizar.Contains(x))
                        {
                            reservasARenderizar.Add(x);
                        }
                    }
                }
            }

            foreach (Reserva x in reservasARenderizar)
            {
                listaOutput.Add(GetReservaId(x.Id));
            }

            if (listaOutput.Count == 0)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "No hay reservas."
                };
            }

            return listaOutput;

        }

    }
}
