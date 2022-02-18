using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    class PlayerMoveRight : IPlayer
    {
        
        public Vector2 location;
        private int moveFactor;
        private PlayerManager Player;
       

        public PlayerMoveRight(Vector2 location, PlayerManager player)
        {
            this.location = location;
            Player = player;
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
                Player.instance.BackToIdleRight();
            }
        }
    }
}
