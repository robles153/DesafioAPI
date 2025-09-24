using DesafioAPI.Dominio.Repositorio;

namespace TestDesafio.Fakes
{
    public class FakeUsuarioRepositorioException : IUsuarioRepositorio
    {
        public Task AdicionarAsync(DesafioAPI.Dominio.Entidades.Usuario.Usuario usuario) => Task.CompletedTask;
        public Task<List<DesafioAPI.Dominio.Entidades.Usuario.Usuario>> ListarTodosAsync(int pageNumber, int pageSize) => Task.FromResult(new List<DesafioAPI.Dominio.Entidades.Usuario.Usuario>());
        public Task<DesafioAPI.Dominio.Entidades.Usuario.Usuario?> ObterPorIdAsync(Guid id) => Task.FromResult<DesafioAPI.Dominio.Entidades.Usuario.Usuario?>(null);
        public Task<bool> RemoverUsuarioAsync(Guid id) => throw new InvalidOperationException("Erro simulado no repositório");
        public Task<bool> AtualizarUsuarioAsync(DesafioAPI.Dominio.Entidades.Usuario.Usuario usuario) => Task.FromResult(false);
    }
}
