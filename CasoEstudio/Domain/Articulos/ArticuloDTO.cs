using Domain.Comentarios;
using Domain.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Articulos
{
    public class ArticuloDTO
    {
        public ArticuloDTO()
        {
        }

        public ArticuloDTO(int id, string header, string body)
        {
            Id = id;
            Header = header;
            Body = body;
        }

        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get;  set; }

        public List<ComentarioDTO> Comentario { get; set; }

        public List<LikeDTO> Like { get; set; }

    }
}
