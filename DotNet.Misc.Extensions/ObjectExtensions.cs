namespace DotNet.Misc.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Provides a correct implementation of GetHashCode that
    /// takes into account the specified properties of an object.
    /// </summary>
    /// <param name="_">Extension hook</param>
    /// <param name="Properties">Equatable properties</param>
    /// <returns></returns>
    public static int GetHashCode(this object _, params object[] Properties)
    {
        const int offset = unchecked((int)2166136261);
        const int prime = 16777619;

        int HashCodeAggregator(int hashCode, object value)
        {
            return value == null
                ? (hashCode ^ 0) * prime
                : (hashCode ^ value.GetHashCode()) * prime;
        }

        return Properties.Aggregate(offset, HashCodeAggregator);
    }
}
