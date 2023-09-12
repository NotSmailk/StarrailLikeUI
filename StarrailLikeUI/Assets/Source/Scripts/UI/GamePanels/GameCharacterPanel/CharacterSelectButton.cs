using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelectButton : AnimatedChooseButton
{
    [field: SerializeField] private Button _button;
    [field: SerializeField] private Image _icon;
    [field: SerializeField] private float enterSizeCoef = 0.1f;
    [field: SerializeField] private float clickSizeCoef = 0.15f;

    private Vector2 _defaultSize;
    private int _id;
    private bool _isSelected = false;
    private UnityEvent<int> _onClick = new UnityEvent<int>();

    public void Init(UnityAction<int> chooseCharacter, int id, Sprite icon)
    {
        _onClick.AddListener(chooseCharacter);
        _id = id;
        _icon.sprite = icon;
        _defaultSize = GetComponent<RectTransform>().sizeDelta;
    }

    public void Select()
    {
        _isSelected = true;
        foreach (RectTransform rect in transform)
        {
            var size = _defaultSize * (1 + clickSizeCoef);
            rect.DOSizeDelta(size, 0.05f);
        }
    }

    public void Deselect()
    {
        _isSelected = false;
        foreach (RectTransform rect in transform)
        {
            var size = _defaultSize * (1 + clickSizeCoef);
            rect.DOSizeDelta(_defaultSize, 0.05f);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        _onClick.Invoke(_id);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_isSelected)
            return;

        foreach (RectTransform rect in transform)
        {
            var size = rect.sizeDelta * (1 + enterSizeCoef);

            rect.DOSizeDelta(size, 0.1f);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_isSelected)
            return;

        foreach (RectTransform rect in transform)
        {
            rect.DOSizeDelta(_defaultSize, 0.1f);
        }
    }
}
