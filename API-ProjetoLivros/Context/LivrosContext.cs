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

    public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //string de conexao
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-8ED5M2P\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(
            //Representação da tabela
            entity =>
            {
                //Primary Key
                entity.HasKey(u => u.UsuarioId);

                entity.Property(u => u.NomeCompleto).IsRequired().HasMaxLength(150).IsUnicode(false);

                entity.Property(u => u.Email).IsRequired().HasMaxLength(150).IsUnicode(false);

                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(u => u.Senha).IsRequired().HasMaxLength(150).IsUnicode(false);

                entity.Property(u => u.Telefone).HasMaxLength(150).IsUnicode(false);

                entity.Property(u => u.Senha).IsRequired().HasMaxLength(255).IsUnicode(false);

                entity.Property(u => u.DataCadastro).IsRequired();

                entity.Property(u => u.DataAtualizacao).IsRequired();

                entity.HasOne(u => u.TipoUsuario).WithMany(t => t.Usuarios).HasForeignKey(u => u.TipoUsuarioId).OnDelete(DeleteBehavior.Cascade);

            }
        );
    }
}
