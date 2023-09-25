using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewButton : AnimatedButtonBorders
{
    [field: Header("Item View Parametres")]
    [field: SerializeField] private Image _spriteImage;
    [field: SerializeField] private TextMeshProUGUI _nameText;

    public void Init(Sprite sprite, string name)
    {
        _spriteImage.sprite = sprite;
        _nameText.text = name;
    }
}
