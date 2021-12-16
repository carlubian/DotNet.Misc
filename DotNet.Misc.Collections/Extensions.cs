namespace System.Collections.Generic;

public static class Extensions
{
    public static bool ContainsValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TValue value)
    {
        return source.Values.Contains(value);
    }
}
