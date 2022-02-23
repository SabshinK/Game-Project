using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class IdleState : IPlayerState
    {
        private Player player;
        public bool FaceRight { get; set; }

        public IdleState(Player manager, bool faceright)
        {
            player = manager;
            FaceRight = faceright;
            if (FaceRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("idleRight");
            } else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("idleLeft");
            }
        }

        public void BackToIdle()
        {
            // Already in the idle state
        }

        public void Move()
        {
            player.SetState(new PlayerMoveState(player, FaceRight));
        }

        public void TakeDamage()
        {
            player.SetState(new DamageState(player, FaceRight));
        }

        public void Attack()
        {
            player.SetState(new PlayerAttackState(player, FaceRight));
        }

        public void UseItem(IProjectile projectile)
        {
            player.projectile = projectile;
            player.SetState(new PlayerItemState(player, FaceRight));
        }
        
        public void Update(GameTime gameTime)
        {
            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }
    }
}
