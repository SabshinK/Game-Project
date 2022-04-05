using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerAttackState : IPlayerState
    {
        private Player player;
        private float timeElapsed;

        public PlayerAttackState(Player player)
        {
            this.player = player;

            if (player.FaceRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("attackRight");
            }
            else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("attackLeft");
            }
        }

        public void BackToIdle()
        {
            player.SetState(new IdleState(player));
        }

        public void Move()
        {
            // Can't move until attack is over
        }
        public void Jump()
        {
            player.SetState(new PlayerJumpState(player));
        }

        public void TakeDamage()
        {
            player.SetState(new DamageState(player));
        }

        public void Attack()
        {
            // Already in attack state
        }

        public void UseItem(IProjectile projectile)
        {
            // Can't use an item while attacking
        }

        public void Update(GameTime gameTime)
        {
            if (timeElapsed < 0.5)
            {
                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
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
