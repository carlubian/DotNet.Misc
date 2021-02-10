using System;

namespace DotNet.Misc.Security
{
    /// <summary>
    /// Allows the user to change the password used
    /// by DotNet.Misc.Security to encrypt and
    /// decrypt files.
    /// </summary>
    public class Password : IDisposable
    {
        public Password(string password)
        {
            Safely.Password = password;
        }

        public void Dispose()
        {
            Safely.Password = Safely.DefaultPassword;
            GC.SuppressFinalize(this);
        }
    }
}
