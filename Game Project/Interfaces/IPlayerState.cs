using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IPlayerState
    {
        public void BackToIdle();
        public void Update(GameTime gameTime); //both move left and moveRight would need to implement this. 
        public void TakeDamage();
    }
}
