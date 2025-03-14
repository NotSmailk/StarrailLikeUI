using UnityEngine;

[CreateAssetMenu(menuName = "Data/Sound/SoundData", fileName = "New Sound Data")]
public class SoundData : ScriptableObject
{
    [field: SerializeField] private UISounds _ui;
    [field: SerializeField] private GameSounds _game;

    public UISounds UI => _ui;
    public GameSounds Game => _game;
}
