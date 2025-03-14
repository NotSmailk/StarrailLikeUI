using UnityEngine;

[System.Serializable]
public class Assignment
{
    [field: SerializeField] private string _name;
    [field: SerializeField, TextArea] private string _description;
    [field: SerializeField] private int _itemId;

    public string Name => _name;
    public string Description => _description;
    public int ItemId => _itemId;
}