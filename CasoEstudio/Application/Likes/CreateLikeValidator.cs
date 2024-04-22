using Domain.Articulos;
using Domain.Comentarios;
using Domain.Likes;
using FluentValidation;
using System.Threading.Tasks;

namespace Application.Comentarios
{
	public class CreateLikeValidator : AbstractValidator<CreateLike>
	{
		public CreateLikeValidator()
		{
	
			RuleFor(o => o.Tipo).NotEmpty();
            RuleFor(o => o.Username).Length(5, 50);


        }
    }
}
