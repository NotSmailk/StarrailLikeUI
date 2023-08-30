using UnityEngine;

public class UserProvider
{
    private UsersData _users;
    private string _username;

    public UserProvider(string username)
    {
        _username = username;
    }

    public UserData User => GetUser();

    private UserData GetUser()
    {
        if (_users == null)
            _users = Resources.Load("New Users Data") as UsersData;

        return _users.GetUser(_username);
    }
}
