using ApiTabelaFipe.Aplication.Interfaces;
using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Xml.Linq;

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
            string path = "C:\\Users\\eduar\\Downloads\\marcas-e-modelos\\marcas-carros.csv";

            string[] text = new string[2];

            var file = await File.ReadAllLinesAsync(path);

            var newMarcas = new List<Marca>();

            var registrosDuplicados = new List<Marca>();

            foreach (var f in file)
            {
                text = f.Split(';');

                newMarcas.Add(
                    new Marca
                    {
                        Codigo = int.Parse(text[0]),
                        Nome = text[1].ToString()
                    });
            }

            var marcasRegistradasNoBanco = await _marcaRepository.ObterMarcas();

            foreach (var marca in marcasRegistradasNoBanco)
            {
                var existeCadastro = newMarcas.FirstOrDefault(x => x.Codigo == marca.Codigo);

                if (existeCadastro is not null)
                {
                    registrosDuplicados.Add(new Marca
                    {
                        Codigo = existeCadastro.Codigo,
                        Nome = existeCadastro.Nome
                    });
                }
            }

        var newList = newMarcas.Except(registrosDuplicados).ToList();

        var ret = await _marcaRepository.AddMarcas(newList);

            if (ret is not null)
                return ret;

            return null;
        }

    public Task<List<Marca>> InserirMarcas(List<Marca> marcas)
    {
        throw new NotImplementedException();
    }

    public Task<List<Marca>> ObterMarcas()
    {
        throw new NotImplementedException();
    }
}
}
