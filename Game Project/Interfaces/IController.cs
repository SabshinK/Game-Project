namespace Game_Project
{
    public interface IController : IUpdateable
    {
        void LoadContent(Game1 game, Player player, TileManager tiles, EnemyManager enemies, ItemManager items);
    }
}
