using ApiTabelaFipe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTabelaFipe.Aplication.Interfaces
{
    public interface IMarcaService
    {
        Task<List<Marca>> ObterMarcas();

        Task<List<Marca>> InserirMarcas(List<Marca> marcas);
    }
}
