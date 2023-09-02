using UnityEngine;

[CreateAssetMenu(menuName = "Data/Spin/SpinData", fileName = "New Spin Data")]
public class SpinData : ScriptableObject
{
    [field: SerializeField] private string _name;
    [field: SerializeField] private string _shortName;
    [field: SerializeField, TextArea] private string _description;
    [field: SerializeField] private Sprite _sprite;

    public string Name => _name;
    public string ShortName => _shortName;
    public string Description => _description;
    public Sprite Sprite => _sprite;
}
