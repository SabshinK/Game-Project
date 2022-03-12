using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IEnemy : IUpdateable, IDrawable, ICollideable
    {
      //  public void Create(SpriteBatch spriteBatch, Vector2 vector);

        public Vector2 Position { get; }
        public void ChangeDirection();

        public void Attack();

        public void TakeDamage();

        public void Fall();
    }
}
