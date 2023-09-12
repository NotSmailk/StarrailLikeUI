using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendButtonPanel : MonoBehaviour
{
    [field: SerializeField] private Image _avatarImg;
    [field: SerializeField] private TextMeshProUGUI _nickname;
    [field: SerializeField] private TextMeshProUGUI _status;
    [field: SerializeField] private TextMeshProUGUI _level;

    public void Init(UserData data, Sprite avatar)
    {
        _avatarImg.sprite = avatar;
        _nickname.text = data.username;
        _status.text = data.status;
        _level.text = $"{GameConstants.KeyWords.LEVEL_TEXT}: {data.level}";
    }
}
