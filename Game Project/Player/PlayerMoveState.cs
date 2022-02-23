using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveState : IPlayerState
    {

        private double velocity;
        private const int acceleration = 2;

        private Player player;
        public bool FaceRight { get; set; }

        public PlayerMoveState(Player manager, bool faceright)
        {
            player = manager;
            velocity = 10;
            FaceRight = faceright;

            if (FaceRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("movingRight");
            }
            else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
            }
        }

        public void Attack()
        {
            player.setState(new PlayerMoveState(player, FaceRight));
        }

        public void UseItem(IProjectile projectile)
        {
            player.projectile = projectile;
            player.setState(new PlayerItemState(player, FaceRight));
        }

        public void Update(GameTime gameTime)
        {
            if (FaceRight == false)
            {
                if (player.location.X > 0)
                {
                    player.location.X -= (float)velocity;
                }
                else
                {
                    BackToIdle();
                }
            } else
            {
                if (player.location.X < 800)
                {
                    player.location.X += (float)velocity;
                }
                else
                {
                    BackToIdle();
                }
            }

            //if (velocity <= 6)
            //{
            //    velocity += acceleration * gameTime.ElapsedGameTime.TotalMilliseconds;
            //}
            if (player.projectile != null)
            {
                player.projectile.Update(gameTime);
            }

            player.sprite.Update();
        }

        public void BackToIdle() 
        {
            player.setState(new IdleState(player, FaceRight));
        }

        public void TakeDamage()
        {
            player.setState(new DamageState(player, FaceRight));
        }
    }
}
