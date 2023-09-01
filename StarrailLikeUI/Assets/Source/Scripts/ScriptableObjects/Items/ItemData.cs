using UnityEngine;

[CreateAssetMenu(menuName = "Data/Items/ItemData", fileName = "New Item Data")]
public class ItemData : ScriptableObject
{
    [field: SerializeField] private string _name;
    [field: SerializeField] private Sprite _sprite;
    [field: SerializeField] private string _description;

    public string Name => _name;
    public Sprite Sprite => _sprite;
    public string Description => _description;
}
