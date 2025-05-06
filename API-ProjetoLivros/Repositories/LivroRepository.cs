using API_ProjetoLivros.Context;
using API_ProjetoLivros.Interfaces;
using API_ProjetoLivros.Models;

namespace API_ProjetoLivros.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly LivrosContext _context;
    public LivroRepository(LivrosContext context)
    {
        _context = context;
    }
    public List<Livro> ListarTodos()
    {
        return _context.Livros.ToList();
    }
    public Livro? BuscarPorId(int id)
    {
        return _context.Livros.FirstOrDefault(l => l.LivroId == id);
    }
    public void Cadastrar(Livro livro)
    {
        _context.Livros.Add(livro);
        _context.SaveChanges();
    }
    public void Atualizar(int id, Livro livro)
    {
        var livroAtual = _context.Livros.FirstOrDefault(l => l.LivroId == id);
        if (livroAtual == null)
        {
            throw new Exception("Livro não encontrados.");
        }

        livroAtual.Titulo = livro.Titulo;
        livroAtual.Autor = livro.Autor;
        livroAtual.DataPublicacao = livro.DataPublicacao;
        livroAtual.CategoriaId = livro.CategoriaId;
        livroAtual.Descricao = livro.Descricao;

        _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            throw new Exception("Livro não encontrado.");
        }

        _context.Livros.Remove(livro); 
        _context.SaveChanges();
    }
}
