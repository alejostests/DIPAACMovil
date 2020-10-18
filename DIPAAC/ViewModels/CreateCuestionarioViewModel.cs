using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DIPAAC.Models;

namespace DIPAAC.ViewModels
{
    /// <summary>
    ///     Class to create a questionnaire
    /// </summary>
    public class CreateCuestionarioViewModel
    {
        /// <summary>
        ///     Questionnaire type: <br />
        ///     0 - Ideognostic
        ///     1 - Operational
        ///     2 - Verbal
        /// </summary>
        [Required]
        [Range(0, 2)]
        public TipoCuestionario Tipo { get; set; }

        /// <summary>
        ///     User id
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int UsuarioId { get; set; }

        /// <summary>
        ///     List of answers
        /// </summary>
        public IList<CreateRespuestaViewModel> Respuestas { get; set; }
    }
}