using ApiTabelaFipe.Aplication.Interfaces;
using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Domain.Models;

namespace ApiTabelaFipe.Aplication.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository repository)
        {
            _marcaRepository = repository;
        }

        public async Task<List<Marca>> InserirMarcas()
        {
            return null;
        }


        public Task<List<Marca>> InserirMarcas(List<Marca> marcas)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Marca>> ObterMarcas()
        {
            var marcas = await _marcaRepository.ObterMarcas();

            if (marcas is not null)
                return marcas;

            return null;
        }
    }
}
