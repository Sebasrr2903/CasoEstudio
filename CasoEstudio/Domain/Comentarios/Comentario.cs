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

        public Comentario(int idC)
        {
			IdC = idC;
        }

        public static Comentario Create
		   (int idC, DateTime fecha, string comment, string username)
		{
			return new()
			{
				IdC = idC,
				Fecha = fecha,
				Comment = comment,
				Username = username,

			};
		}

		public static Comentario Create(int idC, Comentario comment)
		{
			return new()
			{
				IdC = idC,
				Fecha = comment.Fecha,
				Comment = comment.Comment,
				Username = comment.Username,
			};
		}

		[Key]
		[JsonInclude]
		[JsonPropertyName("idC")]
		public int IdC { get; set; }

		[JsonInclude]
		[JsonPropertyName("fecha")]
		public DateTime Fecha { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(100, MinimumLength = 5)]
		[JsonInclude]
		[JsonPropertyName("comment")]
		public string Comment { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 5)]
        [JsonInclude]
        [JsonPropertyName("username")]
        public string Username { get; set; }


        [JsonInclude]
		[JsonPropertyName("article")]
		public List<Articulo> Articulo { get; set; }
	}
}
