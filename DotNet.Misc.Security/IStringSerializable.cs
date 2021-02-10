using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Misc.Security
{
    /// <summary>
    /// Indicates that this class can be converted to
    /// and from a string.
    /// Note that the class should also have a 
    /// 'public static <typeparamref name="T"/> Deserialize(string)' method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStringSerializable<T>
    {
        string Serialize();

        //public static T Deserialize(string v);
    }
}
