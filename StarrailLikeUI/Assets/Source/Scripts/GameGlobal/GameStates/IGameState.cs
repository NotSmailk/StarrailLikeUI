public interface IGameState : IState<GameStateMachine>, IStateRunable
{
    public new void Run();
}
