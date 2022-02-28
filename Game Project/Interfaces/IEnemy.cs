using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IEnemy
    {
      //  public void Create(SpriteBatch spriteBatch, Vector2 vector);
        public void ChangeDirection();

        public void Attack();

        public void TakeDamage();

    }
}
