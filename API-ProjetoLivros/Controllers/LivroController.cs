using API_ProjetoLivros.Interfaces;
using API_ProjetoLivros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProjetoLivros.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroRepository _livroRepository;

    public LivroController(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(_livroRepository.ListarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var livro = _livroRepository.BuscarPorId(id);
        if (livro == null)
        {
            return NotFound("Livro não encontrado.");
        }

        return Ok(livro);
    }

    [HttpPost]
    public IActionResult Cadastrar(Livro livro)
    {
        _livroRepository.Cadastrar(livro);
        return Created();
    }

    [HttpPut]
    public IActionResult Editar(int id, Livro livro)
    {
        try
        {
            _livroRepository.Atualizar(id, livro);
            return Ok(livro);
        }
        catch (Exception)
        {
            return NotFound("Livro não encontrado");
        }        
    }

    [HttpDelete]
    public IActionResult Deletar(int id)
    {
        try
        {
            _livroRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("Livro não encontrado");
        }
    }
}
