using System;
using UnityEngine;

[Serializable]
public class UISounds
{
    [field: SerializeField] private AudioClip _click;
    [field: SerializeField] private AudioClip _hover;

    public AudioClip Click => _click;
    public AudioClip Hover => _hover;
}
