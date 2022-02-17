using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    class TileManager
    {
        private int tileNumber;
        private string[] tileArray;
        private int lengthOfArray = 3;
      
        public TileManager
        {
            tileNumber = 0;
            tileArray = new string[lengthOfArray] {"TileZero", "TileOne", "TileTwo"};
            SpriteFactory.instance.CreateSprite(tileArray[tileNumber]);
        }
      
        public void NextTile
        {
            if (tileNumber == (lengthOfArray - 1)) {
                tileNumber = 0;
            } else {
                tileNumber++;
            }        
            SpriteFactory.instance.CreateSprite(tileArray[tileNumber]);
        }
      
        public void PreviousTile
        {
            if (tileNumber == 0) {
                tileNumber = (lengthOfArray - 1);
            } else {
                tileNumber--;
            }
            SpriteFactory.instance.CreateSprite(tileArray[tileNumber]);
        }
      
    }
    
}
