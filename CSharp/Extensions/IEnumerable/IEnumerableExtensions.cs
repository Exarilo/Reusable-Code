public static class IEnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0 ? new[] { new T[0] } :
          elements.SelectMany((e, i) =>
            elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
    }
    private static IEnumerable<int> ClosestLowerSum(this IEnumerable<int> elements, int n)
    {
        var combinations = elements.Combinations(2);
        var closest = combinations
            .Where(c => c.Sum() <= n)
            .OrderBy(c => Math.Abs(c.Sum() - n))
            .FirstOrDefault();
        return closest ?? new int[] { };
    }
    public static T Random<T>(this IEnumerable<T> enumerable)
    {
        var random = new Random();
        var list = enumerable.ToList();
        return list[random.Next(0, list.Count)];
    }
    public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> enumerable, int size)
    {
        var random = new Random();
        var list = enumerable.OrderBy(x => random.Next()).Take(size);
        return list;
    }
    public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
    {
        return enumerable.ToDictionary(keySelector, valueSelector);
    }
    public static T MostFrequent<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.GroupBy(x => x)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .First();
    }
    public static Tuple<T, T> MinMax<T>(this IEnumerable<T> enumerable)
    {
        return Tuple.Create(enumerable.Min(), enumerable.Max());
    }
    public static IEnumerable<IEnumerable<T>> GetSubsets<T>(this IEnumerable<T> enumerable)
    {
        var list = enumerable.ToList();
        var result = new List<IEnumerable<T>>();
        for (int i = 0; i <= list.Count; i++)
        {
            result.AddRange(list.Subsets(i));
        }
        return result;
    }
    public static IEnumerable<int> GetDivisors(this int n)
    {
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                yield return i;
            }
        }
    }
}
