using Application.Articulos;
using AutoMapper;
using Domain.Articulos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly IValidator<CreateArticulo> _createValidator;
        private readonly IArticuloClient _client;
        private readonly IMapper _mapper;

        public HomeController(

            IValidator<CreateArticulo> createValidator,
            IArticuloClient client,
            IMapper mapper)
        {
            _createValidator = createValidator;

            _client = client;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var Articulos = await _client.List();
            return View(Articulos);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateArticulo());
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateArticulo model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _client.Create(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }


            return View(model);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
