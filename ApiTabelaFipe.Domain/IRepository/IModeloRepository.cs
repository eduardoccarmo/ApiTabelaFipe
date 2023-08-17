using ApiTabelaFipe.Domain.Models;

namespace ApiTabelaFipe.Domain.IRepository
{
    public interface IModeloRepository
    {
        Task<List<Modelo>> InserirModelos(List<Modelo> modelos);

        Task<IEnumerable<Modelo>> ObterModeloPorMarca(int codigoMarca);
    }
}
