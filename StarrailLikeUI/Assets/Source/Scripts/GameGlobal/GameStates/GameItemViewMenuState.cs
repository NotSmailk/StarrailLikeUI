using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameItemViewMenuState : IGameState, IStateEnterable, IStateExitable
{
    [Inject] private GameUI _gameUI;

    public GameStateMachine Initializer { get; set; }
    public bool Entered = false;

    public GameItemViewMenuState(GameStateMachine initializer)
    {
        Initializer = initializer;
    }

    public async Task Enter()
    {
        await _gameUI.ShowPanel<GameItemViewPanel>(true);
        Entered = true;
    }

    public async Task Exit()
    {
        Entered = false;
        await _gameUI.ShowPanel<GameItemViewPanel>(false);
    }

    public void Run()
    {
        if (!Entered)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Initializer.SwitchToPreviousWithoutEnter();
        }
    }
}
