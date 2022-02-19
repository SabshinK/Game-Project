namespace Game_Project
{
    public interface IController
    {
        void LoadContent(Game1 game, Player player, TileManager tiles, EnemyManager enemies, ItemManager items);
        void Update();
    }
}
