namespace FilmFindService.Util
{
    public static class String
    {
        public static bool PartialCompare(this string left, string right, uint firstLetter)
        {
            if (string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right))
            {
                return false;
            }

            int minLen = left.Length > right.Length ? right.Length : left.Length;

            if (minLen < firstLetter)
            {
                return false;
            }

            int similarity = 0;
            for (int i = 0; i < firstLetter; ++i)
            {
                if (char.ToLower(left[i]) == char.ToLower(right[i]))
                {
                    ++similarity;
                }
            }

            return (similarity >= firstLetter);
        }
    }
}
