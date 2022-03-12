using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game_Project
{
    // most of the functionality of this class may be changed based on how sprites are loaded
    public class SpriteFactory
    {
        // Declare the sprite factory as a singleton with a public getter
        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance => instance;

        // A Dictionary that contains a string key and a tuple containing the name of the texture, an array of the frame rectangles,
        // the animation speed, and the scale
        private Dictionary<string, Tuple<string, Rectangle[], int, int>> frames = new Dictionary<string, Tuple<string, Rectangle[], int, int>>();

        public SpriteFactory()
        {
            frames = new Dictionary<string, Tuple<string, Rectangle[], int, int>>();
        }

        /// <summary>
        /// Method for other classes to call when they need an ISprite implementation. Given the name of the animation needed,
        /// the corresponding texture and the animation parameters are found and a GenericSprite is returned
        /// </summary>
        /// <param name="animationName">The name of the animation needed.</param>
        /// <returns>A GenericSprite implementation</returns>
        public ISprite CreateSprite(string animationName)
        {
            return new GenericSprite(new Tuple<Texture2D, Rectangle[], int, int>(Texture2DStorage.GetTexture(frames[animationName].Item1),
                frames[animationName].Item2, frames[animationName].Item3, frames[animationName].Item4));
        }

        public void RegisterAnimation(string name, Tuple<string, Rectangle[], int, int> data)
        {
            frames.Add(name, data);
        }
    }
}
