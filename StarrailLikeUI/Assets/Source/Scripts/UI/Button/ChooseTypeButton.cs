using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class ChooseTypeButton : AnimatedChooseButton
{
    [field: Header("Animation Parametres")]
    [field: SerializeField] protected Image _image;
    [field: SerializeField] protected RectTransform _rect;
    [field: SerializeField] private float _duration;
    [field: SerializeField] private float _enterSizeCoef = 0.1f;
    [field: SerializeField] private float _clickSizeCoef = 0.15f;
    [field: SerializeField] private Color _enterColor = Color.gray;
    [field: SerializeField] private Color _clickColor = Color.gray;

    protected Vector2 _defaultSize;
    protected Color _defaultColor;
    protected bool _isSelected = false;
    protected UnityEvent _onClick = new UnityEvent();
    protected bool _clicked = false;

    [Inject] private GameUI _ui;

    public virtual void Init()
    {
        _defaultSize = GetComponent<RectTransform>().sizeDelta;
        _defaultColor = _image.color;
    }

    public void Add(UnityAction action)
    {
        _onClick.AddListener(action);
    }

    public void Select()
    {
        _isSelected = true;
        var size = _defaultSize * (1 + _clickSizeCoef);
        _rect.DOSizeDelta(size, _duration);
        _image.DOColor(_clickColor, _duration);
    }

    public void Deselect()
    {
        _isSelected = false;
        _rect.DOSizeDelta(_defaultSize, _duration);
        _image.DOColor(_defaultColor, _duration);
    }

    public void DestroyButton()
    {
        Destroy(gameObject);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        _onClick.Invoke();

        if (_clicked)
        {
            _clicked = false;
        }
        else
        {
            _ui.PlayClick();
            _clicked = true;
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_isSelected)
            return;

        try
        {
            _ui.PlayHover();
            var size = _rect.sizeDelta * (1 + _enterSizeCoef);
            _rect.DOSizeDelta(size, _duration);
            _image.DOColor(_enterColor, _duration);
        } catch { }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_isSelected)
            return;

        try
        {
            _rect.DOSizeDelta(_defaultSize, _duration);
            _image.DOColor(_defaultColor, _duration);
            _clicked = false;
        } catch { }
    }
}
