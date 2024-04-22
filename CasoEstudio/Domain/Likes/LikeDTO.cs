using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Likes
{
    public class LikeDTO
    {
        public LikeDTO()
        {
        }

        public LikeDTO(int idL, char tipo, string username)
        {
            IdL = idL;
            Tipo = tipo;
            Username = username;

        }

        public int IdL { get; set; }
        public char Tipo { get; set; }
        public string Username { get; set; }

    }
}
