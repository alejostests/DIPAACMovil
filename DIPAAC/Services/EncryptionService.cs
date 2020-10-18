using System.Security.Cryptography;
using System.Text;

namespace DIPAAC.Services
{
    /// <summary>
    ///     Service that encrypts information
    /// </summary>
    public class EncryptionService
    {
        /// <summary>
        ///     Encrypts a string
        /// </summary>
        /// <param name="str">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        public static string GetSHA256(string str)
        {
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            foreach (var t in stream)
                sb.AppendFormat("{0:x2}", t);

            return sb.ToString();
        }
    }
}