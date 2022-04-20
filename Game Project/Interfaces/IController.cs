namespace Game_Project
{
    public interface IController : IUpdateable
    {
        void LoadContent(Player player, Sidekick sidekick);
    }
}
