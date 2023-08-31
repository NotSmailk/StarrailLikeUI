using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string Name;
    public Sprite Avatar;
    public Player Prefab;
    public CharacterUIView UIPrefab;
    [TextArea] public string Description;
    [TextArea] public string Skills;
}
