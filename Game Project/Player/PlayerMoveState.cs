using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveState : IPlayerState
    {

        private double velocity;
        private const int acceleration = 2;

        private Player player;

        public PlayerMoveState(Player manager)
        {
            player = manager;
            velocity = 10;

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

            //if (velocity <= 6)
            //{
            //    velocity += acceleration * gameTime.ElapsedGameTime.TotalMilliseconds;
            //}
            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }
    }
}
