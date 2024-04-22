using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Likes
{
    public class CreateLike
    {
        public int IdL { get; set; }

        [Required(AllowEmptyStrings = false)]
        public char Tipo { get; set; }

    }
}
