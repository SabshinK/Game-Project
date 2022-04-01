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

        public Camera(Player gamePlayer, GraphicsDeviceManager gameGraphics)
        {
            subject = gamePlayer;
            worldPosVector = gamePlayer.location;
            graphics = gameGraphics;
            RenderTarget2D
        }

        public Matrix4x4 getFocusMatrix()
        {
            float left = worldPosVector.X - width / 2f;
            float right = worldPosVector.X + width / 2f;
            float top = worldPosVector.Y - height / 2f;
            float bottom = worldPosVector.Y + height / 2f;

            Matrix4x4 windowMatrix = Matrix4x4.CreateOrthographicOffCenter(left, right, bottom, top, 0, 0);

            graphics.GraphicsDevice.SetRenderTarget(subject);

            return windowMatrix;
        }
    }
}
