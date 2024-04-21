using AutoMapper;
using Domain.Articulos;
using Domain.Comentarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Articulos
{
    public class ArticuloProfile : Profile
    {
        public ArticuloProfile() 
        {
            CreateMap<CreateArticulo, Articulo>();

            CreateMap<Articulo, ArticuloDTO>()
                .ConstructUsing(source => 
                    new ArticuloDTO(source.Id, source.Header, source.Body));

            CreateMap<AddComment, Comentario>()
                .ConstructUsing(source =>
                    new Comentario(source.IdComment));

        }

	}
}
