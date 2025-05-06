using API_ProjetoLivros.Interfaces;
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


}
