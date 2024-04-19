
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
            (int id, string title, string header)
        {
            return new()
            {
                Id = id,
                Title = title,
                Header = header
               
            };
        }

        public static Articulo Create (int id, Articulo Articulo)
        {
            return new()
            {
                Id = id,
                Title = Articulo.Title,
                Header = Articulo.Header,
				
           
            };
        }

        [Key]
		[JsonInclude]
		[JsonPropertyName("id")]
        public int Id { get; set; } 

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
		[JsonInclude]
		[JsonPropertyName("title")]
        public string Title { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2)]
		[JsonInclude]
		[JsonPropertyName("header")]
        public string  Header { get; private set; }

       
     
    }
}
