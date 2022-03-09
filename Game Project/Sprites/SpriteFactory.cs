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
        // the scale, and the animation speed
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

        // All this will be changed when data starts being loaded from XML files, just a temporary way of loading things in
        public void LoadDictionary()
        {
            // Enemy and Boss animations
            // frames.Add("gelGeneric", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(1, 1, 8, 16), new Rectangle(10, 1, 8, 16) }, 2));
            //  frames.Add("keeseGeneric", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(53, 1, 16, 16), new Rectangle(70, 1, 16, 16) }, 2));
            // frames.Add("zohGeneric", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(19, 1, 16, 16), new Rectangle(36, 1, 16, 16) }, 2));
            // frames.Add("stalfosGeneric", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(69, 18, 16, 16), new Rectangle(69, 35, 16, 16) }, 2));
            //   frames.Add("goriyaDown", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(1, 18, 16, 16), new Rectangle(18, 18, 16, 16) }, 2));
            // frames.Add("goriyaUp", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(35, 18, 16, 16), new Rectangle(52, 18, 16, 16) }, 2));
            // frames.Add("goriyaRight", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(1, 35, 16, 16), new Rectangle(18, 35, 16, 16) }, 2));
            // frames.Add("goriyaLeft", new Tuple<string, Rectangle[], int>("TempDungeonEnemies", new Rectangle[] { new Rectangle(35, 35, 16, 16), new Rectangle(52, 35, 16, 16) }, 2));
            //frames.Add("dragonWaiting", new Tuple<string, Rectangle[], int>("TempBosses", new Rectangle[] { new Rectangle(1, 11, 24, 32), new Rectangle(26, 11, 24, 32), new Rectangle(51, 11, 24, 32), new Rectangle(76, 11, 24, 32) }, 2));
            // frames.Add("dragonAttack", new Tuple<string, Rectangle[], int>("TempBosses", new Rectangle[] { new Rectangle(1, 11, 24, 32), new Rectangle(26, 11, 24, 32) }, 2));

            // Tiles
            //frames.Add("lightGrottoGround", new Tuple<string, Rectangle[], int>("TileSet", new Rectangle[] { new Rectangle(0, 0, 64, 64) }, 1));
            //frames.Add("darkGrottoGround", new Tuple<string, Rectangle[], int>("TileSet", new Rectangle[] { new Rectangle(64, 0, 64, 64) }, 1));
            //frames.Add("grottoPlatform", new Tuple<string, Rectangle[], int>("TileSet", new Rectangle[] { new Rectangle(128, 0, 64, 64) }, 1));

            // Projectile animations
            //frames.Add("boomerangGeneric", new Tuple<string, Rectangle[], int>("TempProjectiles", 
            //    new Rectangle[] 
            //    { 
            //        new Rectangle(1, 1, 16, 16), new Rectangle(18, 1, 16, 16), new Rectangle(35, 1, 16, 16), new Rectangle(52, 1, 16, 16),
            //        new Rectangle(69, 1, 16, 16), new Rectangle(86, 1, 16, 16), new Rectangle(103, 1, 16, 16), new Rectangle(120, 1, 16, 16)
            //    }, 2));
            //frames.Add("leftArrow", new Tuple<string, Rectangle[], int>("TempProjectiles", new Rectangle[] { new Rectangle(1, 18, 16, 16) }, 2));
            //frames.Add("rightArrow", new Tuple<string, Rectangle[], int>("TempProjectiles", new Rectangle[] { new Rectangle(18, 18, 16, 16) }, 2));
            //frames.Add("despawnGeneric", new Tuple<string, Rectangle[], int>("TempProjectiles", new Rectangle[] { new Rectangle(35, 18, 16, 16) }, 2));
            //frames.Add("candleFireGeneric", new Tuple<string, Rectangle[], int>("TempProjectiles", new Rectangle[] { new Rectangle(52, 18, 16, 16), new Rectangle(69, 18, 16, 16) }, 2));
            //frames.Add("bombWaiting", new Tuple<string, Rectangle[], int>("TempProjectiles", new Rectangle[] { new Rectangle(1, 35, 16, 16) }, 2));
            //frames.Add("bombExplosion", new Tuple<string, Rectangle[], int>("TempProjectiles", 
            //    new Rectangle[] { new Rectangle(18, 35, 16, 16), new Rectangle(35, 35, 16, 16), new Rectangle(52, 35, 16, 16) }, 2));
            //frames.Add("swordBeamRight", new Tuple<string, Rectangle[], int>("TempProjectiles", new Rectangle[] { new Rectangle(69, 35, 16, 16), new Rectangle(86, 35, 16, 16) }, 2));
            //frames.Add("swordBeamLeft", new Tuple<string, Rectangle[], int>("TempProjectiles", new Rectangle[] { new Rectangle(103, 35, 16, 16), new Rectangle(120, 35, 16, 16) }, 2));

            // Player animations
            //frames.Add("idleRight", new Tuple<string, Rectangle[], int>("ClarySage", new Rectangle[] { new Rectangle(0, 0, 128, 128) }, 1));
            //frames.Add("idleLeft", new Tuple<string, Rectangle[], int>("ClarySage", new Rectangle[] { new Rectangle(129, 0, 128, 128) }, 1));
            //frames.Add("movingRight", new Tuple<string, Rectangle[], int>("ClarySage", 
            //    new Rectangle[] 
            //    { 
            //        new Rectangle(0, 128, 128, 128), new Rectangle(128, 128, 128, 128), new Rectangle(256, 128, 128, 128), new Rectangle(384, 128, 128, 128),
            //        new Rectangle(512, 128, 128, 128), new Rectangle(640, 128, 128, 128), new Rectangle(768, 128, 128, 128), new Rectangle(896, 128, 128, 128),
            //        new Rectangle(1024, 128, 128, 128), new Rectangle(1152, 128, 128, 128), new Rectangle(1280, 128, 128, 128), new Rectangle(1408, 128, 128, 128)
            //    }, 1));
            //frames.Add("movingLeft", new Tuple<string, Rectangle[], int>("ClarySage", 
            //    new Rectangle[] 
            //    {
            //        new Rectangle(0, 256, 128, 128), new Rectangle(128, 256, 128, 128), new Rectangle(256, 256, 128, 128), new Rectangle(384, 256, 128, 128),
            //        new Rectangle(512, 256, 128, 128), new Rectangle(640, 256, 128, 128), new Rectangle(768, 256, 128, 128), new Rectangle(896, 256, 128, 128),
            //        new Rectangle(1024, 256, 128, 128), new Rectangle(1152, 256, 128, 128), new Rectangle(1280, 256, 128, 128), new Rectangle(1408, 256, 128, 128)
            //    }, 1));
            //frames.Add("useItemRight", new Tuple<string, Rectangle[], int>("TempPlayer", new Rectangle[] { new Rectangle(1, 1, 16, 16) }, 2));
            //frames.Add("useItemLeft", new Tuple<string, Rectangle[], int>("TempPlayer", new Rectangle[] { new Rectangle(18, 1, 16, 16) }, 2));
            //frames.Add("attackRight", new Tuple<string, Rectangle[], int>("TempPlayer", 
            //    new Rectangle[] 
            //    { 
            //        new Rectangle(1, 18, 16, 16), new Rectangle(18, 18, 27, 16), new Rectangle(46, 18, 23, 16), new Rectangle(70, 18, 19, 16)
            //    }, 2));
            //frames.Add("attackLeft", new Tuple<string, Rectangle[], int>("TempPlayer",
            //    new Rectangle[]
            //    {
            //        new Rectangle(73, 35, 16, 16), new Rectangle(45, 35, 27, 16), new Rectangle(21, 35, 23, 16), new Rectangle(1, 35, 19, 16)
            //    }, 2));
            //frames.Add("damagedRight", new Tuple<string, Rectangle[], int>("TempPlayer",
            //    new Rectangle[]
            //    {
            //        new Rectangle(1, 52, 16, 16), new Rectangle(18, 52, 16, 16), new Rectangle(35, 52, 16, 16), new Rectangle(52, 52, 16, 16),
            //        new Rectangle(69, 52, 16, 16), new Rectangle(86, 52, 16, 16)
            //    }, 2));
            //frames.Add("damagedLeft", new Tuple<string, Rectangle[], int>("TempPlayer",
            //    new Rectangle[]
            //    {
            //        new Rectangle(1, 69, 16, 16), new Rectangle(18, 69, 16, 16), new Rectangle(35, 69, 16, 16), new Rectangle(52, 69, 16, 16),
            //        new Rectangle(69, 69, 16, 16), new Rectangle(86, 69, 16, 16)
            //    }, 2));

            // Item and Collectable animations
            //frames.Add("fullHeart", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(0, 0, 8, 8) }, 2));
            //frames.Add("halfHeart", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(8, 0, 8, 8) }, 2));
            //frames.Add("emptyHeart", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(16, 0, 8, 8) }, 2));
            //frames.Add("heartCollectable", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(0, 8, 8, 8) }, 2));
            //frames.Add("heartContainer", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(24, 0, 16, 16) }, 2));
            //frames.Add("fairyGeneric", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(40, 0, 8, 16), new Rectangle(48, 0, 8, 16) }, 2));
            //frames.Add("stopwatch", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(56, 0, 16, 16) }, 2));
            //frames.Add("rupee", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(72, 0, 8, 16), new Rectangle(72, 16, 8, 16) }, 2));
            //frames.Add("redPotion", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(80, 0, 8, 16) }, 2));
            //frames.Add("bluePotion", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(80, 16, 8, 16) }, 2));
            //frames.Add("dungeonMap", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(88, 0, 8, 16), new Rectangle(88, 16, 8, 16) }, 2));
            //frames.Add("bait", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(96, 0, 8, 16) }, 2));
            //frames.Add("bowAndArrow", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(144, 0, 16, 16) }, 2));
            //frames.Add("smallKey", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(240, 0, 8, 16) }, 2));
            //frames.Add("compass", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(256, 0, 16, 16) }, 2));
            //frames.Add("triforce", new Tuple<string, Rectangle[], int>("TempItemsAndCollectables", new Rectangle[] { new Rectangle(272, 0, 16, 16), new Rectangle(272, 16, 16, 16) }, 2));

        }



    }
}
