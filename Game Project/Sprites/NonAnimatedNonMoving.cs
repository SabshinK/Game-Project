using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class NonAnimatedNonMoving : ISprite
    {
        public Texture2D Texture { get; set; }
        // Vector needed to determine location of sprite to render, this is a bandaid solution for the problem of getting a
        // location vector to the sprite classes for drawing
        public Vector2 location;
        // Necessary for movement to tell when the player has moved off screen, this is a bandaid solution
        public Rectangle WindowSize { get; set; }

        // Necessary for animating
        public int Rows { get; set; }
        public int Columns { get; set; }

        // Quick and dirty ways of altering various things
        private int scaleFactor;

        public NonAnimatedNonMoving(Texture2D texture, Vector2 location, Rectangle windowSize, int rows, int columns)
        {
            Texture = texture;
            this.location = location;
            WindowSize = windowSize;

            Rows = rows;
            Columns = columns;

            scaleFactor = 4;
        }

        // No movement or frame counting needed
        public void Update()
        {
            // Do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Calculate size of individual sprites in spritesheet
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;

            // Get the current frame to draw from the sheet and display it at the position in destinationRectangle
            Rectangle sourceRectangle = new Rectangle(width * 1, height * 1, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scaleFactor, height * scaleFactor);

            // Use spriteBatch to draw the current frame
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);  // Gets rid of bluriness
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
