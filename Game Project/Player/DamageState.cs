using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class DamageState : IPlayerState
    {
        private Player player;
        private float timeElapsed;

        public DamageState(Player manager)
        {
            player = manager;
            timeElapsed = 0;

            if (player.FaceRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("damagedRight");
            }
            else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("damagedLeft");
            }
        }
        public void BackToIdle()
        {
            // Can't go to idle in the damaged state until the animation is finished
        }

        public void TakeDamage()
        {
            // Already in the Damage state
        }

        public void Move()
        {
            // Can't move while being damaged
        }
        public void Jump()
        {
            player.SetState(new PlayerJumpState(player));
        }

        public void Attack()
        {
            // Can't attack in the damaged state
        }

        public void UseItem(IProjectile projectile)
        {
            // Can't use item in the damaged state
        }

        public void Update(GameTime gameTime)
        {
            if (timeElapsed < 2)
            {
                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            } else
            {
                player.SetState(new IdleState(player));
            }

            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }
        
    }
}
