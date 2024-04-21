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
	public class Comentario : Entity
	{
        public Comentario()
        {            
        }

		public static Comentario Create
		   (int id, DateTime fecha, string comment)
		{
			return new()
			{
				Id = id,
				Fecha = fecha,
				Comment = comment,

			};
		}

		public static Comentario Create(int id, Comentario comment)
		{
			return new()
			{
				Id = id,
				Fecha = comment.Fecha,
				Comment = comment.Comment,
			};
		}

		[Key]
		[JsonInclude]
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonInclude]
		[JsonPropertyName("fecha")]
		public DateTime Fecha { get; private set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(100, MinimumLength = 5)]
		[JsonInclude]
		[JsonPropertyName("comentario")]
		public string Comment { get; private set; }


		[JsonInclude]
		[JsonPropertyName("article")]
		public List<Articulo> Articulo { get; private set; }
	}
}
