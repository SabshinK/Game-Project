using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveState : IPlayerState
    {

        private Player player;
        private double drag;
        private double time;

        public PlayerMoveState(Player manager)
        {
            player = manager;
            drag = 0;

            player.horizontalAcceleration = 2;
            player.physics.horizontalVelocity = 0;
            player.physics.horizontalDistance = 5;

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
        public void Jump()
        {
            player.SetState(new PlayerJumpState(player));
        }

        public void Fall()
        {
            player.SetState(new PlayerFallState(player));
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
            time += gameTime.ElapsedGameTime.TotalSeconds;
            player.physics.HorizontalChange(gameTime, player.horizontalAcceleration, drag);

            if (!player.FaceRight)
            {
                player.location.X -= (int)player.physics.horizontalDistance;
            } 
            else
            {
                player.location.X += (int)player.physics.horizontalDistance;
            }  

            if (player.horizontalAcceleration < 5 && (time/0.5) >= 1)
            {
                player.horizontalAcceleration++;
            }

            if (player.horizontalAcceleration == 5 && player.horizontalAcceleration != drag && (time/0.5) >= 1)
            {
                drag++;
                time = 0;
            }
            
            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }
    }
}
