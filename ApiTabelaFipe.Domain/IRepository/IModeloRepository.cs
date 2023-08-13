using ApiTabelaFipe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTabelaFipe.Domain.IRepository
{
    public interface IModeloRepository
    {
        Task<List<Modelo>> InserirModelos(List<Modelo> modelos);
    }
}
