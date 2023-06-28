namespace FileReaderCS
{
    internal class Utils
    {

        /* Return a similar array to the one set as parameter with the objects obj1 and obj2
         * permutated
         */
        public static T[] Permutate<T>(T[] array, T obj1, T obj2)
        {
            int i = Array.IndexOf(array, obj1);
            int j = Array.IndexOf(array, obj2);
            T[] res = new List<T>(array).ToArray();
            (res[j], res[i]) = (res[i], res[j]);
            return res;
        }

    }
}
