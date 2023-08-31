using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconView : MonoBehaviour
{
    [field: SerializeField] private Image _characrerIcon;
    [field: SerializeField] private TextMeshProUGUI _characterName;
    [field: SerializeField] private TextMeshProUGUI _inputHint;
    [field: SerializeField] private Image _highlight;

    private Color _activeColor = Color.cyan;
    private Color _defaultColor = Color.white;

    public void Init(CharacterData character, int id)
    {
        _characrerIcon.sprite = character.Avatar;
        _characterName.text = character.Name;
        _inputHint.text = $"{id}";
    }

    public void ActiveIcon(bool active)
    {
        var rect = _highlight.GetComponent<RectTransform>();
        var size = rect.sizeDelta;

        rect.sizeDelta = size * new Vector2(0f, 1f);
        _highlight.gameObject.SetActive(active);

        if (_highlight.gameObject.activeSelf)
        {
            DOTween.Sequence().
                Append(_highlight.DOColor(_activeColor, 0.2f)).
                Append(_highlight.DOColor(_defaultColor, 0.2f));

            rect.DOSizeDelta(size, 0.2f);
        }
        else
        {
            rect.sizeDelta = size;
        }
    }
}
