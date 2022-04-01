using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Game_Project
{
    class Camera
    {
        private Vector2 worldPosVector;
        private Player subject;
        private int height = 600; //height of window
        private int width = 1000; //width of window
        private GraphicsDeviceManager graphics;
        private Viewport playerCam;

        public Camera(Player gamePlayer, GraphicsDeviceManager gameGraphics)
        {
            subject = gamePlayer;
            worldPosVector = gamePlayer.location;
            graphics = gameGraphics;

            playerCam.Width = width;
            playerCam.Height = height;
            playerCam.MinDepth = 0;
            playerCam.MaxDepth = 1;

        }

        public Viewport Update(Player gamePlayer)
        {
            worldPosVector = gamePlayer.location;

            worldPosVector.X -= worldPosVector.X / 2f;
            worldPosVector.Y -= worldPosVector.Y / 2f;


            playerCam.X = (int) worldPosVector.X;
            playerCam.Y = (int)worldPosVector.Y;

            return playerCam;
        }
    }
}
