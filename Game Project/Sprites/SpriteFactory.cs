using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    // most of the functionality of this class may be changed based on how sprites are loaded
    public class SpriteFactory
    {
        // Declare the sprite factory as a singleton with a public getter
        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance => instance;

        // A Dictionary that contains a string key and a tuple containing the name of the texture, an array of the frame rectangles,
        // and the animation speed
        private Dictionary<string, Tuple<string, Rectangle[], int>> frames;

        /// <summary>
        /// Method for other classes to call when they need an ISprite implementation. Given the name of the spritesheet needed,
        /// the corresponding texture and the animation parameters are found and a GenericSprite is returned
        /// </summary>
        /// <param name="spriteName">The name of the spritesheet needed.</param>
        /// <returns>A GenericSprite implementation</returns>
        public ISprite CreateSprite(string animationName)
        {
            return new GenericSprite(Texture2DStorage.GetTexture(frames[animationName].Item1), frames[animationName].Item2, 
                frames[animationName].Item3);
        }
    }
}
