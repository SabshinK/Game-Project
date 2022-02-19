using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveState : IPlayerState
    {
    
        public Vector2 location;

        private double velocity;
        private const int acceleration = 2;

        private Player player;
        public bool FaceRight { get; set; }

        public PlayerMoveState(Vector2 location, Player manager, bool faceright)
        {
            this.location = location;
            player = manager;
            velocity = 0;
            FaceRight = faceright;

        }

        public void Attack()
        {
            player.setState(new PlayerMoveState(location, player, FaceRight));
        }

        public void UseItem(IProjectile projectile)
        {
            player.setState(new PlayerItemState(player, FaceRight, projectile));
        }

        public void Update(GameTime gameTime)
        {
            if (FaceRight == false)
            {
                if (location.X > 0)
                {
                    location.X -= (float)velocity;
                }
                else
                {
                    BackToIdle();
                }
            } else
            {
                if (location.X < 800)
                {
                    location.X += (float)velocity;
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
