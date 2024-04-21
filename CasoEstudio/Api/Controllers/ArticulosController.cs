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


		[HttpPost]
        public IActionResult Create([FromBody] CreateArticulo articulo)
        {
            var result = _service.Create(articulo);
            if (result.IsSuccess)
            {
				//return Created(); ***No funciona***
				return StatusCode(StatusCodes.Status201Created);
			}

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    


    
    }
}
