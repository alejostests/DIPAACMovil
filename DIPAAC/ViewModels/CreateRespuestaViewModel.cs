using System.ComponentModel.DataAnnotations;

namespace DIPAAC.ViewModels
{
    /// <summary>
    ///     Class for creating a questionnaire answer
    /// </summary>
    public class CreateRespuestaViewModel
    {
        /// <summary>
        ///     Is correct
        /// </summary>
        [Required]
        public bool EsCorrecta { get; set; }

        /// <summary>
        ///     Answer entered
        /// </summary>
        [Required]
        public string RespuestaIngresada { get; set; }

        /// <summary>
        ///     Question
        /// </summary>
        [Required]
        public string Pregunta { get; set; }
    }
}