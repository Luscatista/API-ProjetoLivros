using API_ProjetoLivros.Context;
using API_ProjetoLivros.Interfaces;
using API_ProjetoLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ProjetoLivros.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly LivrosContext _context;
    public CategoriaRepository(LivrosContext context)
    {
        _context = context;
    }
    public List<Categoria> ListarTodos()
    {
        return _context.Categorias.ToList();
    }
    public Categoria? BuscarPorId(int id)
    {
        return _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
    }
    public void Cadastrar(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
    }
    public void Atualizar(int id, Categoria categoria)
    {
        var categoriaAtual = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        if (categoriaAtual == null)
        {
            throw new Exception("Categoria não encontrada.");
        }

        categoriaAtual.NomeCategoria = categoria.NomeCategoria;

        _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if(categoria == null)
        {
            throw new Exception("Categoria não encontrada.");
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
    }

}
