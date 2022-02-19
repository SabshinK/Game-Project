using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public interface IDrawable
    {
        public void Draw(SpriteBatch spriteBatch, Vector2 location); // Draw function for creating any animations.
    }
}
