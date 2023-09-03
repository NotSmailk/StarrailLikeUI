using UnityEngine;

public class UserProvider
{
    private UsersData _users;
    private string _username;

    public UserProvider(string username)
    {
        _username = username;
        
        _users = Resources.Load("New Users Data") as UsersData;
    }

    public UserData User => GetUser();

    public UserData GetUserByUID(string uid)
    {
        return _users.GetUserByUID(uid);
    }

    private UserData GetUser()
    {
        return _users.GetUser(_username);
    }
}
