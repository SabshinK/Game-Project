using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Interfaces;

namespace Game_Project.Sprites
{
    class PlayerMoveLeft : IPlayer
    {
    
        public Vector2 location;
        private int moveFactor;
        private PlayerManager manager;

        public PlayerMoveLeft(Vector2 location, PlayerManager player)
        {
            this.location = location;
            manager = player;
            moveFactor = 2;           

        }

        public void Update()
        {
             if (location.X > 0)
            {
                location.X -= moveFactor;
            }
             else
            {
                manager.BackToIdleLeft();
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
