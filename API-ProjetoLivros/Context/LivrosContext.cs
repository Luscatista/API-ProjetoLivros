using Microsoft.EntityFrameworkCore;
using API_ProjetoLivros.Models;

namespace API_ProjetoLivros.Context;

public class LivrosContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<TipoUsuario> TiposUsuarios { get; set; }
    public DbSet<Assinatura> Assinaturas { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
