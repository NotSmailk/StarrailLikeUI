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
        CreateAndAddState<GameWorldState>();
        CreateAndAddState<GamePhoneMenuState>();
        CreateAndAddState<GameStoreMenuState>();
        CreateAndAddState<GameFriendsMenuState>();
        CreateAndAddState<GameAssignementsMenuState>();
        CreateAndAddState<GameInventoryState>();
        CreateAndAddState<GameSpinsMenuState>();
        CreateAndAddState<GameCharactersMenuState>();

        _curState = _states[typeof(GameWorldState)];
        if (_curState is IStateEnterable enterable)
            enterable.Enter();
    }

    private TGameState CreateAndAddState<TGameState>() where TGameState : class, IGameState
    {
        var state = _container.Instantiate<TGameState>();
        state.Initializer = this;
        _container.BindInterfacesAndSelfTo<TGameState>().FromInstance(state);
        _states.Add(typeof(TGameState), state);
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
