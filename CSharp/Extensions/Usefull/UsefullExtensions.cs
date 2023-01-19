public static class BasicsExtensions
{
    public static bool IsUrl(this string str)
    {
        Uri uriResult;
        return Uri.TryCreate(str, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}