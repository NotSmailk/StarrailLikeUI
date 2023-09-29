using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class CharacterSelectButton : AnimatedChooseButton
{
    [field: SerializeField] private RectTransform _rect;
    [field: SerializeField] private Image _icon;
    [field: SerializeField] private float enterSizeCoef = 0.1f;
    [field: SerializeField] private float clickSizeCoef = 0.15f;

    private Vector2 _defaultSize;
    private int _id;
    private bool _isSelected = false;
    private UnityEvent<int> _onClick = new UnityEvent<int>();

    [Inject] GameUI _ui;

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
        var size = _defaultSize * (1 + clickSizeCoef);
        _rect.DOSizeDelta(size, 0.05f);
    }

    public void Deselect()
    {
        _isSelected = false;
        _rect.DOSizeDelta(_defaultSize, 0.05f);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_isSelected)
            return;

        _ui.PlayHover();
        var size = _rect.sizeDelta * (1 + enterSizeCoef);
        _rect.DOSizeDelta(size, 0.1f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_isSelected)
            return;

        _rect.DOSizeDelta(_defaultSize, 0.1f);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        _onClick.Invoke(_id);
        _ui.PlayClick();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        OnPointerExit(eventData);
    }
}
