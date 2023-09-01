using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Store/StoreData", fileName = "New Store Data")]
public class StoreData : ScriptableObject
{
    [field: SerializeField] private List<SlotData> _items = new List<SlotData>();

    public List<SlotData> Items => _items;
}

[Serializable]
public class SlotData
{
    public StoreItemData slot;
    public int quantity;
}
