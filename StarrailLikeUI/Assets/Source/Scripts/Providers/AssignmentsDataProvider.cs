using UnityEngine;

public class AssignmentsDataProvider
{
    private AssignmentsData _assignmentsData;

    public AssignmentsDataProvider()
    {
        _assignmentsData = Resources.Load<AssignmentsData>(GameConstants.Paths.ASSIGNMENTS_DATA_PATH);
    }

    public AssignmentsData Data => _assignmentsData;
}
