using UnityEngine;

public class Phone : MonoBehaviour
{
    [field: SerializeField] private GameObject _phone;

    public void ShowPhone(bool show)
    {
        _phone.SetActive(show);
    }
}
