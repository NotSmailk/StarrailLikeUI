using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FriendsListPanel : MonoBehaviour
{
    [field: SerializeField] private FriendButtonPanel _friendPrefab;
    [field: SerializeField] private RectTransform _rect;

    [Inject] private AvatarsData _avatars;
    [Inject] private FriendsDataProvider _provider;

    private List<FriendButtonPanel> _friends = new List<FriendButtonPanel>();

    public void ShowList()
    {
        foreach (var friend in _provider.Friends)
        {
            var btn = Instantiate(_friendPrefab, _rect);
            btn.Init(friend, _avatars.GetAvatar(friend.avatarId));
            _friends.Add(btn);
        }
    }

    public void HideList()
    {
        foreach (var friend in _friends)
        {
            Destroy(friend.gameObject);
        }

        _friends.Clear();
    }
}
