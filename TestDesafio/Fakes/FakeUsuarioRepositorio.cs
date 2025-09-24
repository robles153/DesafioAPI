using DesafioAPI.Dominio.Entidades.Usuario;
using DesafioAPI.Dominio.Repositorio;

namespace TestDesafio.Fakes
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly List<Usuario> _usuarios;
       
        public FakeUsuarioRepositorio(List<Usuario>? usuarios)
        {
            _usuarios = usuarios ?? new List<Usuario>();
        }
      
        public FakeUsuarioRepositorio(Usuario? usuario)
        {
            _usuarios = usuario != null ? new List<Usuario> { usuario } : new List<Usuario>();
        }

        public Task<Usuario?> ObterPorIdAsync(Guid id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            return Task.FromResult<Usuario?>(usuario);
        }

        public Task<List<Usuario>> ListarTodosAsync(int pageNumber, int pageSize)
        {            
            var paged = _usuarios
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Task.FromResult(paged);
        }

        public Task AdicionarAsync(Usuario usuario)
        {
            _usuarios.Add(usuario);
            return Task.CompletedTask;
        }

        public Task<bool> RemoverUsuarioAsync(Guid id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return Task.FromResult(false);
            _usuarios.Remove(usuario);
            return Task.FromResult(true);
        }

        public Task<bool> AtualizarUsuarioAsync(Usuario usuario)
        {
            var usuarioExistente = _usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (usuarioExistente == null)
                return Task.FromResult(false);

            usuarioExistente.AtualizarDadosUsuario(
                usuario.Email,
                usuario.Telefone,
                usuario.Celular,
                usuario.FotoUrl,
                usuario.Nacionalidade
            );
            return Task.FromResult(true);
        }
    }
}
