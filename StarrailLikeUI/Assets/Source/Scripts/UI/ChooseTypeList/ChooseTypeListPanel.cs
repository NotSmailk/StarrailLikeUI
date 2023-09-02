using System.Collections.Generic;
using UnityEngine;

public class ChooseTypeListPanel : MonoBehaviour, IChooseTypeList
{
    protected List<ChooseTypeButton> _buttons = new List<ChooseTypeButton>();
    protected ChooseTypeButton _selected;

    public virtual void ChooseButton(ChooseTypeButton button)
    {
        if (_selected == button)
            return;

        _selected?.Deselect();
        _selected = button;
        _selected.Select();
    }
}