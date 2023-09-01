using UnityEngine;

[CreateAssetMenu(menuName = "Data/Store/StoreItemData", fileName = "New Store Item Data")]
public class StoreItemData : ScriptableObject
{
    [field: SerializeField] private ItemData _item;
    [field: SerializeField] private int _price;

    public ItemData Item => _item;
    public int Price => _price;
}
