using ApiTabelaFipe.Aplication.Interfaces;
using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Domain.Models;
using ApiTabelaFipe.Infra.Network;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiTabelaFipe.Controllers
{
    [Route("api/Marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IHttpServiceFipe _httpServiceFipe;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMarcaService _marcaService;

        public MarcaController(IHttpServiceFipe httpServiceFipe,
                               IMarcaRepository marcaRepository,
                               IMarcaService marcaService)
        {
            _httpServiceFipe = httpServiceFipe;
            _marcaRepository = marcaRepository;
            _marcaService = marcaService;
        }

        [HttpGet]
        [Route("GetMarcasAsync")]
        public async Task<IActionResult> Teste()
        {
            var ret = await _marcaService.InserirMarcas();

            if (ret is not null)
                return Ok(ret);

            return BadRequest();
        }
    }
}
