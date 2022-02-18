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
        
        public void LoadDictionary()
        {
            frames.Add("gelGeneric", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(1, 1, 8, 16), new Rectangle(10, 1, 8, 16) }, 2));
            frames.Add("keeseGeneric", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(53, 1, 16, 16), new Rectangle(70, 1, 16, 16) }, 2));
            frames.Add("zohGeneric", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(19, 1, 16, 16), new Rectangle(36, 1, 16, 16) }, 2));
            frames.Add("stalfosGeneric", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(69, 18, 16, 16), new Rectangle(69, 35, 16, 16) }, 2));
            frames.Add("goriyaDown", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(1, 18, 16, 16), new Rectangle(18, 18, 16, 16) }, 2));
            frames.Add("goriyaUp", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(35, 18, 16, 16), new Rectangle(52, 18, 16, 16) }, 2));
            frames.Add("goriyaRight", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(1, 35, 16, 16), new Rectangle(18, 35, 16, 16) }, 2));
            frames.Add("goriyaLeft", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(35, 35, 16, 16), new Rectangle(52, 35, 16, 16) }, 2));
        }
    }
}
