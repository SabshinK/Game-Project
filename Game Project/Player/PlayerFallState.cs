using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerFallState : IPlayerState
    {
        Player player;
        public PlayerFallState(Player manager)
        {
            player = manager;

            if (player.FaceRight)
                player.sprite = SpriteFactory.Instance.CreateSprite("fallRight");
            else
                player.sprite = SpriteFactory.Instance.CreateSprite("fallLeft");
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
            player.physics.VerticalChange(true);

            //I left the FaceRight condition because ideally, jumps will also move horizontally.
            //Right now, the if and else conditions have the same block of code.
            if (!player.FaceRight)
            {
                if (player.location.Y > 0)
                {
                    player.location.Y -= (int)player.physics.verticalDistance;
                } else
                {
                    BackToIdle();
                }
            }
            else
            {
                if (player.location.Y > 0)
                {
                    player.location.Y -= (int)player.physics.verticalDistance;
                }
                else
                {
                    BackToIdle();
                }
            }

            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }

    }
}
