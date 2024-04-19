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

        public ArticuloDTO(int id, string title, string header)
        {
            Id = id;
            Title = title;
            Header = header;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Header { get;  set; }
    }
}
