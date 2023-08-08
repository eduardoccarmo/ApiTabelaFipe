using ApiTabelaFipe.Domain.Models;

namespace ApiTabelaFipe.Domain.IRepository
{
    public interface IMarcaRepository
    {
        Task<List<Marca>> AddMarcas(List<Marca> marcas);

        Task<List<Marca>> ObterMarcas();
    }


}
