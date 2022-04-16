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

            // This snippet might be able to be put in a method or something it's used a few times I think
            if (player.FacingRight)
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
            if (player.FacingRight)
            {
                player.location.X += player.physics.HorizontalChange(gameTime);
            }
            else
            {
                player.location.X -= player.physics.HorizontalChange(gameTime);
            }

            //vertical movement
            if (player.physics.appliedForce.Y > 0)
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

            // We shouldn't need to go back to the idle state because they will go back once they hit a tile. 
            //if (player.physics.velocity.X <= 0 && (player.physics.falling && player.physics.velocity.Y >= player.physics.TERMINAL_Y))
            //{
            //    BackToIdle();
            //}

            player.physics.Update(gameTime);
        }   
    }
}
