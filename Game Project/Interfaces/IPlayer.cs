using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IPlayer : IUpdateable, IDrawable, ICollideable
    {
        public Vector2 Position { get; }
    }
}
