using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Items/Item Collection", fileName = "New Item Collection")]
public class ItemDataCollection : ScriptableObject
{
    public List<ItemData> _items = new List<ItemData>();

    public List<ItemData> Items => _items;
}
