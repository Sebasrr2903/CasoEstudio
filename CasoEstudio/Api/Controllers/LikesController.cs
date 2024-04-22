

using Application.Likes;
using Domain.Articulos;
using Domain.Likes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private ILikeService _service;

        public LikesController(ILikeService service)
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
        public IActionResult Create([FromBody] CreateLike like)
        {
            var result = _service.Create(like);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


    }
}
