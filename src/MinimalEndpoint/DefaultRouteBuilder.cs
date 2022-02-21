using System.Text.RegularExpressions;

namespace MinimalEndpoint
{
    public static class DefaultRouteBuilder
    {
        static Regex r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])",
                 RegexOptions.IgnorePatternWhitespace);


        public static string Build(Type endpointType) =>
        r.Replace(endpointType.Name.Replace("Endpoint", ""), "-").ToLower();

    }
}