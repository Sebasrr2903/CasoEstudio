using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Articulos
{
    public class CreateArticulo
    {
		[Required(AllowEmptyStrings = false)]
		public string Header { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Title { get; set; }


    }
}
