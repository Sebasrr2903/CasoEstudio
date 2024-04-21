using Domain.Articulos;
using Domain.Comentarios;
using FluentValidation;
using System.Threading.Tasks;

namespace Application.Comentarios
{
	public class CreateComentarioValidator : AbstractValidator<CreateComentario>
	{
		public CreateComentarioValidator()
		{
	
			RuleFor(o => o.Comment).Length(5, 100);

		}
	}
}
