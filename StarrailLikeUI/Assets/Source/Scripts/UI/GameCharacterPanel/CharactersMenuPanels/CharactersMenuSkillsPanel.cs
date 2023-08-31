using TMPro;
using UnityEngine;

public class CharactersMenuSkillsPanel : MonoBehaviour, ICharactersMenuPanel
{
    [field: SerializeField] private TextMeshProUGUI _skillsText;
 
    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }

    public void SetActiveCharacter(CharacterUIView character)
    {
        _skillsText.text = character.Skills;
    }
}
