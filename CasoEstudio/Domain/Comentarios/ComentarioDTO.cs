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

		public ComentarioDTO(int idC, DateTime fecha, string coment)
		{
			IdC = idC;
			Fecha = fecha;
            Comment = coment;
		}

		public int IdC { get; set; }
		public DateTime Fecha { get; set; }
		public string Comment { get; set; }
	}
}
