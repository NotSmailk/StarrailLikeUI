using System;

[Serializable]
public class InventoryInfo
{
    public int ItemId;
    public int Quantity;

    public InventoryInfo(int id, int quantity)
    {
        ItemId = id;
        Quantity = quantity;
    }
}
