using ApiTabelaFipe.Domain.Models;
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

        public async Task<List<Marca>> ObterTodasAsMarcas()
        {
            using (var response = await _httpClient.GetAsync("caminhoes/marcas"))
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
