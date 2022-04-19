using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class IdleState : IPlayerState
    {
        private Player player;

        public IdleState(Player manager)
        {
            player = manager;
            player.moving = false;
            if (player.FacingRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("idleRight");
            } else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("idleLeft");
            }
        }

        public void BackToIdle()
        {
            // Already in the idle state
        }

        public void Move()
        {
            player.SetState(new PlayerMovementState(player));
        }

        public void TakeDamage()
        {
            player.SetState(new DamageState(player));
        }

        public void Attack()
        {
            player.SetState(new PlayerAttackState(player));
        }

        public void UseItem(IProjectile projectile)
        {
            player.projectile = projectile;
            player.SetState(new PlayerItemState(player));
        }
        
        public void Update(GameTime gameTime)
        {
            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }
    }
}
