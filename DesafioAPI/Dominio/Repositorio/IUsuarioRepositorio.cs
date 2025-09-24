using DesafioAPI.Dominio.Entidades.Usuario;

namespace DesafioAPI.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task AdicionarAsync(Usuario usuario);        
        Task<List<Usuario>> ListarTodosAsync(int pageNumber, int pageSize);
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task<bool> RemoverUsuarioAsync(Guid id);
        Task<bool> AtualizarUsuarioAsync(Usuario usuario);
    }
}
