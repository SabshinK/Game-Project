using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IPlayer : IGameObject, IMoveable, IUpdateable, IDrawable, ICollideable
    {
        public void Bump(Rectangle collision, int direction);
    }
}
