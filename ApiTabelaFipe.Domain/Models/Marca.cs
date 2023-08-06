using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTabelaFipe.Domain.Models
{
    public class Marca
    {
        public int Codigo { get; set; }

        public string? Nome { get; set; }

        public IList<Modelo>? Modelo { get; set; }
    }
}
