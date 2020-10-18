using System.Linq;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class CuestionarioRepository : ICuestionarioRepository
    {
        private readonly DipaacContext _context;

        public CuestionarioRepository(DipaacContext context)
        {
            _context = context;
        }

        public IQueryable<Cuestionario> GetAllCuestionarios()
        {
            return _context.Cuestionarios;
        }

        public IQueryable<Cuestionario> GetCuestionarioById(int id)
        {
            return _context.Cuestionarios.Where(c => c.Id == id);
        }

        public void AddCuestionario(Cuestionario cuestionario)
        {
            _context.Add(cuestionario);
            _context.SaveChanges();
        }
    }
}