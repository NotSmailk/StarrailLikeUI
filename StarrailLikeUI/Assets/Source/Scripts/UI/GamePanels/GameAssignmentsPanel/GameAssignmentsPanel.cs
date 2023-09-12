using Zenject;

public class GameAssignmentsPanel : VanishingGamePanel
{
    [Inject] private GameStateMachine _gameBehaviour;

    public override void Init()
    {
        base.Init();
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
    }
}
