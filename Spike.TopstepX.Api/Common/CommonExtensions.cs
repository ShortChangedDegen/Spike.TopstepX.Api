using System;

namespace Spike.TopstepX.Api.Common
{
    /// <summary>
    /// Common extension methods.
    /// </summary>
    /// <remarks>
    /// This will be refactored if there are enough extensions
    /// to categorize them toether (eg, StringExtensions).
    /// </remarks>
    internal static class CommonExtensions
    {
        /// <summary>
        /// Converts a string to camel case by making the first character lowercase.
        /// </summary>
        /// <param name="value">The string to convery to camelCase.</param>
        /// <returns>The new string.</returns>
        public static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2)
                return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// Converts a string to pascal case by making the first character uppercase.
        /// </summary>
        /// <param name="value">The string to convery to PascalCase.</param>
        /// <returns>The new string.</returns>
        public static string ToPascalCase(this string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2)
                return value;
            return char.ToUpperInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// Guards a value against null and a predicate. This should 
        /// not be used unless there are no better guard options.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="param">The parameter value.</param>
        /// <param name="predicate">The test that <paramref name="param"/> must pass.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The error message.</param>
        /// <returns>The <paramref name="param"/> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="param"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="param"/> fails the <paramref name="predicate"/>.</exception>
        public static T Guard<T>(this T? param, Func<T, bool> predicate, string paramName, string message)
        {

#pragma warning disable CS8604 // Possible null reference argument.
            // In this case, we may not case if a ref or nullable is null.
            if (!predicate(param))
            {
                throw new ArgumentException(paramName, message);
            }
#pragma warning restore CS8604 // Possible null reference argument.

            return param;
        }

        /// <summary>
        /// Guards a value against null. This should not be used unless there are no better guard options.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="param">The parameter value.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <returns>The <paramref name="param"/> value.</returns>
        public static T GuardNotNull<T>(this T? param, string paramName)
        {
            if(param is null)
            {
                throw new ArgumentNullException(paramName, "The provided parameter cannot be null.");
            }
            return param;
        }

        /// <summary>
        /// Guards a string against null or empty values.
        /// </summary>
        /// <param name="param">The parameter value.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <returns>The <paramref name="param"/> value.</returns>
        public static string GuardNotNullOrEmpty(this string? param, string paramName) =>
            Guard(
                GuardNotNull(param, paramName),
                v => !string.IsNullOrEmpty(v),
                paramName,
                $"{paramName} cannot be empty."
            );

        
    }
}
