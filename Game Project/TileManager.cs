using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class TileManager
    {
        private ISprite sprite;
        
        private int tileNumber;
        private List<ISprite> tileList;
        private const int lengthOfList = 3;
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
            tileNumber = (tileNumber + 1) % lengthOfList;
            sprite = tileList[tileNumber];
        }
      
        public void PreviousTile()
        {
            if (tileNumber == 0) {
                tileNumber = (lengthOfList - 1);
            } else {
                tileNumber--;
                if(tileNumber < 0)
                {
                    tileNumber = lengthOfList;
                }
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
