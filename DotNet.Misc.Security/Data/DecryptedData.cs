using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Misc.Security.Data
{
    /// <summary>
    /// Represents a piece of data decrypted
    /// by DotNet.Misc.Security
    /// </summary>
    public struct DecryptedData
    {
        /// <summary>
        /// Gets the decrypted data as a string.
        /// </summary>
        public string Data { get; internal set; }

        internal DecryptedData(string data)
        {
            Data = data;
        }

        public override string ToString() => "DotNet.Misc.Security Decrypted Data";
        public override int GetHashCode() => Data.GetHashCode();
        public override bool Equals(object obj) => Data.GetHashCode().Equals(obj.GetHashCode());
    }
}
