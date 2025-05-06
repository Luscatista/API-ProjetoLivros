using API_ProjetoLivros.Models;

namespace API_ProjetoLivros.Interfaces;

public interface ILivroRepository
{
    List<Livro> ListarTodos();
    Livro BuscarPorId(int id);
    void Cadastrar(Livro livro);
    void Atualizar(int id, Livro livro);
    void Deletar(int id);
}
