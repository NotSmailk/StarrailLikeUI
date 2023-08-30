using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameSpinsMenuState : IGameState, IStateEnterable, IStateExitable
{
    [Inject] private GameUI _gameUI;

    public GameStateMachine Initializer { get; set; }
    public bool Entered = false;

    public GameSpinsMenuState(GameStateMachine initializer)
    {
        Initializer = initializer;
    }

    public async Task Enter()
    {
        await _gameUI.ShowPanel<GameSpinsMenuPanel>(true);
        Entered = true;
    }

    public async Task Exit()
    {
        await _gameUI.ShowPanel<GameSpinsMenuPanel>(false);
        Entered = false;
    }

    public void Run()
    {
        if (!Entered)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Initializer.SwitchToPreviousState();
        }
    }
}
