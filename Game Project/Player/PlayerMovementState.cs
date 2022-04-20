using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
            player.moving = true;
            if (player.FacingRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("movingRight");
                player.location.X += player.physics.HorizontalChange(gameTime);
            }
            else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
                player.location.X -= player.physics.HorizontalChange(gameTime);
            }

            //vertical movement
            if (player.physics.appliedForce.Y > 1)
                player.physics.falling = false;
            else
                player.physics.falling = true;

            if (player.FacingRight)
                player.sprite = SpriteFactory.Instance.CreateSprite("jumpingRight");
            else
                player.sprite = SpriteFactory.Instance.CreateSprite("jumpingLeft");

            //change position
            if (player.physics.falling)
                player.location.Y += (int)player.physics.VerticalChange(gameTime);
            else
                player.location.Y -= (int)player.physics.VerticalChange(gameTime);

            // stop once you've slowed down completely
            //if (!(player.physics.velocity.X > 0) && !(player.physics.velocity.Y > 0))
            //{
            //    BackToIdle();
            //}

            // No code for going back to the idle state because they will go back once they collide with a tile. 

            //player.physics.Update(gameTime);
        }   
    }
}
