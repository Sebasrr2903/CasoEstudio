using Application.Articulos;
using Application.Comentarios;
using Domain.Articulos;
using Domain.Comentarios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private IComentarioService _service;

        public ComentariosController(IComentarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _service.List();

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = _service.Get(id);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateComentario comentario)
        {
            var result = _service.Create(comentario);
            if (result.IsSuccess)
            {
				//return Created(); ***No funciona***
				return StatusCode(StatusCodes.Status201Created);
			}

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
