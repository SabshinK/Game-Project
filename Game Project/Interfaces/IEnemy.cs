using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IEnemy : IGameObject, IMoveable, ICollideable
    {
        public void ChangeDirection();

        public void Attack();

        public void TakeDamage();

        public void Collide(Rectangle collision, int direction);
    }
}
