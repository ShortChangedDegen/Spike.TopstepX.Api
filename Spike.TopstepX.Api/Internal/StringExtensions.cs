using System;

namespace Spike.TopstepX.Api.Common
{
    /// <summary>
    /// String extension methods.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts a string to camel case by making the first character lowercase.
        /// </summary>
        /// <param name="value">The string to convery to camelCase.</param>
        /// <returns>The new string.</returns>
        public static string ToCamelCase(this string value) =>
            (string.IsNullOrEmpty(value) || value.Length < 2)
                ? value
                : char.ToLowerInvariant(value[0]) + value.Substring(1);
        

        /// <summary>
        /// Converts a string to pascal case by making the first character uppercase.
        /// </summary>
        /// <param name="value">The string to convery to PascalCase.</param>
        /// <returns>The new string.</returns>
        public static string ToPascalCase(this string value) =>        
            (string.IsNullOrEmpty(value) || value.Length < 2)
                ? value
                : char.ToUpperInvariant(value[0]) + value.Substring(1);
    }
}
