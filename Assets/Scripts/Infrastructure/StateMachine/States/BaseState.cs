namespace Platformer.Infrastructure.StateMachine.States
{
    public abstract class BaseState : IAppState
    {
        public abstract void Enter();
        public abstract void Exit();

        public override string ToString() =>
            $"{GetType()}";
    }
}