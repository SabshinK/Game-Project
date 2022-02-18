using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    class PlayerMoveLeft : IPlayer
    {
    
        public Vector2 location;
        private int moveFactor;
        private PlayerManager manager;

        public PlayerMoveLeft(Vector2 location)
        {
            this.location = location;

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
                manager.Instance.BackToIdleLeft();
            }              

        }
    }
}
