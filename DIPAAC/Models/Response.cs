namespace DIPAAC.Models
{
    /// <summary>
    ///     Class that defines if the response of a service or controller is successfully or not
    /// </summary>
    public class Response
    {
        /// <summary>
        ///     Types of responses
        /// </summary>
        public enum ResponseCode
        {
            /// <summary>
            ///     OK if is successfully
            /// </summary>
            Ok,

            /// <summary>
            ///     Error if is not successfully
            /// </summary>
            Error
        }

        /// <summary>
        ///     Code response
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Message response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Description response
        /// </summary>
        public string Description { get; set; }
    }
}