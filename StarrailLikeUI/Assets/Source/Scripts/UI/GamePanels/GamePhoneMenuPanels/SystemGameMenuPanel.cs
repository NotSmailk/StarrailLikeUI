using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SystemGameMenuPanel : MonoBehaviour
{
    [field: SerializeField] private Button _closeMenuBtn;
    [field: SerializeField] private Button _exitGameBtn;

    [Inject] private GameStateMachine _gameBehaviour;

    public void Init()
    {
        _closeMenuBtn.onClick.AddListener(_gameBehaviour.SwitchState<GameWorldState>);
        _exitGameBtn.onClick.AddListener(Application.Quit); // TODO
    }
}
