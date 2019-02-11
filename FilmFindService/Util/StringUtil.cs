namespace FilmFindService.Util
{
    public static class String
    {
        public const double SimilarityCoefficient = 0.5;

        public static bool PartialCompare(this string left, string right)
        {
            if (string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right))
            {
                return false;
            }

            int minLen = left.Length > right.Length ? right.Length : left.Length;

            int similarity = 0;
            for (int i = 0; i < minLen; ++i)
            {
                if (left[i] == right[i])
                {
                    ++similarity;
                }
            }

            bool similary = ((double)similarity / minLen) >= SimilarityCoefficient;
            return similary;
        }
    }
}
