using System;
using System.Collections.Generic;
using DIPAAC.Models;

namespace DIPAAC.ViewModels
{
    public class CuestionarioViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TipoCuestionario Tipo { get; set; }

        public byte Calificacion { get; set; }

        public int UsuarioId { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public ICollection<RespuestaViewModel> Respuestas { get; set; }
    }
}