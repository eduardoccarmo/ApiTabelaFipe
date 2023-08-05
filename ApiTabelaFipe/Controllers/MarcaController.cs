using ApiTabelaFipe.Domain.Models;
using ApiTabelaFipe.Infra.Network;
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
        private readonly IHttpServiceFipe _httpServiceFipe;

        public MarcaController(IHttpServiceFipe httpServiceFipe)
        {
            _httpServiceFipe = httpServiceFipe;
        }

        [HttpGet]
        [Route("GetMarcasAsync")]
        public async Task<IActionResult> Teste()
        {
            var marcas = await _httpServiceFipe.ObterTodasAsMarcas();
            return Ok(marcas);
        }
    }
}
