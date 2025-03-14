using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Assignments/AssigmnetsData", fileName = "New Assignments Data")]
public class AssignmentsData : ScriptableObject
{
    [field: SerializeField] private List<Assignment> _assignments = new List<Assignment>();

    public List<Assignment> Assignments => _assignments;
}
