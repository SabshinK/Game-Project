using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface ISidekick : IGameObject, IMoveable, ICollideable
    {
        public void Follow();

        public void Attack();

        public void Stay();

        public void Collide(Rectangle collision, int direction);
    }
}
