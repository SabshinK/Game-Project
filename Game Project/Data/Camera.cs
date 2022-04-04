﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace Game_Project
{
    class Camera
    {

        public Matrix zoomMatrix;
        Viewport cameraView;
        Vector2 cameraPos;

        public Camera(Viewport gameCamera)
        {
            cameraView = gameCamera;
        }

        public void Update(Player gamePlayer)
        {
            float cameraX = gamePlayer.location.X + 64 - (cameraView.Width / 2);
            float cameraY = gamePlayer.location.Y + 64 - (cameraView.Height / 2);

            cameraPos = new Vector2(cameraX, cameraY);

            //can be modified if needed, but tells the game how much to be zoomed in, this is standard zoom level
            zoomMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-cameraPos.X, -cameraPos.Y, 0));
        }
    }
}
