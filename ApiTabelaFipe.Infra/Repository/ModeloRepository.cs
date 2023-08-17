using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Domain.Models;
using ApiTabelaFipe.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiTabelaFipe.Infra.Repository
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly ApiContext? _context;

        public ModeloRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Modelo>> InserirModelos(List<Modelo> modelos)
        {
            try
            {
                _context.Modelos.AddRange(modelos);
                _context.SaveChanges();

                return modelos;
            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException(message: ex.Message);
            }           
        }

        public async Task<IEnumerable<Modelo>> ObterModeloPorMarca(int codigoMarca)
        {
            var modelos = new List<Modelo>();

            modelos = await _context
                            .Modelos
                            .Include(x => x.Marca)
                            .ThenInclude(x => x.Modelos)
                            .Where(x => x.Marca.Codigo == codigoMarca)
                            .ToListAsync();
            return modelos;
        }
    }
}
