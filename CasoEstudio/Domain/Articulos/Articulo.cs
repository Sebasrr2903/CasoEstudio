
using Domain.Comentarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Articulos
{
    public class Articulo : Entity
    {
        public Articulo()
        {
        }

        public static Articulo Create
            (int id, string header, string body)
        {
            return new()
            {
                Id = id,
                Header = header,
                Body = body,
               
            };
        }

        public static Articulo Create (int id, Articulo Articulo)
        {
            return new()
            {
                Id = id,
                Header = Articulo.Header,
                Body = Articulo.Body,
				
           
            };
        }

        [Key]
		[JsonInclude]
		[JsonPropertyName("id")]
        public int Id { get; set; } 

        [Required(AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 5)]
		[JsonInclude]
		[JsonPropertyName("header")]
        public string Header { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 2)]
		[JsonInclude]
		[JsonPropertyName("body")]
        public string  Body { get; private set; }


		[JsonInclude]
		[JsonPropertyName("comments")]
		public List<Comentario> Comentario { get; set; }



	}
}
