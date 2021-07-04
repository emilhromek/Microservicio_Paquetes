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
    public interface IHotelService
    {
        public Response PostHotel(HotelDto hotel);
        public object GetHotelId(int id);
        public object GetHoteles(string idDestino);
    }

    public class HotelService: IHotelService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public HotelService (ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public Response PostHotel(HotelDto hotel)
        {
            Destino getDestino = _queries.EncontrarPor<Destino>(hotel.DestinoId);

            if (getDestino == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Destino con el id: " + hotel.DestinoId + " no existe."
                };
            }

            if (hotel.Marca.Length > 50)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "La marca del hotel supera los 50 caracteres."
                };
            }

            if (hotel.Sucursal.Length > 50)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "La sucursal del hotel supera los 50 caracteres."
                };
            }

            Hotel nuevoHotel = new Hotel()
            {
                Marca = hotel.Marca,
                Sucursal = hotel.Sucursal,
                Estrellas = hotel.Estrellas,
                Bloqueado = hotel.Bloqueado,
                DireccionId = hotel.DireccionId,
                DestinoId = hotel.DestinoId,
            };

            _commands.Agregar<Hotel>(nuevoHotel);

            return new Response()
            {
                Code = "OK",
                Message = "Hotel con el id: " + nuevoHotel.Id + ", marca: " + nuevoHotel.Marca + " y sucursal: " + nuevoHotel.Sucursal + " creado."
            };
        }

        // Falta agregar el detalle de las habitaciones y usar datos

        public object GetHotelId(int id)
        {
            var hotel = _queries.EncontrarPor<Hotel>(id);

            if (hotel == null)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "Hotel con el id: " + id + " no encontrado."
                };
            }

            var destino = _queries.EncontrarPor<Destino>(hotel.DestinoId);

            var listaHabitaciones = new List<HabitacionHotelOutDto>();

            foreach (HabitacionHotel x in _queries.Traer<HabitacionHotel>())
            {
                if (x.HotelId == id)
                {
                    var habitacion = new HabitacionHotelOutDto()
                    {
                        Id = x.Id,
                        Disponibles = x.Disponibles,
                        TipoHabitacionId = x.TipoHabitacionId,
                        HotelId = x.HotelId,
                    };

                    listaHabitaciones.Add(habitacion);
                }
            }

            var output = new HotelOutDto()
            {
                Id = hotel.Id,
                Marca = hotel.Marca,
                Sucursal = hotel.Sucursal,
                Estrellas = hotel.Estrellas,
                Bloqueado = hotel.Bloqueado,
                DireccionId = hotel.DireccionId,
                DestinoId = hotel.DestinoId,
                Destino = new DestinoOutDto
                {
                    Id = destino.Id,
                    Lugar = destino.Lugar,
                    Descripcion = destino.Descripcion,
                    Atractivo = destino.Atractivo,
                    Historia = destino.Historia,
                    Imagen = destino.Imagen,
                },

                Habitaciones = listaHabitaciones,
            };

            return output;
        }

        public object GetHoteles(string idDestino)
        {
            var hoteles = _queries.Traer<Hotel>();

            if (idDestino.Equals(""))
            {
                var hotelesOut = new List<HotelOutDto>();

                if (hoteles.Count == 0)
                {
                    return new Response()
                    {
                        Code = "NOT_FOUND",
                        Message = "No hay hoteles."
                    };
                }

                foreach (Hotel x in hoteles)
                {
                    var destino = _queries.EncontrarPor<Destino>(x.DestinoId);

                    var listaHabitaciones = new List<HabitacionHotelOutDto>();

                    foreach (HabitacionHotel y in _queries.Traer<HabitacionHotel>())
                    {
                        if (y.HotelId == x.Id)
                        {
                            var habitacion = new HabitacionHotelOutDto()
                            {
                                Id = y.Id,
                                Disponibles = y.Disponibles,
                                TipoHabitacionId = y.TipoHabitacionId,
                                HotelId = y.HotelId,
                            };

                            listaHabitaciones.Add(habitacion);
                        }
                    }

                    var output = new HotelOutDto()
                    {
                        Id = x.Id,
                        Marca = x.Marca,
                        Sucursal = x.Sucursal,
                        Estrellas = x.Estrellas,
                        Bloqueado = x.Bloqueado,
                        DireccionId = x.DireccionId,
                        DestinoId = x.DestinoId,
                        Destino = new DestinoOutDto
                        {
                            Id = destino.Id,
                            Lugar = destino.Lugar,
                            Descripcion = destino.Descripcion,
                            Atractivo = destino.Atractivo,
                            Historia = destino.Historia,
                            Imagen = destino.Imagen,
                        },

                        Habitaciones = listaHabitaciones,
                    };

                    hotelesOut.Add(output);
                }

                return hotelesOut;
            }

            if (_queries.EncontrarPor<Destino>(Int32.Parse(idDestino)) == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Destino con el id: " + idDestino + " no encontrado."
                };
            }           

            if (hoteles.Count == 0)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "No hay hoteles."
                };
            }            

            var hotelesDestino = new List<HotelOutDto>();

            foreach (Hotel x in hoteles)
            {
                if (Int32.Parse(idDestino) == x.DestinoId)
                {
                    var destino = _queries.EncontrarPor<Destino>(x.DestinoId);

                    var listaHabitaciones = new List<HabitacionHotelOutDto>();

                    foreach (HabitacionHotel y in _queries.Traer<HabitacionHotel>())
                    {
                        if (y.HotelId == x.Id)
                        {
                            var habitacion = new HabitacionHotelOutDto()
                            {
                                Id = y.Id,
                                Disponibles = y.Disponibles,
                                TipoHabitacionId = y.TipoHabitacionId,
                                HotelId = y.HotelId,
                            };

                            listaHabitaciones.Add(habitacion);
                        }
                    }

                    var output = new HotelOutDto()
                    {
                        Id = x.Id,
                        Marca = x.Marca,
                        Sucursal = x.Sucursal,
                        Estrellas = x.Estrellas,
                        Bloqueado = x.Bloqueado,
                        DireccionId = x.DireccionId,
                        DestinoId = x.DestinoId,
                        Destino = new DestinoOutDto
                        {
                            Id = destino.Id,
                            Lugar = destino.Lugar,
                            Descripcion = destino.Descripcion,
                            Atractivo = destino.Atractivo,
                            Historia = destino.Historia,
                            Imagen = destino.Imagen,
                        },

                        Habitaciones = listaHabitaciones,
                    };

                    hotelesDestino.Add(output);
                }
            }

            return hotelesDestino;
        }
    }
}
