using Zenject;

public class GameInventoryPanel : VanishingGamePanel
{
    [Inject] private GameStateMachine _gameBehaviour;

    public override void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        base.Init();
    }
}
