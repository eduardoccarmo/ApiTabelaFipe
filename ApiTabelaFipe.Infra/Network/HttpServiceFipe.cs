using ApiTabelaFipe.Domain.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiTabelaFipe.Infra.Network
{
    internal class HttpServiceFipe : IHttpServiceFipe
    {
        private readonly HttpClient _httpClient;

        public HttpServiceFipe(HttpClient httpClient)
        {

            _httpClient.BaseAddress = new Uri("https://parallelum.com.br/fipe/api/v1/");
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Marca>> ObterTodasAsMarcas()
        {
            using (var response = await _httpClient.GetAsync("carros/marcas"))
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
