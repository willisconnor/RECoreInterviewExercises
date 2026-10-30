namespace InterviewExercises.PalindromeChecker;

public static class PalindromeChecker
{
    public static bool IsPalindrome(string value)
    {
        //check for null before any else is executed
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        //if not null, go on to all other cases with a 2 index approach
        int len = value.Length;
        int i = 0, j = len - 1;
        //this checks for exact match -  we need to ignore non digits
        while (i < j)
        {
            //first 2 if statements check for non alphanumeric characters
            //and either increment or decrement the index accordingly
            if (char.IsLetterOrDigit(value[i]) == false)
            {
                i++;
                continue;
            }
            if (char.IsLetterOrDigit(value[j]) == false)
            {
                j--;
                continue;
            }
            if (char.ToLower(value[i]) != char.ToLower(value[j]))
            {
                return false;
            }
            i++;
            j--;
        }
        //throw new NotImplementedException();
        return true;
    }
}
