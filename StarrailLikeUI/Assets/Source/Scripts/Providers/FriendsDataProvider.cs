using System.Collections.Generic;

public class FriendsDataProvider
{
    private UserData _user;
    private List<UserData> _friends;

    public List<UserData> Friends => _friends;
    
    public FriendsDataProvider(UserProvider provider)
    {
        _user = provider.User;
        _friends = new List<UserData>();

        foreach (var uid in _user.friendsList)
        {
            _friends.Add(provider.GetUserByUID(uid));
        }
    }
}
