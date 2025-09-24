using DesafioAPI.Dominio.Entidades.Usuario;
using DesafioAPI.Dominio.Repositorio;

namespace DesafioAPI.Infra.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Task AdicionarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> ListarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
