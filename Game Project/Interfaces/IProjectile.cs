using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IProjectile
    {
        public void Update(GameTime gameTime);
        public void Draw();
    }
}
