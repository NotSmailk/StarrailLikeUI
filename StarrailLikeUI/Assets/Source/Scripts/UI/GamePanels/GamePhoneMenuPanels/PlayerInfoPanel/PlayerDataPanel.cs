using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerDataPanel : MonoBehaviour
{
    [field: SerializeField] private Image _avatar;
    [field: SerializeField] private TextMeshProUGUI _usernameText;
    [field: SerializeField] private TextMeshProUGUI _levelText;
    [field: SerializeField] private TextMeshProUGUI _statusText;
    [field: SerializeField] private TextMeshProUGUI _uidText;

    [Inject] private UserProvider _userProvider;
    [Inject] private AvatarsData _avatarsData;

    public void ShowPanel()
    {
        _levelText.text = $"{GameConstants.KeyWords.LEVEL_TEXT}: {_userProvider.User.level}";
        _avatar.sprite = _avatarsData.GetAvatar(_userProvider.User.avatarId);
        _usernameText.text = _userProvider.User.username;
        _statusText.text = _userProvider.User.status;
        _uidText.text = $"{GameConstants.KeyWords.UID_TEXT}: {_userProvider.User.uid}";
    }
}
