using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public interface IProjectile : IGameObject, IMoveable, IUpdateable, IDrawable, ICollideable
    {
        // There are no projectile specific methods currently
    }
}
