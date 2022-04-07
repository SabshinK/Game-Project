using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface ISprite
    {
        public Vector2 Size { get; }

        void Update();
        
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
