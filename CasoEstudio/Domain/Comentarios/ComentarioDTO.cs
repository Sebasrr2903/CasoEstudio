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

		public ComentarioDTO(int idC, DateTime fecha, string coment, string username)
		{
			IdC = idC;
			Fecha = fecha;
            Comment = coment;
			Username = username;
		}

		public int IdC { get; set; }
		public DateTime Fecha { get; set; }
		public string Comment { get; set; }
        public string Username { get; set; }

    }
}
