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
    }
}
