using API_LastProjetct.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrototipoProjetoFinal.Data;

namespace API_LastProject.Controllers;

[ApiController]
public class PesquisaController : ControllerBase
{
    private readonly PesquisaService _service;

    public PesquisaController(PesquisaService service)
    {
        _service = service;
    }

    [HttpGet("pesquisa/getall")]
    public async Task<ActionResult<List<Pesquisa>>> GetAllAsync()
        => await _service.GetAllPesquisaAsync();

    [HttpGet("pesquisa/get/{id}")]
    public async Task<ActionResult<Pesquisa>> GetByIdPesquisa(string id)
    {
        var pesq = await _service.GetPesquisaByIdAsync(id);

        if(pesq == null)
        {
            return BadRequest(new {status = false, message = "Pesquisa não encontrada :("});
        }

        return Ok(pesq);
    }

    [HttpGet("response/get/idloja/{id}")]
    public async Task<ActionResult<Pesquisa>> GetByIdStore(int id)
    {
        var responses = await _service.GetResponseByStoreIdAsync(id);

        if (responses == null) return NotFound(new {status = false, message = "Respostas não encontradas"});

        return Ok(responses);
    }

    [HttpGet("pesquisa/get/idloja/{id}")]
    public async Task<ActionResult<List<Pesquisa>>> GetPesquisaByIdLoja(int id)
    {
        var stores = await _service.GetPesquisasByStoreIdAsync(id);

        if (stores.Count == 0) return NotFound(new { status = false, message = "Pesquisas não encontradas :(" });

        return stores;
    }

    [HttpPost("pesquisa/register")]
    public async Task<ActionResult<Pesquisa>> CreatePesquisa([FromBody] Pesquisa pesquisa)
    {
        var addResult = await _service.AddPesquisaAsync(pesquisa);

        if(!addResult) BadRequest();

        return Ok(new {status = true});
    }

    [HttpPost("response/add/{id}")]
    public async Task<ActionResult> AddResponse(string id, List<Response> res)
    {
        var addResult = await _service.AddResponseAsync(id, res);

        if(!addResult) BadRequest();

        return Ok(new { status = true });
    }
}
