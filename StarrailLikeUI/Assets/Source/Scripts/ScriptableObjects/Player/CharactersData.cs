using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Data/Player/Charactesr", fileName = "New Characters Data")]
public class CharactersData : ScriptableObject
{
    [field: SerializeField] private List<CharacterData> _characters = new List<CharacterData>();

    public CharacterData GetCharacter(int id)
    {
        if (id < 0 || id >= _characters.Count)
            return null;

        return _characters[id];
    }
}
