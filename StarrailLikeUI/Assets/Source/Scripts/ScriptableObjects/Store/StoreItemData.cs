using UnityEngine;

[CreateAssetMenu(menuName = "Data/Store/StoreItemData", fileName = "New Store Item Data")]
public class StoreItemData : ScriptableObject
{
    [field: SerializeField] private int _itemId;
    [field: SerializeField] private int _price;

    public int ItemId => _itemId;
    public int Price => _price;
}
