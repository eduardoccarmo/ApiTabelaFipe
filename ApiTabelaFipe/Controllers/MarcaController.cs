using ApiTabelaFipe.Aplication.Interfaces;
using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Infra.Network;
using Microsoft.AspNetCore.Mvc;

namespace ApiTabelaFipe.Controllers
{
    [Route("api/Marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IHttpServiceFipe _httpServiceFipe;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMarcaService _marcaService;
        private readonly IModeloRepository _modeloRepository;

        public MarcaController(IHttpServiceFipe httpServiceFipe,
                               IMarcaRepository marcaRepository,
                               IMarcaService marcaService,
                               IModeloRepository modeloRepository)
        {
            _httpServiceFipe = httpServiceFipe;
            _marcaRepository = marcaRepository;
            _marcaService = marcaService;
            _modeloRepository = modeloRepository;
        }

        [HttpGet]
        [Route("GetMarcasAsync")]
        public async Task<IActionResult> Teste()
        {
            //var ret = await _httpServiceFipe.ObterModeloPorMarca(59);

            //var modelos = _modeloRepository.InserirModelos(ret);

            var marcas = await _httpServiceFipe.ObterTodasAsMarcas();

            if (marcas is not null)
                
                return Ok(marcas);

            return BadRequest();
        }
    }
}
