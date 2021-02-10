using System;

namespace DotNet.Misc.Security.Data
{
    /// <summary>
    /// Represents a piece of data encrypted by
    /// DotNet.Misc.Security
    /// </summary>
    public struct EncryptedData
    {
        /// <summary>
        /// Gets the encrypted data as a string.
        /// </summary>
        public string Data { get; internal set; }

        internal EncryptedData(string data)
        {
            Data = data;
        }

        public override string ToString() => "DotNet.Misc.Security Encrypted Data";
        public override int GetHashCode() => Data.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj is EncryptedData enc)
                return Data.Equals(enc.Data);

            return false;
        }
    }
}
