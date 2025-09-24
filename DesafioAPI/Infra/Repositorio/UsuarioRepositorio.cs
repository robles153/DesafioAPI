using DesafioAPI.Dominio.Entidades.Usuario;
using DesafioAPI.Dominio.Repositorio;
using DesafioAPI.Infra.Percistencia;
using Microsoft.EntityFrameworkCore;

namespace DesafioAPI.Infra.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> ListarTodosAsync(int pageNumber, int pageSize)
        {
            return await _context.Usuarios
                .OrderBy(u => u.Nome)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Usuario?> ObterPorIdAsync(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> RemoverUsuarioAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AtualizarUsuarioAsync(Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(usuario.Id);
            if (usuarioExistente == null)
                return false;
            
            usuarioExistente.AtualizarDadosUsuario(
                usuario.Email,
                usuario.Telefone,
                usuario.Celular,
                usuario.FotoUrl,
                usuario.Nacionalidade
            );

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
