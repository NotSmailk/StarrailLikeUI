using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Sound/SoundData", fileName = "New Sound Data")]
public class SoundData : ScriptableObject
{
    [field: SerializeField] private UISounds _ui;
    [field: SerializeField] private GameSounds _game;

    public UISounds UI => _ui;
    public GameSounds Game => _game;
}

[Serializable]
public class UISounds
{
    [field: SerializeField] private AudioClip _click;
    [field: SerializeField] private AudioClip _hover;

    public AudioClip Click => _click;
    public AudioClip Hover => _hover;
}

[Serializable]
public class GameSounds
{
    [field: SerializeField] private AudioClip _changeCharacter;

    public AudioClip ChangeCharacter => _changeCharacter;
}