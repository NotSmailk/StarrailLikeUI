using System.Collections.Generic;

public static class InventoryInfoExtension
{
    public static bool Contains(this List<InventoryInfo> info, int id)
    {
        foreach (var item in info)
        {
            if (item.ItemId.Equals(id))
                return true;
        }

        return false;
    }

    public static int GetQuantity(this List<InventoryInfo> info, int id)
    {
        foreach (var item in info)
        {
            if (item.ItemId.Equals(id))
                return item.Quantity;
        }

        return 0;
    }

    public static void AddItem(this List<InventoryInfo> info, int id, int quantity)
    {
        foreach (var item in info)
        {
            if (item.ItemId.Equals(id))
            {
                item.Quantity += quantity;
                return;
            }
        }

        info.Add(new InventoryInfo(id, quantity));
    }
}
