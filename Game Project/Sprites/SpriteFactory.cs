using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    public class SpriteFactory
    {
        // Declare the sprite factory as a singleton with a public getter
        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance => instance;

        private Dictionary<string, Texture2D> spritesByNames;
        
        private SpriteFactory()
        {
            spritesByNames = new Dictionary<string, Texture2D>();
        }

        /// <summary>
        /// Given the name of a spritesheet, this function gets the corresponding Texture2D
        /// </summary>
        /// <param name="spriteName">The name of the sprite to be fetched.</param>
        public Texture2D GetTexture(string spriteName)
        {
            if (spritesByNames.ContainsKey(spriteName))
            {
                return spritesByNames[spriteName];
            }
            else
            {
                return null;
            }
        }

        public ISprite CreateSprite(string spriteName)
        {
            // After figuring out how to load the data from somewhere else, this will return a sprite as necessary
            return new GenericSprite(GetTexture(spriteName), 0, 0);
        }

        private void LoadContent(ContentManager content)
        {
            // Load all sprites
            content.Load<Texture2D>("");
        }
    }
}
