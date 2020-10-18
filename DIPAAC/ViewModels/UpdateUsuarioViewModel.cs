using System.ComponentModel.DataAnnotations;

namespace DIPAAC.ViewModels
{
    /// <summary>
    ///     Class to update an user
    /// </summary>
    public class UpdateUsuarioViewModel
    {
        /// <summary>
        ///     User id
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

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
        public string Contraseña { get; set; }

        /// <summary>
        ///     Confirmed password
        /// </summary>
        public string ContraseñaConfirmada { get; set; }
    }
}