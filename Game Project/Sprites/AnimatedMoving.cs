using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class AnimatedMoving
    {
        // Necessary for implementing ISprite
        public Texture2D Texture { get; set; }
        // Vector needed to determine location of sprite to render, this is a bandaid solution for the problem of getting a
        // location vector to the sprite classes for drawing
        public Vector2 location;
        // Necessary for movement to tell when the player has moved off screen, this is a bandaid solution
        public Rectangle WindowSize { get; set; }

        // Necessary for animating
        public int Rows { get; set; }
        public int Columns { get; set; }

        private int currentFrame;
        private int totalFrames;

        // Quick and dirty ways of altering various things
        private int scaleFactor;
        private int moveFactor;
        private int animationSpeed;

        public AnimatedMoving(Texture2D texture, Vector2 location, Rectangle windowSize, int rows, int columns)
        {
            Texture = texture;
            this.location = location;
            WindowSize = windowSize;

            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;

            scaleFactor = 4;
            moveFactor = 4;
            animationSpeed = 3;
        }

        // Must include both frame counting and movement
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames * animationSpeed)
                currentFrame = 0;

            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Calculate size of individual sprites in spritesheet and which sprite is being animated
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (currentFrame / animationSpeed) / Columns;
            int column = (currentFrame / animationSpeed) % Columns;

            // Get the current frame to draw from the sheet and display it at the position in destinationRectangle
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scaleFactor, height * scaleFactor);

            // Use spriteBatch to draw the current frame
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);  // Gets rid of bluriness
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        // All manipulating of positions goes in this method
        private void Move()
        {
            location.X += moveFactor;
            if (location.X == WindowSize.Width)
            {
                location.X = -Texture.Width;
            }
        }
    }
}
