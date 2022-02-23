using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerAttackState : IPlayerState
    {
        private Player player;
        private float timeElapsed;
        public bool FaceRight { get; set; }

        public PlayerAttackState(Player player, bool faceRight)
        {
            this.player = player;
            FaceRight = faceRight;

            if (FaceRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("attackRight");
            }
            else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("attackLeft");
            }
        }

        public void BackToIdle()
        {
            player.SetState(new IdleState(player, FaceRight));
        }

        public void Move()
        {
            // Can't move until attack is over
        }

        public void TakeDamage()
        {
            player.SetState(new DamageState(player, FaceRight));
        }

        public void Attack()
        {
            // Already in attack state
        }

        public void UseItem(IProjectile projectile)
        {
            // Can't use an item while attacking
        }

        public void Update(GameTime gameTime)
        {
            if (timeElapsed < 0.5)
            {
                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                player.SetState(new IdleState(player, FaceRight));
            }

            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }
    }
}
