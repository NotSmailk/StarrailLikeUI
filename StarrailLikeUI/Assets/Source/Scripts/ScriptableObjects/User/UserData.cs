using System.Collections.Generic;

[System.Serializable]
public class UserData
{
    public string username = "Default";
    public string uid = "000000000";
    public int avatarId = 0;
    public string status = "Status";
    public int level = 0;
    public int expCount = 0;
    public List<string> friendsList = new List<string>();
}
