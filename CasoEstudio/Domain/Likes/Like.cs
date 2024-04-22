using Domain.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Likes
{
    public class Like : Entity
    {
        public Like()
        {
        }

        public Like(int idL)
        {
            IdL = idL;
        }

        public static Like Create
           (int idL, char tipo)
        {
            return new()
            {
                IdL = idL,
                Tipo = tipo,

            };
        }

        public static Like Create(int idC, Like like)
        {
            return new()
            {
                IdL = idC,
                Tipo = like.Tipo,
            };
        }

        [Key]
        [JsonInclude]
        [JsonPropertyName("idL")]
        public int IdL { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(1, MinimumLength = 1)]
        [JsonInclude]
        [JsonPropertyName("tipo")]
        public char Tipo { get; set; }


        [JsonInclude]
        [JsonPropertyName("article")]
        public List<Articulo> Articulo { get; set; }
    }
}
