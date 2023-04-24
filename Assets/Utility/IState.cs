namespace CustomStateMachine
{
    public interface IState
    {
        public void Initialize(StateMachine stateMachine);
        public void Enter();
        public void Update();
        public void Exit();

    }
}