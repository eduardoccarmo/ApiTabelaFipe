using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Domain.Models;
using ApiTabelaFipe.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
