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
        public bool runAndThenJump;

        public PlayerMovementState(Player manager)
        {
            player = manager;

            runAndThenJump = false;

            // Reset physics stuff
            player.physics.displacement = new Vector2(0.0f, 0.0f);
            player.physics.velocity = new Vector2(0.0f, 0.0f);
            player.physics.acceleration = new Vector2(0.0f, 0.0f);

            if (player.isJumping)
                player.physics.startJumping = true;

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
            if (player.FacingRight)
            {
                if (player.isRunning && !player.isJumping)
                {
                    player.physics.startJumping = false;
                    player.location.X += player.physics.HorizontalChange(gameTime);

                    if (player.physics.displacement.X <= 0)
                        BackToIdle();

                }
                if (player.isJumping && !player.isRunning)
                {
                    player.location.Y -= player.physics.VerticalChange(gameTime);

                    if (player.physics.displacement.Y <= 0)
                        player.physics.falling = true;

                    if (player.physics.displacement.Y <= 0)
                    {
                        BackToIdle();
                    }

                    if (player.physics.velocity.Y <= 0 && player.isRunning) //set the starting velocity if a jump occurs while already running
                        player.physics.startJumping = true;
                }
                if (player.isRunning && player.isJumping)
                {
                    player.location.X += player.physics.HorizontalChange(gameTime);
                    player.location.Y -= player.physics.VerticalChange(gameTime);

                    if (player.physics.displacement.X <= 0 && player.physics.displacement.Y <= 0)
                        BackToIdle();
                }
            }
            else
            {
                if (player.isRunning && !player.isJumping)
                {
                    player.physics.startJumping = false;
                    player.location.X -= player.physics.HorizontalChange(gameTime);

                    if (player.physics.displacement.X <= 0)
                        BackToIdle();

                }
                if (player.isJumping && !player.isRunning)
                {
                    player.location.Y -= player.physics.VerticalChange(gameTime);

                    if (player.physics.displacement.Y <= 0)
                        player.physics.falling = true;

                    if (player.physics.displacement.Y <= 0)
                    {
                        BackToIdle();
                    }

                    if (player.physics.velocity.Y <= 0 && player.isRunning) //set the starting velocity if a jump occurs while already running
                        player.physics.startJumping = true;
                }
                if (player.isRunning && player.isJumping)
                {
                    player.location.X -= player.physics.HorizontalChange(gameTime);
                    player.location.Y -= player.physics.VerticalChange(gameTime);

                    if (player.physics.displacement.X <= 0 && player.physics.displacement.Y <= 0)
                        BackToIdle();
                }

            }

            Debug.WriteLine(player.physics.displacement.Y);

            //player.physics.Update(gameTime);
        }   
    }
}
