using System.Linq;
using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        IQueryable<Usuario> GetUsuarioById(int id);

        IQueryable<Usuario> GetUsuarioByUserName(string userName);

        void AddUsuario(Usuario usuario);

        void UpdateUsuario(Usuario usuario);
    }
}