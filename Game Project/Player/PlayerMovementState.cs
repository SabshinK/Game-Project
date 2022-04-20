using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game_Project
{
    class PlayerMovementState : IPlayerState
    {
        private Player player;

        public PlayerMovementState(Player manager)
        {
            player = manager;

            // Reset physics stuff
            player.physics.displacement = new Vector2(0.0f, 0.0f);
            player.physics.velocity = new Vector2(0.0f, 0.0f);
            player.physics.acceleration = new Vector2(0.0f, 0.0f);

            if (player.FacingRight) {
                if (player.isRunning)
                    player.sprite = SpriteFactory.Instance.CreateSprite("movingRight");
                if (player.isJumping)
                    player.sprite = SpriteFactory.Instance.CreateSprite("jumpingRight");
            }
            else
            {
                if (player.isRunning)
                    player.sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
                if (player.isJumping)
                    player.sprite = SpriteFactory.Instance.CreateSprite("jumpingLeft");
            }
                

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
            if (player.FacingRight)
            {
                if (player.isRunning)
                {
                    player.location.X += player.physics.HorizontalChange(gameTime);

                    if (player.physics.displacement.X <= 0)
                        BackToIdle();
                }
                if (player.isJumping)
                {
                    player.location.Y -= (int)player.physics.VerticalChange(gameTime);

                    if (player.physics.displacement.Y >= 0) //jumping has negative displacement
                        BackToIdle();
                }
            }
            else
            {
                if (player.isRunning)
                {
                    player.location.X -= player.physics.HorizontalChange(gameTime);

                    if (player.physics.displacement.X <= 0)
                        BackToIdle();
                }
                if (player.isJumping)
                {
                    player.location.Y -= (int)player.physics.VerticalChange(gameTime);

                    if (player.physics.displacement.Y >= 0) //jumping has negative displacement
                        BackToIdle();
                }
            }

            Debug.WriteLine(player.physics.displacement.X);

            //player.physics.Update(gameTime);
        }   
    }
}
