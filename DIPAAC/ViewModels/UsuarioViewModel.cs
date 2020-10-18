using DIPAAC.Models.Interfaces;

namespace DIPAAC.ViewModels
{
    /// <inheritdoc />
    public class UsuarioViewModel : Persona
    {
        /// <summary>
        ///     User id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     User name
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        ///     Password
        /// </summary>
        public string Contraseña { get; set; }
    }
}