using Domain.Articulos;
using FluentValidation;

namespace Application.Articulos
{
	public class CreateArticuloValidator : AbstractValidator<CreateArticulo>
	{
        public CreateArticuloValidator()
        {
         
            RuleFor(o => o.Title).Length(2, 40);
            RuleFor(o => o.Header).Length(2, 40);
     
		}
    }
}
