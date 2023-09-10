using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GamePhoneMenuState : IGameState, IStateEnterable, IStateExitable
{
    [Inject] private GameCharacters _characters;
    [Inject] private GameUI _gameUI;
    [Inject] private GameCamera _camera;

    public GameStateMachine Initializer { get; set; }
    public bool Entered = false;

    public GamePhoneMenuState(GameStateMachine initializer)
    {
        Initializer = initializer;
    }

    public async Task Enter()
    {
        if (Initializer.PrevState?.GetType() == typeof(GameWorldState))
        {
            Vector3 middle = _characters.CurCharacter.PhoneViewPoint.position - _characters.CurCharacter.PhoneViewPoint.forward;
            _camera.SetPositionAndRotation(
                middle, 
                _characters.CurCharacter.PhoneViewPoint.position, 
                _characters.CurCharacter.PhoneViewPoint.rotation, 
                0.25f);
        }

        _characters.ActivatePhoneMode();
        await _gameUI.ShowPanel<GameMenuPanel>(true);
        await Task.Delay(300);
        Entered = true;
    }

    public async Task Exit()
    {
        Entered = false;
        await _gameUI.ShowPanel<GameMenuPanel>(false);
    }

    public void Run()
    {
        if (!Entered)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Initializer.SwitchState<GameWorldState>();
        }

        _gameUI.GameUpdateMenu();
    }
}
