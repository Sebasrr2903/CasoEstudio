using Domain.Articulos;
using FluentValidation;

namespace Application.Articulos
{
	public class CreateArticuloValidator : AbstractValidator<CreateArticulo>
	{
        public CreateArticuloValidator()
        {
         
            RuleFor(o => o.Header).Length(2, 30);
            RuleFor(o => o.Body).Length(2, 250);
     
		}
    }
}
