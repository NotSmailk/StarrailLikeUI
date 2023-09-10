using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameStoreBuyItemState : IGameState, IStateEnterable, IStateExitable
{
    [Inject] private GameUI _gameUI;

    public GameStateMachine Initializer { get; set; }
    public bool Entered = false;

    public GameStoreBuyItemState(GameStateMachine initializer)
    {
        Initializer = initializer;
    }

    public async Task Enter()
    {
        await _gameUI.ShowPanel<StoreBuyItemPanel>(true);
        Entered = true;
    }

    public async Task Exit()
    {
        await _gameUI.ShowPanel<StoreBuyItemPanel>(false);
        Entered = false;
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
