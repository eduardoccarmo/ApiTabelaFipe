using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTabelaFipe.Domain.Models
{
    public class Root
    {
        public List<Modelo>? modelos { get; set; }
        public List<Ano>? anos { get; set; }
    }

}
