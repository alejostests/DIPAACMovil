namespace DIPAAC.ViewModels
{
    /// <summary>
    ///     Class to return user information
    /// </summary>
    public class ReturnUserViewModel
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
        ///     Full name
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        ///     Age
        /// </summary>
        public byte Edad { get; set; }
    }
}