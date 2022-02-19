using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public static class Texture2DStorage
    {
        // Declarations of Texture2D's; These are examples of what may be needed and subject to change
        //private static Texture2D skeletonSpriteSheet;
        //private static Texture2D batSpriteSheet;
        //private static Texture2D moblinSpriteSheet;
        //private static Texture2D dragonSpriteSheet;
        //private static Texture2D forestSpriteSheet;
        //private static Texture2D cliffSpriteSheet;
        //private static Texture2D grottoSpriteSheet;
        //private static Texture2D itemSpriteSheet;
        //private static Texture2D playerSpriteSheet;
        //private static Texture2D musicianSpriteSheet;

        // Actual Zelda spritesheet
        private static Texture2D enemiesSpriteSheet;
        private static Texture2D blocksSpriteSheet;
        private static Texture2D projectilesSpriteSheet;
        private static Texture2D playerSpriteSheet;
        private static Texture2D bossesSpriteSheet;
        private static Texture2D itemsSpriteSheet;

        // Dictionary used for getting Texture2D's
        private static Dictionary<string, Texture2D> spritesByNames;

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
            // once more sprites are added there will be more load calls
            //skeletonSpriteSheet = content.Load<Texture2D>("skeletonSpriteSheet");
            //batSpriteSheet = content.Load<Texture2D>("batSpriteSheet");
            //moblinSpriteSheet = content.Load<Texture2D>("moblinSpriteSheet");
            //dragonSpriteSheet = content.Load<Texture2D>("dragonSpriteSheet");
            //forestSpriteSheet = content.Load<Texture2D>("forestSpriteSheet");
            //cliffSpriteSheet = content.Load<Texture2D>("cliffSpriteSheet");
            //grottoSpriteSheet = content.Load<Texture2D>("grottoSpriteSheet");
            //itemSpriteSheet = content.Load<Texture2D>("itemSpriteSheet");
            //playerSpriteSheet = content.Load<Texture2D>("playerSpriteSheet");
            //musicianSpriteSheet = content.Load<Texture2D>("musicianSpriteSheet");
            enemiesSpriteSheet = content.Load<Texture2D>("TempDungeonEnemies");
            blocksSpriteSheet = content.Load<Texture2D>("TileSet");
            projectilesSpriteSheet = content.Load<Texture2D>("TempProjectiles");
            playerSpriteSheet = content.Load<Texture2D>("ClarySage");
            bossesSpriteSheet = content.Load<Texture2D>("TempBosses");
            itemsSpriteSheet = content.Load<Texture2D>("TempItemsAndCollectables");

            LoadDictionary();
        }

        private static void LoadDictionary()
        {
            //spritesByNames.Add("skeletonSpriteSheet", skeletonSpriteSheet);
            //spritesByNames.Add("batSpriteSheet", batSpriteSheet);
            //spritesByNames.Add("moblinSpriteSheet", moblinSpriteSheet);
            //spritesByNames.Add("dragonSpriteSheet", dragonSpriteSheet);
            //spritesByNames.Add("forestSpriteSheet", forestSpriteSheet);
            //spritesByNames.Add("cliffSpriteSheet", cliffSpriteSheet);
            //spritesByNames.Add("grottoSpriteSheet", grottoSpriteSheet);
            //spritesByNames.Add("itemSpriteSheet", itemSpriteSheet);
            //spritesByNames.Add("playerSpriteSheet", playerSpriteSheet);
            //spritesByNames.Add("musicianSpriteSheet", musicianSpriteSheet);
            spritesByNames.Add("TempDungeonEnemies", enemiesSpriteSheet);
            spritesByNames.Add("TileSet", blocksSpriteSheet);
            spritesByNames.Add("TempProjectiles", projectilesSpriteSheet);
            spritesByNames.Add("ClarySage", playerSpriteSheet);
            spritesByNames.Add("TempBosses", bossesSpriteSheet);
            spritesByNames.Add("TempItemsAndCollectables", itemsSpriteSheet);
        }
    }
}
