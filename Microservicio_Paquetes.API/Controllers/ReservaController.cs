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
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaservice;

        public ReservaController(IReservaService reservaservice)
        {
            _reservaservice = reservaservice;
        }

        [HttpPost]
        public async Task<ActionResult> PostReserva(ReservaDto reserva)
        {
            Response respuesta = _reservaservice.PostReserva(reserva);

            if (respuesta.Code.Equals("BAD_REQUEST"))
            {
                return BadRequest(respuesta);
            }

            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReserva(int id)
        {
            object respuesta = _reservaservice.GetReservaId(id);

            if (respuesta is Response)
            {
                if (((Response)respuesta).Code == "NOT_FOUND")
                {
                    return NotFound(respuesta);
                }
            }

            return Ok(respuesta);
        }

        [Route("{id}/registrarPago")]
        [HttpPatch]
        public async Task<IActionResult> PatchPago(int id)
        {
            object respuesta = _reservaservice.PatchPago(id);

            return Ok(respuesta);
        }

        
        [HttpGet]
        public async Task<ActionResult> GetReservas([FromQuery] string idPaquete = "")
        {
            object respuesta = _reservaservice.GetReservas(idPaquete);

            if (respuesta is Response)
            {
                if (((Response)respuesta).Code == "NOT_FOUND")
                {
                    return NotFound(respuesta);
                }
            }

            return Ok(respuesta);
        }

    }
}
