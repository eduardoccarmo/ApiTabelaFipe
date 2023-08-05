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

        public MarcaController(IHttpServiceFipe httpServiceFipe, IMarcaRepository marcaRepository)
        {
            _httpServiceFipe = httpServiceFipe;
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        [Route("GetMarcasAsync")]
        public async Task<IActionResult> Teste()
        {
            try
            {
                var marcas = await _httpServiceFipe.ObterTodasAsMarcas();

                await _marcaRepository.AddMarcas(marcas);

                return Ok(marcas);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
