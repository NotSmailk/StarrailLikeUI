using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Data/User/UsersData", fileName = "New Users Data")]
public class UsersData : ScriptableObject
{
    [field: SerializeField] private List<UserData> _data = new List<UserData>();

    public List<UserData> Data => _data;

    public UserData GetUser(string username)
    {
        foreach (var item in _data)
        {
            if (item.username.Equals(username))
                return item;
        }

        return null;
    }

    public UserData GetUserByUID(string uid)
    {
        foreach (var item in _data)
        {
            if (item.uid.Equals(uid))
                return item;
        }

        return null;
    }
}
