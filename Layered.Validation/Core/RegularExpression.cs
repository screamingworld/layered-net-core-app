using System.Text.RegularExpressions;

namespace Layered.Common.Core
{
    public static class RegularExpression
    {
        public static readonly Regex OnlyDigits = new Regex(@"^\d+$");
    }
}
