namespace FilmFindService.Util
{
    public static class String
    {
        public static bool PartialCompare(this string left, string right)
        {
            if (string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right))
            {
                return false;
            }
          
            return !(left.ToLower().IndexOf(right.ToLower()) == -1);
        }
    }
}
