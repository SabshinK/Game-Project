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
        public PlayerJumpState(Player manager)
        {
            player = manager;
            drag = 0;
            player.verticalAcceleration = 0;
            player.physics.verticalVelocity = -5;
            player.physics.verticalDistance = 0;

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
            player.physics.VerticalChange(false, gameTime, player.verticalAcceleration, drag);

            //I left the FaceRight condition because ideally, jumps will also move horizontally.
            //Right now, the if and else conditions have the same block of code.
            if (!player.FaceRight)
            {
                if (player.location.Y > 0)
                {
                    player.location.Y += (int)player.physics.verticalDistance;

                    if (player.physics.verticalVelocity == 0)
                    {
                        Fall();
                    }

                } else
                {
                    Fall();
                }
            }
            else
            {
                if (player.location.Y > 0)
                {
                    player.location.Y += (int)player.physics.verticalDistance;

                    if (player.physics.verticalVelocity == 0)
                    {
                        Fall();
                    }

                }
                else
                {
                    Fall();
                }
            }

            if (drag < (player.verticalAcceleration * -2) && (time / 0.5) >= 1)
            {
                drag++;
                time = 0;
            }

            if (player.physics.verticalVelocity >= 0)
            {
                Fall();
            }

            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }

    }
}
