using UnityEngine;

public class CharacterUIView : MonoBehaviour
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Skills { get; private set; }

    public void Init(string name, string description, string skills)
    {
        Name = name;
        Description = description;
        Skills = skills;
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
