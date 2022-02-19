using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class TileManager
    {
        private ISprite sprite;
        
        private int tileNumber;
        private List<ISprite> tileList;
        private Vector2 location;
      
        public TileManager()
        {
            tileNumber = 0;
            tileList = new List<ISprite>();
            LoadTileList();
            sprite = tileList[tileNumber];
        }
      
        public void NextTile()
        {
            if (tileNumber == (lengthOfArray - 1)) {
                tileNumber = 0;
            } else {
                tileNumber++;
            }
            sprite = tileList[tileNumber];
        }
      
        public void PreviousTile()
        {
            if (tileNumber == 0) {
                tileNumber = (lengthOfArray - 1);
            } else {
                tileNumber--;
            }
            sprite = tileList[tileNumber];
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void LoadTileList()
        {
            tileList.Add(SpriteFactory.Instance.CreateSprite("lightGrottoGround"));
            tileList.Add(SpriteFactory.Instance.CreateSprite("darkGrottoGround"));
            tileList.Add(SpriteFactory.Instance.CreateSprite("grottoPlatform"));
        }
      
    }
    
}
