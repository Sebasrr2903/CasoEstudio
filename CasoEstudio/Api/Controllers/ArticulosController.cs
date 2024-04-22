using Application.Articulos;
using Domain.Articulos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticuloService _service;

        public ArticulosController(IArticuloService service)
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


        [HttpGet("withcomments")]
		public IActionResult ListWithComments()
		{
			var result = _service.List(true);

			if (result.IsSuccess)
			{
				return Ok(result.Value);
			}

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

        [HttpGet("withlikes")]
        public IActionResult ListWithLikes()
        {
            var result = _service.List(false, true);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateArticulo articulo)
        {
            var result = _service.Create(articulo);
            if (result.IsSuccess)
            {
				return StatusCode(StatusCodes.Status201Created);
			}

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        [Route("{Id}/addcomment")]

        public IActionResult AddComment([FromRoute] int Id, [FromBody] AddComment comment)
        {
            int idComment = comment.IdComment;

            var result = _service.AddComment(Id, idComment);

            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        [Route("{Id}/addlike")]

        public IActionResult AddLike([FromRoute] int Id, [FromBody] AddLike like)
        {
            int idLike = like.IdLike;

            var result = _service.AddLike(Id, idLike);

            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }





    }
}
