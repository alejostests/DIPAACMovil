using System.Linq;
using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICuestionarioRepository
    {
        IQueryable<Cuestionario> GetAllCuestionarios();

        IQueryable<Cuestionario> GetCuestionarioById(int id);

        void AddCuestionario(Cuestionario cuestionario);
    }
}