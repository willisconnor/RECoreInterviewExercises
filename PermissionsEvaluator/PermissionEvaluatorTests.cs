namespace InterviewExercises.PermissionsEvaluator;

public class PermissionEvaluatorTests
{
    [Fact]
    public void IsAllowed_ReturnsTrueForAnExactPermissionMatch()
    {
        var evaluator = new PermissionEvaluator(
        [
            new Permission("alice", "reports", "read")
        ]);

        Assert.True(evaluator.IsAllowed("alice", "reports", "read"));
    }

    [Fact]
    public void IsAllowed_ReturnsFalseWhenEvaluatorHasNoPermissions()
    {
        var evaluator = new PermissionEvaluator([]);

        Assert.False(evaluator.IsAllowed("alice", "reports", "read"));
    }

    [Fact]
    public void IsAllowed_ReturnsTrueWhenOneOfSeveralPermissionsMatches()
    {
        var evaluator = new PermissionEvaluator(
        [
            new Permission("alice", "reports", "write"),
            new Permission("alice", "reports", "read"), //matches with previous
            new Permission("bob", "reports", "read"),
            new Permission("alice", "users", "read")
        ]);

        Assert.True(evaluator.IsAllowed("alice", "users", "read"));
    }
    [Theory]
    [InlineData("bob", "reports", "read")]
    [InlineData("alice", "reports", "write")]
    [InlineData("alice", "users", "read")]
    //My test cases:
    [InlineData("alice", "users", "")]
    [InlineData("alice", "", "read")]
    [InlineData("", "users", "read")]
    [InlineData("", "", "")]
    [InlineData("Alice", "reports", "read")]
    [InlineData("alice ", "reports", "read")]
    //next three should be false - but each have one "true" field, but not all 3 are true
    [InlineData("alice", "users", "write")]
    [InlineData("bob", "reports", "write")]
    [InlineData("bob", "users", "read")]
    public void IsAllowed_ReturnsFalseWhenNoExactPermissionMatches(
        string user, string resource, string action)
    {
        var evaluator = new PermissionEvaluator(
        [
            new Permission("alice", "reports", "read")
        ]);

        Assert.False(evaluator.IsAllowed(user, resource, action));
    }

    
}
