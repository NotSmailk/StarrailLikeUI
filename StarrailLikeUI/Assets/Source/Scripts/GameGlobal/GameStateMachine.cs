using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMachine : MonoBehaviour
{
    [Inject] private DiContainer _container;
    private IGameState _curState;
    private Dictionary<Type, IGameState> _states = new Dictionary<Type, IGameState>();
    private Stack<IGameState> _statesStack = new Stack<IGameState>();

    public IGameState PrevState 
    {
        get
        {
            _statesStack.TryPeek(out IGameState state);
            return state;
        }
    }

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
        CreateAndAddState<GameStoreBuyItemState>();
        CreateAndAddState<GameItemViewMenuState>();

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
        if (_curState is IStateExitable exitable)
            await exitable.Exit();

        if (_statesStack.Count > 0)
            _statesStack.Pop();

        _statesStack.Push(_curState);

        if (_states.TryGetValue(typeof(TState), out IGameState state))
            _curState = state;

        if (_curState is IStateEnterable enterable)
            await enterable.Enter();
    }

    public async void SwitchStateWithoutExit<TState>() where TState : IState<GameStateMachine>
    {
        _statesStack.Push(_curState);

        if (_states.TryGetValue(typeof(TState), out IGameState state))
            _curState = state;

        if (_curState is IStateEnterable enterable)
            await enterable.Enter();
    }

    public async void SwitchToPreviousState()
    {
        if (_curState is IStateExitable exitable)
            await exitable.Exit();

        if (_statesStack.Peek() is IStateEnterable enterable)
            await enterable.Enter();

        _curState = _statesStack.Pop();
    }

    public async void SwitchToPreviousWithoutEnter()
    {
        var curState = _curState;
        _curState = _statesStack.Pop();

        if (curState is IStateExitable exitable)
            await exitable.Exit();
    }
}
