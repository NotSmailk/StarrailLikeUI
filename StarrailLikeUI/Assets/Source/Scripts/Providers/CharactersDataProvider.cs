using UnityEngine;

public class CharactersDataProvider
{
    private CharactersData _characters;

    public CharacterData GetCharacter(int id)
    {
        if (_characters == null)
            _characters = Resources.Load("New Characters Data") as CharactersData;

        return _characters.GetCharacter(id);
    }
}
