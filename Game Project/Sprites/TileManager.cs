using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    class TileManager
    {
        private ISprite sprite;
        
        private int tileNumber;
        private string[] tileArray;
        private int lengthOfArray = 3;
        private Vector2 location;
      
        public TileManager
        {
            tileNumber = 0;
            tileArray = new string[lengthOfArray] {"TileZero", "TileOne", "TileTwo"};
            sprite = SpriteFactory.instance.CreateSprite(tileArray[tileNumber]);
        }
      
        public void NextTile
        {
            if (tileNumber == (lengthOfArray - 1)) {
                tileNumber = 0;
            } else {
                tileNumber++;
            }        
            sprite = SpriteFactory.instance.CreateSprite(tileArray[tileNumber]);
        }
      
        public void PreviousTile
        {
            if (tileNumber == 0) {
                tileNumber = (lengthOfArray - 1);
            } else {
                tileNumber--;
            }
            sprite = SpriteFactory.instance.CreateSprite(tileArray[tileNumber]);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
      
    }
    
}
