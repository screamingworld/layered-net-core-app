using System.Collections.Generic;
using System.Linq;

namespace Layered.Common.Core
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Gets the given name in camel case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The given name in camel case.</returns>
        internal static string ToCamelCase(this string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            if (!char.IsUpper(name[0]))
                return name;

            var chars = name.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if ((0 < i) && HasNotUpperCharacter(i + 1, chars))
                    break;
                chars[i] = char.ToLowerInvariant(chars[i]);
            }
            return new string(chars);
        }

        /// <summary>
        /// Gets the given name path in camel case.
        /// </summary>
        /// <param name="path">The name path.</param>
        /// <returns>The given name path in camel case.</returns>
        public static string ToDottedCamelCase(this string path)
        {
            return string.IsNullOrEmpty(path) ? path : string.Join(".", path.Split('.').Select(ToCamelCase));
        }

        private static bool HasNotUpperCharacter(int i, IReadOnlyList<char> chars) => (i < chars.Count) && !char.IsUpper(chars[i]);
    }
}
