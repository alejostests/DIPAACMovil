using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; }

        public string NombreCompleto { get; set; }

        public byte Edad { get; set; }

        public string Contraseña { get; set; }

        public ICollection<Cuestionario> Cuestionarios { get; set; }
    }
}