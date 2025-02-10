namespace LibraryManagement.Extensions
{
    public static class IEnumerableExtension
    {

        public static bool IsExists<T>(this IEnumerable<T> enumerable, T obj)
        {
            return enumerable.Contains(obj);
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> enumerable, int size)
        {
            var len = enumerable.Count();
            var pos = 0;

            do
            {
                yield return enumerable.Skip(pos).Take(size);
                pos = pos + size;

            }while (pos < len);
        }
    }
}
