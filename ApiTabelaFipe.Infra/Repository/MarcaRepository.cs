using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Domain.Models;
using ApiTabelaFipe.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiTabelaFipe.Infra.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly ApiContext _context;

        public MarcaRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> AddMarcas(List<Marca> marcas)
        {
            try
            {

                _context.Marcas.AddRange(marcas);
                var ret = await _context.SaveChangesAsync();

                return marcas;
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException(message: "Occoreu um erro ao inserir os registros no banco de dados.");
            }
        }

        public async Task<List<Marca>> ObterMarcas()
        {
            var marcas = await _context
                               .Marcas
                               .AsNoTracking()
                               .ToListAsync();

            return marcas; 
        }

        public async Task<Marca> ObterModelos(int codMarca)
        {
            var marca = await _context
                .Marcas
                .Include(x => x.Modelos)
                .FirstOrDefaultAsync(x => x.Codigo == codMarca);

            return marca;        
        }
    }
}
