using System.ComponentModel.DataAnnotations;

namespace DIPAAC.ViewModels
{
    /// <summary>
    ///     Class to create an user
    /// </summary>
    public class CreateUsuarioViewModel
    {
        /// <summary>
        ///     Full name
        /// </summary>
        [Required]
        [MinLength(6)]
        [MaxLength(32)]
        public string NombreCompleto { get; set; }

        /// <summary>
        ///     User name
        /// </summary>
        [Required]
        [MinLength(6)]
        [MaxLength(16)]
        public string NombreUsuario { get; set; }

        /// <summary>
        ///     Age
        /// </summary>
        [Required]
        [Range(6, 9)]
        public byte Edad { get; set; }

        /// <summary>
        ///     Password
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Contraseña { get; set; }

        /// <summary>
        ///     Confirmed password
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string ContraseñaConfirmada { get; set; }
    }
}