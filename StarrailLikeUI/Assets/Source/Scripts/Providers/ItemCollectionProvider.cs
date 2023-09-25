using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionProvider
{
    private ItemDataCollection _collection;
    public int ItemToBuyId { get; set; }
    public int ItemToBuyPrice { get; set; }
    public int ItemToShowId { get; set; }
    public List<int> ItemsToGet { get; set; }

    public ItemCollectionProvider()
    {
        ItemsToGet = new List<int>();
        _collection = Resources.Load<ItemDataCollection>(GameConstants.Paths.ITEM_COLLECTION_PATH);
    }

    public ItemData GetItem(int id)
    {
        if (id < 0 || id >= _collection.Items.Count)
            throw new System.Exception($"There is no item with id: {id}");

        return _collection.Items[id];
    }
}
