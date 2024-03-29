﻿using ApiTabelaFipe.Domain.Models;
using Newtonsoft.Json;

namespace ApiTabelaFipe.Infra.Network
{
    public class HttpServiceFipe : IHttpServiceFipe
    {
        private readonly HttpClient _httpClient;

        public HttpServiceFipe(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://parallelum.com.br/fipe/api/v1/");
        }

        public async Task<List<Modelo>> ObterModeloPorMarca(int marca)
        {
            var modelos = new List<Modelo>();

            using (var response = await _httpClient.GetAsync($"carros/marcas/{marca}/modelos"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    if (result is not null)
                    {
                        var rootModelos = JsonConvert.DeserializeObject<Root>(result);

                        foreach (var modelo in rootModelos.modelos)
                        {
                            modelo.MarcaCodigo = marca;

                            modelos.Add(new Modelo
                            {
                                Codigo = modelo.Codigo,
                                Nome = modelo.Nome,
                                MarcaCodigo = modelo.MarcaCodigo
                            });
                        }
                        return modelos;
                    };
                }

                return null;
            }
        }

        public async Task<List<Marca>> ObterTodasAsMarcas()
        {
            using (var response = await _httpClient.GetAsync("motos/marcas"))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (result is not null)
                {
                    var marcas = JsonConvert.DeserializeObject<List<Marca>>(result);

                    return marcas;
                }

                return null;
            }
        }
    }
}
