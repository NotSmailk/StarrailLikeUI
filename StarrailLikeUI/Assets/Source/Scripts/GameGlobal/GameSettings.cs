using System;
using UnityEngine;

[Serializable]
public class GameSettings
{
    [field: SerializeField] private float _volume;

    public float Volume => _volume;
}
