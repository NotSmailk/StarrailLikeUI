using TMPro;
using UnityEngine;

public class CharactersMenuInfoPanel : MonoBehaviour, ICharactersMenuPanel
{
    [field: SerializeField] private TextMeshProUGUI _characterNameText;
    [field: SerializeField] private TextMeshProUGUI _characterDescriptionText;

    public void SetActiveCharacter(CharacterUIView character)
    {
        _characterNameText.text = character.Name;
        _characterDescriptionText.text = character.Description;
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
