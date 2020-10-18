using DataAccess.Context;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class RespuestaRepository : IRespuestaRepository
    {
        private readonly DipaacContext _context;

        public RespuestaRepository(DipaacContext context)
        {
            _context = context;
        }

        public void AddRespuesta(Respuesta respuesta)
        {
            _context.Add(respuesta);
            _context.SaveChanges();
        }
    }
}