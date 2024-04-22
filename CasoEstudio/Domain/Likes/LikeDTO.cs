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

        public LikeDTO(int idL, char tipo)
        {
            IdL = idL;
            Tipo = tipo;

        }

        public int IdL { get; set; }
        public char Tipo { get; set; }

    }
}
