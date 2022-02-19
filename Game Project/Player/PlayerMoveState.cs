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
        public bool faceRight;

        public PlayerMoveState(Vector2 location, Player manager, bool faceright)
        {
            this.location = location;
            player = manager;
            velocity = 0;
            faceRight = faceright;

        }

        public void Update(GameTime gameTime)
        {
            if (faceRight == false)
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
            player.state = new IdleState(player, faceRight);
        }

        public void TakeDamage()
        {
            //hey whats up
        }
    }
}
