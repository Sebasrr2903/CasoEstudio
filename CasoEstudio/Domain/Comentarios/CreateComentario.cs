using Domain.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Comentarios
{
	public class CreateComentario
	{
		[Required]
		public DateTime Fecha { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Comment { get; set; }
	}
}
