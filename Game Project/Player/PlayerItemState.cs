using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerItemState : IPlayerState : IUpdateable
    {
        private Player player;
        private float timeElapsed;

        public PlayerItemState(Player player)
        {
            this.player = player;
            if (player.FaceRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("useItemRight");
            } else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("useItemLeft");
            }
        }

        public void BackToIdle()
        {
            player.SetState(new IdleState(player));
        }

        public void Move()
        {
            // Can't move while using an item
        }
        
        public void TakeDamage()
        {
            player.SetState(new DamageState(player));
        }

        public void Attack()
        {
            // Can't attack while using an item
        }

        public void UseItem(IProjectile projectile)
        {
            // Already using an item
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
