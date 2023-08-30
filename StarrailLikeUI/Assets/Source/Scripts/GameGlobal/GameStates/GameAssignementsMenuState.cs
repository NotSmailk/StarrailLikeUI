using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameAssignementsMenuState : IGameState, IStateEnterable, IStateExitable
{
    [Inject] private GameUI _gameUI;

    public GameStateMachine Initializer { get; set; }
    public bool Entered = false;

    public GameAssignementsMenuState(GameStateMachine initializer)
    {
        Initializer = initializer;
    }

    public async Task Enter()
    {
        await _gameUI.ShowPanel<GameAssignmentsPanel>(true);
        Entered = true;
    }

    public async Task Exit()
    {
        await _gameUI.ShowPanel<GameAssignmentsPanel>(false);
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
