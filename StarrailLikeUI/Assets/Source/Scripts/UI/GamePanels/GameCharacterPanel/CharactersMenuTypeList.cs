using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharactersMenuTypeList : ChooseTypeListPanel
{
    [field: SerializeField] private ChooseTypeButton _characterInfoBtn;
    [field: SerializeField] private ChooseTypeButton _characterSkillsBtn;

    public void Init()
    {
        _buttons.Add(_characterInfoBtn);
        _buttons.Add(_characterSkillsBtn);

        _characterInfoBtn.Init();
        _characterSkillsBtn.Init();

        _characterInfoBtn.Add(() => { ChooseButton(_characterInfoBtn); });
        _characterSkillsBtn.Add(() => { ChooseButton(_characterSkillsBtn); });

        ChooseButton(_characterInfoBtn);
    }

    public void AddCharacterInfo(UnityAction action)
    {
        _characterInfoBtn.Add(action);
    }
    
    public void AddCharacterSkills(UnityAction action)
    {
        _characterSkillsBtn.Add(action);
    }
}
