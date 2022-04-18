using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GenericSprite : ISprite
    {
        private Texture2D spriteSheet;
        private Rectangle[] frames;        

        private int currentFrame;
        private int animationSpeed;
        private int frameCount;
        private int scale;
        
        public Vector2 Size => new Vector2(frames[currentFrame].Width, frames[currentFrame].Height);

        public GenericSprite(Tuple<Texture2D, Rectangle[], int, int> spriteData)
        {
            this.spriteSheet = spriteData.Item1;
            this.frames = spriteData.Item2;
            this.animationSpeed = spriteData.Item3;
            this.scale = spriteData.Item4;
            currentFrame = 0;
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
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, frames[currentFrame].Width * scale, 
                frames[currentFrame].Height * scale);

            spriteBatch.Draw(spriteSheet, destinationRectangle, frames[currentFrame], Color.White);
        }
    }
}
