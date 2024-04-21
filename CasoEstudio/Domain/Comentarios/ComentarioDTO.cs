using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Comentarios
{
	public class ComentarioDTO
	{
		public ComentarioDTO()
		{
		}

		public ComentarioDTO(int id, DateTime fecha, string comment)
		{
			Id = id;
			Fecha = fecha;
			Comentario = comment;
		}

		public int Id { get; set; }
		public DateTime Fecha { get; set; }
		public string Comentario { get; set; }
	}
}
