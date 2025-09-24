using DesafioAPI.Dominio.Entidades.Usuario;

namespace DesafioAPI.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task AdicionarAsync(Usuario usuario);        
        Task<List<Usuario>> ListarTodosAsync(int pageNumber, int pageSize);
    }
}
