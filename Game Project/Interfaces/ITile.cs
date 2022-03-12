using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface ITile : IDrawable, ICollideable
    {
        //  no tile specific methods rn
        public Vector2 Position { get; }
    }
}
