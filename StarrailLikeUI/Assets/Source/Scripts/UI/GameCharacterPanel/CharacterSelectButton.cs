using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [field: SerializeField] private Button _button;
    [field: SerializeField] private Image _icon;
    [field: SerializeField] private float enterSizeCoef = 0.1f;
    [field: SerializeField] private float clickSizeCoef = 0.15f;

    private Vector2 _defaultSize;

    public void Init(UnityEngine.Events.UnityAction<int> chooseCharacter, int id, Sprite icon)
    {
        _button.onClick.AddListener(() => { chooseCharacter.Invoke(id); });
        _icon.sprite = icon;
        _defaultSize = GetComponent<RectTransform>().sizeDelta;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (RectTransform rect in transform)
        {
            var size = _defaultSize * (1 + clickSizeCoef);

            DOTween.Sequence().
                        Append(rect.DOSizeDelta(size, 0.05f)).
                        Append(rect.DOSizeDelta(_defaultSize, 0.05f));
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (RectTransform rect in transform)
        {
            var size = rect.sizeDelta * (1 + enterSizeCoef);

            rect.DOSizeDelta(size, 0.1f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (RectTransform rect in transform)
        {
            rect.DOSizeDelta(_defaultSize, 0.1f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (RectTransform rect in transform)
        {
            var size = _defaultSize * (1 + clickSizeCoef);

            rect.DOSizeDelta(size, 0.05f);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerExit(eventData);
    }
}
