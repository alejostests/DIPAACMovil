using System.Linq;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DipaacContext _context;

        public UsuarioRepository(DipaacContext context)
        {
            _context = context;
        }

        public IQueryable<Usuario> GetUsuarioById(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id);
        }

        public IQueryable<Usuario> GetUsuarioByUserName(string userName)
        {
            return _context.Usuarios.Where(u => u.NombreUsuario == userName);
        }

        public void AddUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}