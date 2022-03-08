using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveState : IPlayerState
    {

        private Player player;
        private int velocity;

        public PlayerMoveState(Player manager)
        {
            player = manager;

            velocity = (int)player.physics.horizontalVelocity;

            // This snippet might be able to be put in a method or something it's used a few times I think
            if (player.FaceRight)
                player.sprite = SpriteFactory.Instance.CreateSprite("movingRight");
            else
                player.sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
        }

        public void BackToIdle() 
        {
            player.SetState(new IdleState(player));
        }

        public void Move()
        {
            // Already moving
        }

        public void TakeDamage()
        {
            player.SetState(new DamageState(player));
        }

        public void Attack()
        {
            player.SetState(new PlayerMoveState(player));
        }

        public void UseItem(IProjectile projectile)
        {
            player.projectile = projectile;
            player.SetState(new PlayerItemState(player));
        }

        public void Update(GameTime gameTime)
        {
            if (!player.FaceRight)
            {
                if (player.location.X > 0)
                {
                    player.location.X -= (float)velocity;
                }
                else
                {
                    BackToIdle();
                }
            } 
            else
            {
                if (player.location.X < 800)
                {
                    player.location.X += (float)velocity;
                }
                else
                {
                    BackToIdle();
                }
            }

            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }
    }
}
