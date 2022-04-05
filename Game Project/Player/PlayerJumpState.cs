using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerJumpState : IPlayerState
    {
        private Player player;
        private double drag;
        private double time;
        private bool falling;
        public PlayerJumpState(Player manager)
        {
            player = manager;
            drag = 0;
            falling = false;

            player.physics.verticalVelocity = -5;
            player.physics.verticalDisplacement = 0;

            if (player.FaceRight)
                player.sprite = SpriteFactory.Instance.CreateSprite("idleRight");
            else
                player.sprite = SpriteFactory.Instance.CreateSprite("idleLeft");
        }

        public void BackToIdle()
        {
            player.SetState(new IdleState(player));
        }

        public void Move()
        {
            player.SetState(new PlayerMoveState(player));
        }
        public void Jump()
        {
            // Already in the jump state
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
            int displacement = (int)player.physics.VerticalChange(falling, gameTime, player.verticalAcceleration, drag);

            if (player.location.Y > 0)
            {
                player.location.Y += displacement;
            }
            else
            {
                drag = Math.Abs(player.verticalAcceleration + player.verticalAcceleration);
                player.physics.verticalVelocity = 0;
                player.physics.verticalDisplacement = 0;
                falling = true;
            }

            if (drag < Math.Abs(player.verticalAcceleration + player.verticalAcceleration) && (time / 0.5) >= 1)
            {
                drag++;
                time = 0;
            }

            if (player.physics.verticalVelocity >= 0)
            {
                falling = true;
            }

            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }

    }
}
