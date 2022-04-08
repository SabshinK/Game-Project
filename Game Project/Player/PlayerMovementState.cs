using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMovementState : IPlayerState
    {
        private Player player;

        public PlayerMovementState(Player manager, float forceX, float forceY)
        {
            player = manager;

            //reset the movement variables
            player.physics.drag = 0;

            player.physics.acceleration.X = 0;
            player.physics.velocity.X = 0;
            player.physics.displacement.X = 5;

            player.physics.acceleration.Y = 0;
            player.physics.velocity.Y = 0;
            player.physics.displacement.Y = 5;

            player.physics.appliedForce.X = forceX;
            player.physics.appliedForce.Y = forceY;

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
            player.SetState(new PlayerAttackState(player));
        }

        public void UseItem(IProjectile projectile)
        {
            player.projectile = projectile;
            player.SetState(new PlayerItemState(player));
        }

        public void Update(GameTime gameTime)
        {
            //horizontal movement
            player.physics.acceleration.X = player.physics.appliedForce.X = player.physics.drag;

            int displacement = (int)player.physics.HorizontalChange(gameTime, player.physics.acceleration.X);

            if (!player.FaceRight)
            {
                player.location.X -= displacement;
            } 
            else
            {
                player.location.X += displacement;
            }

            if (player.physics.drag < player.physics.appliedForce.X)
            {
                player.physics.drag += (float)gameTime.ElapsedGameTime.TotalSeconds;
            } else
            {
                player.physics.drag = player.physics.appliedForce.X;
            }

            //still need to implement slowing down and stopping
            if (player.physics.velocity.X == 0)
            {
                //BackToIdle();
            }

            //vertical movement
            if (player.physics.appliedForce.Y > 0)
            {
                player.physics.acceleration.Y = player.physics.appliedForce.Y - player.physics.gravity;

                player.location.Y -= (int)player.physics.VerticalChange(gameTime, player.physics.acceleration.Y);

                if (player.physics.velocity.Y >= 0)
                {
                    player.physics.falling = true;
                    player.physics.appliedForce.Y = 0;
                }
            } 

            //projectiles
            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }
    }
}
