using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimatedButtonBorders : AnimatedButton
{
    [field: Header("Border Parametres")]
    [field: SerializeField] private RectTransform _rect;
    [field: SerializeField] private Image _image;

    private void Awake()
    {
        defaultSize = _rect.sizeDelta;
        defaultColor = _image.color;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _image.maskable = false;
        var size = _rect.sizeDelta * (1 + enterSizeCoef);
        _ui.PlayHover();

        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                _rect.DOSizeDelta(size, 0.1f);
                break;
            case AnimatedButtonType.Color:
                _image.DOColor(enterColor, 0.1f);
                break;
            case AnimatedButtonType.ColorAndSize:
                _rect.DOSizeDelta(size, 0.1f);
                _image.DOColor(enterColor, 0.1f);
                break;
        }
    }

    public override async void OnPointerExit(PointerEventData eventData)
    {
        try
        {
            switch (_buttonType)
            {
                case AnimatedButtonType.Size:
                    _rect.DOSizeDelta(defaultSize, 0.1f);
                    break;
                case AnimatedButtonType.Color:
                    _image.DOColor(defaultColor, 0.1f);
                    break;
                case AnimatedButtonType.ColorAndSize:
                    _rect.DOSizeDelta(defaultSize, 0.1f);
                    _image.DOColor(defaultColor, 0.1f);
                    break;
            }
            await Task.Delay(100);

            _image.maskable = true;
        } 
        catch { }
    }

    public async override void OnPointerDown(PointerEventData eventData)
    {
        try
        {
            _image.maskable = false;
            var size = defaultSize * (1 + clickSizeCoef);
            _onClick.Invoke();
            _ui.PlayClick();

            switch (_buttonType)
            {
                case AnimatedButtonType.Size:
                    _rect.DOSizeDelta(size, 0.1f);
                    break;
                case AnimatedButtonType.Color:
                    _image.DOColor(clickColor, 0.1f);
                    break;
                case AnimatedButtonType.ColorAndSize:
                    _rect.DOSizeDelta(size, 0.1f);
                    _image.DOColor(clickColor, 0.1f);
                    break;
            }

            await Task.Delay(100);
            _image.maskable = true;
        }
        catch { }
    }
}
