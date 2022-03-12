using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public interface IProjectile : IUpdateable, IDrawable, ICollideable
    {
        // There are no projectile specific methods currently
        public Vector2 Position { get; }
    }
}
