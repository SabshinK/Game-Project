using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IPlayerState
    {
        public void BackToIdle();
        
        public void Move();

        public void TakeDamage();

        public void Attack();

        public void UseItem(IProjectile projectile);

        public void Update(GameTime gameTime);
    }
}
