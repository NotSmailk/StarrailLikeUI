using System;
using UnityEngine;

[Serializable]
public class GameSounds
{
    [field: SerializeField] private AudioClip _changeCharacter;
    [field: SerializeField] private AudioClip _getNewItem;

    public AudioClip ChangeCharacter => _changeCharacter;
    public AudioClip GetNewItem => _getNewItem;
}