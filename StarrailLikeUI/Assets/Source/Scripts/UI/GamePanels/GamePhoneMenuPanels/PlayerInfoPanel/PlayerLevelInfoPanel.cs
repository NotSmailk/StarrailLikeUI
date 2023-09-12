using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerLevelInfoPanel : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI _levelText;
    [field: SerializeField] private TextMeshProUGUI _expText;
    [field: SerializeField] private Slider _levelSlider;

    [Inject] private LevelsData _levelsData;
    [Inject] private UserProvider _userProvider;

    public void ShowPanel()
    {
        var maxExp = 0;
        foreach (var item in _levelsData.Data)
        {
            if (_userProvider.User.level + 1 == item.level)
                maxExp = item.exp;
        }

        _levelText.text = $"{GameConstants.KeyWords.LEVEL_TEXT}: {_userProvider.User.level}";
        _expText.text = $"{GameConstants.KeyWords.EXP_TEXT}: {_userProvider.User.expCount}/{maxExp}";
        _levelSlider.value = _userProvider.User.expCount / (float)maxExp;
    }
}
