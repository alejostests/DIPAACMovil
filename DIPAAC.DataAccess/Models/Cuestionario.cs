using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Cuestionario
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public byte Tipo { get; set; }

        public byte Calificacion { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public ICollection<Respuesta> Respuestas { get; set; }
    }
}