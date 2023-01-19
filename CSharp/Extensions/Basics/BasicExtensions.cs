public static class BasicsExtensions
{
    public static bool IsNullOrEmpty<T>(this List<T> list)
    {
        return list == null || list.Count == 0;
    }
    public static T Last<T>(this List<T> list)
    {
        if (list.IsNullOrEmpty())
        {
            throw new ArgumentException("La liste est nulle ou vide.");
        }
        return list[list.Count - 1];
    }
    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }
    public static bool IsOdd(this int number)
    {
        return number % 2 != 0;
    }
    public static string Repeat(this string str, int count)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(str);
        }
        return sb.ToString();
    }
    public static bool IsNull(this object obj)
    {
        return obj == null;
    }
    public static bool IsNumber(this string str)
    {
        double result;
        return double.TryParse(str, out result);
    }
    public static bool IsBetween(this int number, int min, int max)
    {
        return number >= min && number <= max;
    }
    public static string Substring(this string str, int startIndex, int length)
    {
        return str.Substring(startIndex, length);
    }
    public static bool IsEmail(this string str)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(str);
            return addr.Address == str;
        }
        catch
        {
            return false;
        }
    }
}