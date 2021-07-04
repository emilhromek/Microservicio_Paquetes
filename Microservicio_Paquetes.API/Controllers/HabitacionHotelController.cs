using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Paquetes.Domain.Entities;
using Microservicio_Paquetes.Domain.Commands;
using Microservicio_Paquetes.Domain.DTO;
using Microservicio_Paquetes.Application.Services;
using Microservicio_Paquetes.Domain.Responses;

namespace Microservicio_Paquetes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionHotelController : ControllerBase
    {
        private readonly IHabitacionHotelService _habitacionhotelservice;

        public HabitacionHotelController(IHabitacionHotelService habitacionhotelservice)
        {
            _habitacionhotelservice = habitacionhotelservice;
        }

        [HttpPost]
        public async Task<ActionResult> PostHabitacionHotel(HabitacionHotelDto habitacionhotel)
        {
            Response respuesta = _habitacionhotelservice.PostHabitacionHotel(habitacionhotel);

            if (respuesta.Code.Equals("BAD_REQUEST"))
            {
                return BadRequest(respuesta);
            }

            return Ok(respuesta);
        }


    }
}
