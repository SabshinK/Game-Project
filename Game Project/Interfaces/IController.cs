namespace Game_Project
{
    public interface IController : IUpdateable
    {
        void LoadContent(GameStateMachine stateMachine, Player player, Sidekick sidekick);
    }
}
