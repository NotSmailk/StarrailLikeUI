using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameStoreMenuState : IGameState, IStateEnterable, IStateExitable
{
    [Inject] private GameUI _gameUI;

    public GameStateMachine Initializer { get; set; }
    public bool Entered = false;

    public GameStoreMenuState(GameStateMachine initializer)
    {
        Initializer = initializer;
    }

    public async Task Enter()
    {
        await _gameUI.ShowPanel<GameStorePanel>(true);
        Entered = true;
    }

    public async Task Exit()
    {
        Entered = false;
        await _gameUI.ShowPanel<GameStorePanel>(false);
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
