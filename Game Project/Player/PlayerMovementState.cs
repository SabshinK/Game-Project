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
            player.physics.velocity.X = 0f;
            player.physics.acceleration = new Vector2(0.0f, 0.0f);

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

        public void CheckAnimation()
        {
            if (player.FacingRight) 
            {
                if (player.isColliding && player.currentAnimationJump.Equals("jumpingRight") && player.physics.falling)
                {
                    player.sprite = SpriteFactory.Instance.CreateSprite("movingRight");
                    player.currentAnimationJump = "";
                }

                if (!player.isColliding && player.currentAnimationRun.Equals("movingRight"))
                {
                    player.sprite = SpriteFactory.Instance.CreateSprite("jumpingRight");
                    player.currentAnimationRun = "";
                }
            }
            else
            {
                if (player.isColliding && player.currentAnimationJump.Equals("jumpingLeft") && player.physics.falling)
                {
                    player.sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
                    player.currentAnimationJump = "";
                }

                if (!player.isColliding && player.currentAnimationRun.Equals("movingLeft"))
                {
                    player.sprite = SpriteFactory.Instance.CreateSprite("jumpingLeft");
                    player.currentAnimationRun = "";
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (player.FacingRight)
            {

                player.location.X += player.physics.HorizontalChange(gameTime);

                if (player.physics.displacement.X <= 0f)
                {
                    CheckAnimation();
                    player.physics.isRunning = false;
                }


                player.location.Y -= player.physics.VerticalChange(gameTime);

                if (player.physics.displacement.Y <= 0f)
                {
                    CheckAnimation();
                    player.physics.isJumping = false;
                    player.physics.falling = true;
                    player.physics.startJumping = false;
                }

                if (!player.physics.isRunning && !player.physics.isJumping)
                {

                    BackToIdle();
                }

            }
            else
            {

                player.location.X -= player.physics.HorizontalChange(gameTime);

                if (player.physics.displacement.X <= 0f)
                {
                    CheckAnimation();
                    player.physics.isRunning = false;
                }

                player.location.Y -= player.physics.VerticalChange(gameTime);

                if (player.physics.displacement.Y <= 0f)
                {
                    CheckAnimation();
                    player.physics.isJumping = false;
                    player.physics.falling = true;
                    player.physics.startJumping = false;
                }

                if (!player.physics.isRunning && !player.physics.isJumping)
                {
                    BackToIdle();
                }


            }

            Debug.WriteLine(player.physics.acceleration.Y);
        }   
    }
}
