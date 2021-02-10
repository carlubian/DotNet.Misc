using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Misc.Extensions.Linq
{
    public static class Extensions
    {
        /// <summary>
        /// Executes an action for each element
        /// in the sequence.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Sequence</param>
        /// <param name="f">Action</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> f)
        {
            if (source is null || f is null)
                return;

            foreach (var x in source)
                f(x);
        }

        /// <summary>
        /// Executes an action for each element in the
        /// sequence, without consuming them. Note that
        /// Peek is not a terminal operation.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Sequence</param>
        /// <param name="f">Action</param>
        /// <returns>Sequence</returns>
        public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> f)
        {
            if (source is null || f is null)
                f = n => { };

            foreach (var x in source)
            {
                f(x);
                yield return x;
            }
        }

        /// <summary>
        /// Generates an infinite sequence from a
        /// starting seed and a generator function.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="seed">Seed element</param>
        /// <param name="generator">Generator function</param>
        /// <returns>Sequence</returns>
        public static IEnumerable<T> Generate<T>(this T seed, Func<T, T> generator)
        {
            if (generator is null)
                yield break;

            yield return seed;

            while (true)
                yield return seed = generator(seed);
        }

        /// <summary>
        /// Converts this object into a sequence
        /// with a single element.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="origin">Starting element</param>
        /// <returns>Sequence</returns>
        public static IEnumerable<T> Enumerate<T>(this T origin)
        {
            yield return origin;
        }

        /// <summary>
        /// Converts a sequence into a string using the supplied
        /// function, and an optional separator string.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Sequence</param>
        /// <param name="function">Element to string converter</param>
        /// <param name="separator">Separator string</param>
        /// <returns>string</returns>
        public static string Stringify<T>(this IEnumerable<T> source, Func<T, string> function = null, string separator = "")
        {
            if (function is null)
                if (typeof(T).Equals(typeof(string)))
                    function = e => e as string;
                else
                    function = e => e.ToString();
            if (source is null)
                return string.Empty;
            if (separator is null)
                separator = string.Empty;

            var str = source.Select(e => function(e))
                .Aggregate("", (result, elem) => $"{result}{separator}{elem}");
            str = str.Remove(0, separator.Length);

            return str;
        }

        /// <summary>
        /// Returns a random element contained inside
        /// the source sequence.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T Random<T>(this IEnumerable<T> source)
        {
            if (source is null)
                return default;

            var rnd = new Random();
            return source.ElementAtOrDefault(rnd.Next(0, source.Count()));
        }

        /// <summary>
        /// Returns the second element inside
        /// the source sequence.
        /// </summary>
        /// <typeparam name="T">Typoe</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T Second<T>(this IEnumerable<T> source)
        {
            return source.Skip(1).First();
        }

        /// <summary>
        /// Returns the second element inside the
        /// source sequence, or a default value.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T SecondOrDefault<T>(this IEnumerable<T> source)
        {
            return source.Skip(1).FirstOrDefault();
        }

        /// <summary>
        /// Returns the third element inside
        /// the source sequence.
        /// </summary>
        /// <typeparam name="T">Typoe</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T Third<T>(this IEnumerable<T> source)
        {
            return source.Skip(1).Second();
        }

        /// <summary>
        /// Returns the third element inside the
        /// source sequence, or a default value.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T ThirdOrDefault<T>(this IEnumerable<T> source)
        {
            return source.Skip(1).SecondOrDefault();
        }

        /// <summary>
        /// Returns the fourth element inside
        /// the source sequence.
        /// </summary>
        /// <typeparam name="T">Typoe</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T Fourth<T>(this IEnumerable<T> source)
        {
            return source.Skip(1).Third();
        }

        /// <summary>
        /// Returns the fourth element inside the
        /// source sequence, or a default value.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T FourthOrDefault<T>(this IEnumerable<T> source)
        {
            return source.Skip(1).ThirdOrDefault();
        }

        /// <summary>
        /// Returns the fifth element inside
        /// the source sequence.
        /// </summary>
        /// <typeparam name="T">Typoe</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T Fifth<T>(this IEnumerable<T> source)
        {
            return source.Skip(1).Fourth();
        }

        /// <summary>
        /// Returns the fifth element inside the
        /// source sequence, or a default value.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Sequence</param>
        /// <returns>Element</returns>
        public static T FifthOrDefault<T>(this IEnumerable<T> source)
        {
            return source.Skip(1).FourthOrDefault();
        }
    }
}
