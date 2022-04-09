using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IEnemy : IGameObject, IMoveable, IUpdateable, IDrawable, ICollideable
    {
        public void ChangeDirection();

        public void Attack();

        public void TakeDamage();

    }
}
