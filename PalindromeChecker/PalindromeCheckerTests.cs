namespace InterviewExercises.PalindromeChecker;

public class PalindromeCheckerTests
{
    [Theory]
    [InlineData("racecar")]
    [InlineData("Racecar")]
    [InlineData("A man, a plan, a canal: Panama!")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("a")]
    //Test cases added below
    [InlineData("aba")]
    [InlineData("abba")]
    [InlineData("12321")]
    [InlineData("!aba")]
    [InlineData("!!")]
    public void IsPalindrome_ReturnsTrueForPalindromes(string value)
    {
        Assert.True(PalindromeChecker.IsPalindrome(value));
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("racecars")]
    [InlineData("A man, a plan, a canal: California!")]
    [InlineData("ab")]
    //Test Cases added below
    [InlineData("1234")]
    [InlineData("abcda")]
    [InlineData("abca")]
    public void IsPalindrome_ReturnsFalseForNonPalindromes(string value)
    {
        Assert.False(PalindromeChecker.IsPalindrome(value));
    }

    [Fact]
    public void IsPalindrome_ThrowsForNull()
    {
        Assert.Throws<ArgumentNullException>(() => PalindromeChecker.IsPalindrome(null!));
    }
}
