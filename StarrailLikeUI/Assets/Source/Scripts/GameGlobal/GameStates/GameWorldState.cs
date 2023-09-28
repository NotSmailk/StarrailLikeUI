using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameWorldState : IGameState, IStateEnterable, IStateExitable
{
    [Inject] private GameUI _gameUI;
    [Inject] private GameCharacters _characters;
    [Inject] private GameCamera _camera;

    public GameStateMachine Initializer { get; set; }
    public bool Entered = false;

    public GameWorldState(GameStateMachine initializer)
    {
        Initializer = initializer;
    }

    public async Task Enter()
    {
        if (Initializer.PrevState?.GetType() == typeof(GamePhoneMenuState))
        { 
            var middle = _camera.WorldPosition + (_characters.CurCharacter.transform.position - _camera.WorldPosition) / 4f;
            _camera.SetWorldPositionAndRotation(middle, 0.25f);
        }

        _characters.ActivateWorldMode();
        await _gameUI.ShowPanel<GameWorldPanel>(true);
        await Task.Delay(300);
        Entered = true;
    }

    public async Task Exit()
    {
        _camera.RememperPositionAndRotation();
        Entered = false;
        await _gameUI.ShowPanel<GameWorldPanel>(false);
    }

    public void Run()
    {
        if (!Entered)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            Initializer.SwitchState<GamePhoneMenuState>();

        if (Input.GetKeyDown(KeyCode.I))
            Initializer.SwitchState<GameInventoryState>();

        if (Input.GetKeyDown(KeyCode.C))
            Initializer.SwitchState<GameCharactersMenuState>();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetAcitveCharacter(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetAcitveCharacter(1);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetAcitveCharacter(2);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetAcitveCharacter(3);
    }

    private void SetAcitveCharacter(int id)
    {
        if (_characters.SetActiveCharater(id))
        {
            _gameUI.SetActiveCharacter(id);
        }
    }
}
