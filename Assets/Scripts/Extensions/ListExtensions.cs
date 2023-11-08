using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtensions
    {
        public static bool TryRemoveByIndex<T>(this List<T> list, int index)
        {
            try
            {
                list.RemoveAt(index);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
