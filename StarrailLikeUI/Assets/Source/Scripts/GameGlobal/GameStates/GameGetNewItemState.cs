using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameGetNewItemState : IGameState, IStateEnterable, IStateExitable
{
    [Inject] private GameUI _gameUI;
    [Inject] private SoundDataProvider _soundProvider;

    public GameStateMachine Initializer { get; set; }
    public bool Entered = false;

    public GameGetNewItemState(GameStateMachine initializer)
    {
        Initializer = initializer;
    }

    public async Task Enter()
    {
        _gameUI.PlayClip(_soundProvider.Data.Game.GetNewItem);
        await _gameUI.ShowPanel<GameGetNewItemPanel>(true);
        Entered = true;
    }

    public async Task Exit()
    {
        await _gameUI.ShowPanel<GameGetNewItemPanel>(false);
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
