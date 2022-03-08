using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// Sprint 2 - cycling thru items

namespace Game_Project
{
    public class ItemManager
    {
        private int numItems = 15;
        private List<ISprite> itemList;

        private int itemId;
        private ISprite sprite;

        private Vector2 location;

        public ItemManager()
        {
            itemId = 0;
            itemList = new List<ISprite>(numItems);
            FeedItemList(); //Creating the Item List
            sprite = itemList[itemId];
            location = new Vector2(100, 300);
            
            
        }

        public void FeedItemList()
        {
            itemList.Add(SpriteFactory.Instance.CreateSprite("fullHeart"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("halfHeart"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("emptyHeart"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("heartCollectable"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("heartContainer"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("fairyGeneric"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("stopwatch"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("rupee"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("redPotion"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("dungeonMap"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("bait"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("bowAndArrow"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("smallKey"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("compass"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("triforce"));
        }

        public void NextItem()
        {
            if (itemList.IndexOf(sprite) == (numItems - 1))
            {
                itemId = 0;
            }
            else
            {
                itemId = itemList.IndexOf(sprite) + 1;
            }
            if(itemId >= numItems)
            {
                itemId = 0;
            }
            sprite = itemList[itemId];
        }

        public void PreviousItem()
        {
            if (itemList.IndexOf(sprite) == (0))
            {
                itemId = numItems-1;
            }
            else
            {
                itemId = itemList.IndexOf(sprite) - 1;
                if(itemId < 0)
                {
                    itemId = numItems-1;
                }
            }
            sprite = itemList[itemId];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
      
    }
    
}