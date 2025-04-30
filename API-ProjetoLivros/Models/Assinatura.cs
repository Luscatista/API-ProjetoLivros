namespace API_ProjetoLivros.Models;

public class Assinatura
{
    public int AssinaturaId { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Status { get; set; }
}
