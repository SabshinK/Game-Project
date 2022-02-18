using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Interfaces;

namespace Game_Project.Sprites
{
    class GenericSprite : ISprite
    {
        private Texture2D spriteSheet;
        private Rectangle[] frames;

        private int currentFrame;
        private int animationSpeed;
        private int frameCount;

        public GenericSprite(Texture2D spriteSheet, Rectangle[] frames, int animationSpeed)
        {
            this.spriteSheet = spriteSheet;
            this.frames = frames;
            currentFrame = 0;
            this.animationSpeed = animationSpeed;
        }

        // Count frames
        public void Update()
        {
            frameCount++;
            if (frameCount == frames.Length * animationSpeed)
                frameCount = 0;

            // Must divide frameCount by the animation speed since frame count is a scale of the actual current frame
            currentFrame = frameCount / animationSpeed;
        }

        // Display the current frame
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, frames[currentFrame].Width, 
                frames[currentFrame].Height);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, frames[currentFrame], Color.White);
            spriteBatch.End();
        }
    }
}
