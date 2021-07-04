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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _comentarioservice;

        public ComentarioController(IComentarioService comentarioservice)
        {
            _comentarioservice = comentarioservice;
        }

        [HttpPost]
        public async Task<ActionResult> PostComentario(ComentarioDto comentario)
        {
            Response respuesta = _comentarioservice.PostComentario(comentario);

            if (respuesta.Code.Equals("BAD_REQUEST"))
            {
                return BadRequest(respuesta);
            }

            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            object respuesta = _comentarioservice.GetComentarioId(id);

            if (respuesta is Response)
            {
                if (((Response)respuesta).Code == "NOT_FOUND")
                {
                    return NotFound(respuesta);
                }
            }

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<ActionResult> GetComentarios([FromQuery] string idPasajero = "", [FromQuery] string idDestino = "")
        {
            object respuesta = _comentarioservice.GetComentarios(idDestino, idPasajero);

            if (respuesta is Response)
            {
                if (((Response)respuesta).Code == "BAD_REQUEST")
                {
                    return BadRequest(respuesta);
                }

                if (((Response) respuesta).Code == "NOT_FOUND")
                {
                    return NotFound(respuesta);
                }
            }

            return Ok(respuesta);

        }
    }
}
