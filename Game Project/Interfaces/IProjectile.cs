using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public interface IProjectile
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
