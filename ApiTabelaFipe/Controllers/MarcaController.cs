using ApiTabelaFipe.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiTabelaFipe.Controllers
{
    [Route("api/Marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        [HttpGet]
        [Route("GetMarcasAsync")]
        public async Task<IActionResult> Teste()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://parallelum.com.br/fipe/api/v1/") };

            var response = await client.GetAsync("carros/marcas");

            var content = await response.Content.ReadAsStringAsync();

            var marcas = JsonConvert.DeserializeObject<List<Marca>>(content);

            return Ok(marcas);
        }
    }
}
