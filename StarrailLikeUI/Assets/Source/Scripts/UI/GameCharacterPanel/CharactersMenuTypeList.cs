using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharactersMenuTypeList : MonoBehaviour
{
    [field: SerializeField] private Button _characterInfoBtn;
    [field: SerializeField] private Button _characterSkillsBtn;

    public void AddCharacterInfo(UnityAction action)
    {
        _characterInfoBtn.onClick.AddListener(action);
    }
    
    public void AddCharacterSkills(UnityAction action)
    {
        _characterSkillsBtn.onClick.AddListener(action);
    }
}
