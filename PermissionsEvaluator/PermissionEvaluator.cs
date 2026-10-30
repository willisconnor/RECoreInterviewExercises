namespace InterviewExercises.PermissionsEvaluator;

public sealed record Permission(string User, string Resource, string Action);

public sealed class PermissionEvaluator
{
    private readonly IReadOnlyCollection<Permission> _permissions;

    public PermissionEvaluator(IEnumerable<Permission> permissions)
    {
        _permissions = permissions.ToArray();
    }

    public bool IsAllowed(string user, string resource, string action)
    {
        //Check if user has required permissions FROM the _permissions collection
        //check if 1)user is in permissions. no? exit. yes? move on
        //2) resouce/table is in permissions with specified user. no? exit. yes? move on
        //3) action is in permissions WITH the specified user and resource.. no? exit. yes? return true
        //matching is case sensitive.
        if (_permissions.Any(p => p.User == user && p.Resource == resource && p.Action == action))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
