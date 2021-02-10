using DotNet.Misc.Security.Data;
using Rijndael256;

namespace DotNet.Misc.Security
{
    /// <summary>
    /// Entry point for data encryption and
    /// decryption using DotNet.Misc.Security
    /// </summary>
    public static class Safely
    {
        internal static string Password { get; set; }
        internal static string DefaultPassword { get; }

        static Safely()
        {
            Password = "c27d281f-a267-41a3-9127-6b3cd018d2f3";
            DefaultPassword = Password;
        }

        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>Encrypted data</returns>
        public static EncryptedData Encrypt(string data)
        {
            var safe = Rijndael.Encrypt(data, Password, KeySize.Aes256);
            return new EncryptedData(safe);
        }

        /// <summary>
        /// Encrypts an object. The object's type should
        /// implement IStringSerializable; otherwise its
        /// .ToString() method will be used.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="data">Object</param>
        /// <returns>Encrypted data</returns>
        public static EncryptedData Encrypt<T>(T data)
        {
            string safe;
            if (typeof(IStringSerializable<T>).IsAssignableFrom(typeof(T)))
                safe = Rijndael.Encrypt((data as IStringSerializable<T>).Serialize(), Password, KeySize.Aes256);
            else
                safe = Rijndael.Encrypt(data.ToString(), Password, KeySize.Aes256);

            return new EncryptedData(safe);
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="data">string</param>
        /// <returns>Decrypted data</returns>
        public static DecryptedData Decrypt(string data)
        {
            try
            {
                var result = Rijndael.Decrypt(data, Password, KeySize.Aes256);
                return new DecryptedData(result);
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                return new DecryptedData("");
            }
        }

        /// <summary>
        /// Decrypts a piece of encrypted data.
        /// </summary>
        /// <param name="data">Encrypted data</param>
        /// <returns>Decrypted data</returns>
        public static DecryptedData Decrypt(EncryptedData data)
        {
            try
            {
                var result = Rijndael.Decrypt(data.Data, Password, KeySize.Aes256);
                return new DecryptedData(result);
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                return new DecryptedData("");
            }
        }
    }
}
