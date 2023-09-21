using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Assignments/AssigmnetsData", fileName = "New Assignments Data")]
public class AssignmentsData : ScriptableObject
{
    [field: SerializeField] private List<Assignment> _assignments = new List<Assignment>();

    public List<Assignment> Assignments => _assignments;
}

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