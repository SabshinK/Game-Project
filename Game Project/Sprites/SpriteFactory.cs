using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game_Project
{
    public class SpriteFactory
    {
        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance => instance;

        // A Dictionary that contains a string key and a tuple containing the texture, an array of the frame rectangles,
        // the animation speed, and the scale
        private Dictionary<string, Tuple<Texture2D, Rectangle[], int, int>> frames = new Dictionary<string, Tuple<Texture2D, Rectangle[], int, int>>();

        /// <summary>
        /// Method for other classes to call when they need an ISprite implementation. Given the name of the animation needed,
        /// the corresponding texture and the animation parameters are found and a GenericSprite is returned
        /// </summary>
        /// <param name="animationName">The name of the animation needed.</param>
        /// <returns>A GenericSprite implementation</returns>
        public ISprite CreateSprite(string animationName)
        {
            if (animationName != null && frames.ContainsKey(animationName))
                return new GenericSprite(frames[animationName]);
            else
                return null;
        }

        public void RegisterAnimation(string name, Tuple<Texture2D, Rectangle[], int, int> data)
        {
            frames.Add(name, data);
        }

        // SpriteFactory should realistically need to be reset unless a full art swap is being done
        public void Reset()
        {
            frames = new Dictionary<string, Tuple<Texture2D, Rectangle[], int, int>>();
        }
    }
}
