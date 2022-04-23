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
        private static Texture2D fireBallSpriteSheet;
        private static Texture2D explosionSpriteSheet;
        private static Texture2D arrowSpriteSheet;
        private static Texture2D idleArrowSpriteSheet;
        private static Texture2D accordianSpriteSheet;
        private static Texture2D background;
        private static Texture2D backgroundTwo;
        private static Texture2D backgroundFinal;

        // Dictionary used for getting Texture2D's
        private static Dictionary<string, Texture2D> spritesByNames = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Given the name of a spritesheet, this function gets the corresponding Texture2D
        /// </summary>
        /// <param name="spriteName">The name of the sprite to be fetched.</param>
        public static Texture2D GetTexture(string spriteName)
        {
            if (spritesByNames.ContainsKey(spriteName))
                return spritesByNames[spriteName];
            else
                return null;
        }

        public static void LoadContent(ContentManager content)
        {
            // Load all sprites
            enemiesSpriteSheet = content.Load<Texture2D>("Enemies");
            blocksSpriteSheet = content.Load<Texture2D>("TileSet");
            projectilesSpriteSheet = content.Load<Texture2D>("TempProjectiles");
            playerSpriteSheet = content.Load<Texture2D>("ClarySage");
            bossesSpriteSheet = content.Load<Texture2D>("Dragon");
            itemsSpriteSheet = content.Load<Texture2D>("TempItemsAndCollectables");
            tempPlayerSpriteSheet = content.Load<Texture2D>("TempPlayer");
            newItemSpriteSheet = content.Load<Texture2D>("Items");
            fireBallSpriteSheet = content.Load<Texture2D>("fireball");
            explosionSpriteSheet = content.Load<Texture2D>("bombexplode");
            arrowSpriteSheet = content.Load<Texture2D>("Arrow");
            idleArrowSpriteSheet = content.Load<Texture2D>("IdleArrowCollect");
            accordianSpriteSheet = content.Load<Texture2D>("accordionboomerang");
            background = content.Load<Texture2D>("2b");
            backgroundTwo = content.Load<Texture2D>("3b");
            backgroundFinal = content.Load<Texture2D>("FinalBackground");

            LoadDictionary();
        }

        private static void LoadDictionary()
        {
            spritesByNames.Add("Enemies", enemiesSpriteSheet);
            spritesByNames.Add("TileSet", blocksSpriteSheet);
            spritesByNames.Add("TempProjectiles", projectilesSpriteSheet);
            spritesByNames.Add("ClarySage", playerSpriteSheet);
            spritesByNames.Add("Dragon", bossesSpriteSheet);
            spritesByNames.Add("TempItemsAndCollectables", itemsSpriteSheet);
            spritesByNames.Add("TempPlayer", tempPlayerSpriteSheet);
            spritesByNames.Add("Items", newItemSpriteSheet);
            spritesByNames.Add("fireball", fireBallSpriteSheet);
            spritesByNames.Add("bombexplode", explosionSpriteSheet);
            spritesByNames.Add("Arrow", arrowSpriteSheet);
            spritesByNames.Add("IdleArrowCollect", idleArrowSpriteSheet);
            spritesByNames.Add("accordionboomerang", accordianSpriteSheet);
            spritesByNames.Add("2b", background);
            spritesByNames.Add("3b", backgroundTwo);
            spritesByNames.Add("FinalBackground", backgroundFinal);
        }
    }
}
