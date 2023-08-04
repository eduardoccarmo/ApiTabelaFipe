using ApiTabelaFipe.Domain.Models;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTabelaFipe.Infra.Network
{
    public interface IHttpServiceFipe
    {
        Task<IEnumerable<Marca>> ObterTodasAsMarcas(); 
    }
}
