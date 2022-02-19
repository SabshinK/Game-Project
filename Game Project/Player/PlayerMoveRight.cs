using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveRight : IPlayer
    {
        
        public Vector2 location;
        private int moveFactor;
        private Player manager;
       

        public PlayerMoveRight(Vector2 location, Player player)
        {
            this.location = location;
            manager = player;
            moveFactor = 2;

        }

        public void Update()
        {
            if (location.X < 800)
            {
                location.X += moveFactor;
            }
            else
            {
                manager.BackToIdleRight();
            }
        }
        public void BackToIdleRight()
        {
            manager.state = new RightIdle(manager);

        }
        public void BackToIdleLeft()
        {
            manager.state = new LeftIdle(manager);
        }
    }
}
