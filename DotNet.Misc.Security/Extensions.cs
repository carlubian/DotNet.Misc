using DotNet.Misc.Security.Data;
using System;

namespace DotNet.Misc.Security
{
    public static class Extensions
    {
        /// <summary>
        /// Attempts to convert a piece of decrypted data
        /// into a class type. The destination class, if
        /// it's not System.String, should
        /// have a 'public static T Deserialize(string)' method.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Decrypted data</param>
        /// <param name="result">Class instance</param>
        /// <returns>Conversion result</returns>
        public static bool As<T>(this DecryptedData source, out T result) where T: class
        {
            // Strings don't need conversion
            if (typeof(T) == typeof(string))
            {
                result = (T)(object)source.Data;
                return true;
            }

            // Method 1: Convert.ChangeType
            try
            {
                result = (T)Convert.ChangeType(source, typeof(T));
                return true;
            }
            catch
            {
                // Method 2: Invoke static deserialization method
                try
                {
                    result = (T)typeof(T).InvokeMember("Deserialize", 
                        System.Reflection.BindingFlags.Static |
                        System.Reflection.BindingFlags.Public |
                        System.Reflection.BindingFlags.InvokeMethod, null, null, 
                        new[] { source.Data });
                    return true;
                }
                catch
                {
                    result = default;
                    return false;
                }
            }
        }

        /// <summary>
        /// Attempts to convert a piece of decrypted data
        /// into a primitive type. Note that strings are
        /// not a primitive type, and should be converted
        /// using the .As() method.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Decrypted data</param>
        /// <param name="result">Primitive type</param>
        /// <returns></returns>
        public static bool AsValue<T>(this DecryptedData source, out T result) where T: struct
        {
            // Method 1: Primitive type parsing
            if (typeof(T) == typeof(int)
                && int.TryParse(source.Data, out int resInt))
            {
                result = (T)(object)resInt;
                return true;
            }
            if (typeof(T) == typeof(short)
                && short.TryParse(source.Data, out short resSht))
            {
                result = (T)(object)resSht;
                return true;
            }
            if (typeof(T) == typeof(double)
                && double.TryParse(source.Data, out double resDbl))
            {
                result = (T)(object)resDbl;
                return true;
            }
            if (typeof(T) == typeof(float)
                && float.TryParse(source.Data, out float resFlt))
            {
                result = (T)(object)resFlt;
                return true;
            }
            if (typeof(T) == typeof(long)
                && long.TryParse(source.Data, out long resLng))
            {
                result = (T)(object)resLng;
                return true;
            }
            if (typeof(T) == typeof(bool)
                && bool.TryParse(source.Data, out bool resBln))
            {
                result = (T)(object)resBln;
                return true;
            }

            result = default;
            return false;
        }
    }
}
