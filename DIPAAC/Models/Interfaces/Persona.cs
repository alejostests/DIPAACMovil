namespace DIPAAC.Models.Interfaces
{
    /// <summary>
    ///     Define the structure of a person
    /// </summary>
    public abstract class Persona
    {
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