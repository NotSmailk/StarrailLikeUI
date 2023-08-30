using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMachine : MonoBehaviour
{
    [Inject] private DiContainer _container;
    private IGameState _curState;
    private IGameState _prevState;
    private Dictionary<Type, IGameState> _states = new Dictionary<Type, IGameState>();

    public IGameState PrevState => _prevState;

    public void Init()
    {
        _states.Add(typeof(GameWorldState), Create<GameWorldState>());
        _states.Add(typeof(GamePhoneMenuState), Create<GamePhoneMenuState>());
        _states.Add(typeof(GameStoreMenuState), Create<GameStoreMenuState>());
        _states.Add(typeof(GameFriendsMenuState), Create<GameFriendsMenuState>());
        _states.Add(typeof(GameAssignementsMenuState), Create<GameAssignementsMenuState>());
        _states.Add(typeof(GameInventoryState), Create<GameInventoryState>());
        _states.Add(typeof(GameSpinsMenuState), Create<GameSpinsMenuState>());
        _states.Add(typeof(GameCharactersMenuState), Create<GameCharactersMenuState>());

        _curState = _states[typeof(GameWorldState)];
        if (_curState is IStateEnterable enterable)
            enterable.Enter();
    }

    public TGameState Create<TGameState>() where TGameState : class, IGameState
    {
        var state = _container.Instantiate<TGameState>();
        state.Initializer = this;
        _container.BindInterfacesAndSelfTo<TGameState>().FromInstance(state);
        return state;
    }

    public void GameUpdate()
    {
        RunStateMachine();
    }

    public void RunStateMachine()
    {
        _curState?.Run();
    }

    public async void SwitchState<TState>() where TState : IState<GameStateMachine>
    {
        // Try to exit from previous state
        if (_curState is IStateExitable exitable)
            await exitable.Exit();

        // Try to find new state
        _prevState = _curState;
        if (_states.TryGetValue(typeof(TState), out IGameState state))
            _curState = state;

        // Try to enter new state
        if (_curState is IStateEnterable enterable)
            await enterable.Enter();
    }

    public async void SwitchToPreviousState()
    {
        // Try to exit from previous state
        if (_curState is IStateExitable exitable)
            await exitable.Exit();

        // Try to find new state
        var temp = _curState;
        _curState = _prevState;
        _prevState = temp;

        // Try to enter new state
        if (_curState is IStateEnterable enterable)
            await enterable.Enter();
    }
}
