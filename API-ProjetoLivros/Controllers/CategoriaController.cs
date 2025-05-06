using API_ProjetoLivros.Interfaces;
using API_ProjetoLivros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProjetoLivros.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;
    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(_categoriaRepository.ListarTodos());
    }
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var categoria = _categoriaRepository.BuscarPorId(id);
        if(categoria == null)
        {
            return NotFound("Categoria não encontrada.");
        }
        return Ok(categoria);
    }

    [HttpPost]
    public IActionResult Cadastrar(Categoria categoria)
    {
        _categoriaRepository.Cadastrar(categoria);
        return Created();
    }

    [HttpPut]
    public IActionResult Editar(int id, Categoria categoria)
    {
        try
        {
            _categoriaRepository.Atualizar(id, categoria);
            return Ok(categoria);
        }
        catch (Exception)
        {
            return NotFound("Categoria não encontrada.");
        }

    }

    [HttpDelete]
    public IActionResult Deletar(int id)
    {
        try
        {
            _categoriaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("Categoria não encontrada.");
        }
        
    }
}
