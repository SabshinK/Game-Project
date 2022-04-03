using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerFallState : IPlayerState
    {
        private Player player;
        private double drag;
        private double time;
        public PlayerFallState(Player manager)
        {
            player = manager;
            player.verticalAcceleration = 2;
            drag = -2;

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
            player.SetState(new PlayerJumpState(player));
        }

        public void Fall()
        {
            //already falling
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
            player.physics.VerticalChange(true, gameTime, player.verticalAcceleration, drag);

            //I left the FaceRight condition because ideally, jumps will also move horizontally.
            //Right now, the if and else conditions have the same block of code.
            if (!player.FaceRight)
            {
                player.location.Y += (int)player.physics.verticalDistance;
            }
            else
            {
                player.location.Y += (int)player.physics.verticalDistance;
            }

            if (player.verticalAcceleration != drag && (time / 0.5) >= 1)
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
