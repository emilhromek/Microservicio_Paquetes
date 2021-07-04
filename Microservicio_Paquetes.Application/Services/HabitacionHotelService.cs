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
    public interface IHabitacionHotelService
    {
        public Response PostHabitacionHotel(HabitacionHotelDto habitacionHotel);
    }

    public class HabitacionHotelService : IHabitacionHotelService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public HabitacionHotelService(ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public Response PostHabitacionHotel(HabitacionHotelDto habitacionHotel)
        {
            TipoHabitacion getTipoHabitacion = _queries.EncontrarPor<TipoHabitacion>(habitacionHotel.TipoHabitacionId);

            if (getTipoHabitacion == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Tipo de habitación con el id: " + habitacionHotel.TipoHabitacionId + " no existe."
                };
            }

            Hotel getHotel = _queries.EncontrarPor<Hotel>(habitacionHotel.HotelId);

            if (getHotel == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Hotel con el id: " + habitacionHotel.HotelId + " no existe."
                };
            }

            List<HabitacionHotel> getHabitacionHotel = _queries.Traer<HabitacionHotel>();

            foreach (HabitacionHotel x in getHabitacionHotel)
            {
                if (x.HotelId == habitacionHotel.HotelId && x.TipoHabitacionId == habitacionHotel.TipoHabitacionId)
                {
                    return new Response()
                    {
                        Code = "BAD_REQUEST",
                        Message = "Ya existe una tabla habitacionHotel para este hotel y este tipo de habitación." +
                        "Debe actualizar la cantidad de habitaciones en vez de crear una nueva.",
                    };
                }
            }

            HabitacionHotel nuevaHabitacionHotel = new HabitacionHotel()
            {
                TipoHabitacionId = habitacionHotel.TipoHabitacionId,
                Disponibles = habitacionHotel.Disponibles,
                HotelId = habitacionHotel.HotelId,
            };

            _commands.Agregar<HabitacionHotel>(nuevaHabitacionHotel);

            return new Response()
            {
                Code = "OK",
                Message = "HabitacionHotel con el id: " + nuevaHabitacionHotel.Id + ", para el hotel: " + nuevaHabitacionHotel.HotelId + "y tipo de habitación: " + nuevaHabitacionHotel.TipoHabitacionId + " creado."
            };
        }
    }
}
