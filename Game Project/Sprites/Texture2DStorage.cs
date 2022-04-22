using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public static class Texture2DStorage
    {
        // This class should be moved into LevelLoader eventually
        private static Texture2D enemiesSpriteSheet;
        private static Texture2D blocksSpriteSheet;
        private static Texture2D projectilesSpriteSheet;
        private static Texture2D playerSpriteSheet;
        private static Texture2D bossesSpriteSheet;
        private static Texture2D itemsSpriteSheet;
        private static Texture2D tempPlayerSpriteSheet;
        private static Texture2D newItemSpriteSheet;

        // Dictionary used for getting Texture2D's
        private static Dictionary<string, Texture2D> spritesByNames = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Given the name of a spritesheet, this function gets the corresponding Texture2D
        /// </summary>
        /// <param name="spriteName">The name of the sprite to be fetched.</param>
        public static Texture2D GetTexture(string spriteName)
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

        public static void LoadContent(ContentManager content)
        {
            // Load all sprites
            enemiesSpriteSheet = content.Load<Texture2D>("Enemies");
            blocksSpriteSheet = content.Load<Texture2D>("TileSet");
            projectilesSpriteSheet = content.Load<Texture2D>("TempProjectiles");
            playerSpriteSheet = content.Load<Texture2D>("ClarySage");
            bossesSpriteSheet = content.Load<Texture2D>("TempBosses");
            itemsSpriteSheet = content.Load<Texture2D>("TempItemsAndCollectables");
            tempPlayerSpriteSheet = content.Load<Texture2D>("TempPlayer");
            newItemSpriteSheet = content.Load<Texture2D>("Items");

            LoadDictionary();
        }

        private static void LoadDictionary()
        {
            spritesByNames.Add("Enemies", enemiesSpriteSheet);
            spritesByNames.Add("TileSet", blocksSpriteSheet);
            spritesByNames.Add("TempProjectiles", projectilesSpriteSheet);
            spritesByNames.Add("ClarySage", playerSpriteSheet);
            spritesByNames.Add("TempBosses", bossesSpriteSheet);
            spritesByNames.Add("TempItemsAndCollectables", itemsSpriteSheet);
            spritesByNames.Add("TempPlayer", tempPlayerSpriteSheet);
            spritesByNames.Add("Items", newItemSpriteSheet);
        }
    }
}
