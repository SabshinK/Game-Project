using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class ItemManager
    {
        private ISprite sprite;

        private int itemNumber;
        private List<ISprite> itemList;
        private const int lengthOfList = 3;
        private Vector2 location;

        public ItemManager()
        {
            itemNumber = 0;
            itemList = new List<ISprite>();
            LoaditemList();
            sprite = itemList[itemNumber];
        }

        public void NextItem()
        {
            if (itemNumber == (lengthOfList - 1))
            {
                itemNumber = 0;
            }
            else
            {
                itemNumber++;
            }
            sprite = itemList[itemNumber];
        }

        public void Previousitem()
        {
            if (itemNumber == 0)
            {
                itemNumber = (lengthOfList - 1);
            }
            else
            {
                itemNumber--;
            }
            sprite = itemList[itemNumber];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void LoaditemList()
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
            itemList.Add(SpriteFactory.Instance.CreateSprite("bluePotion"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("dungeonMap"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("bait"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("bowAndArrow"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("smallKey"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("compass"));
            itemList.Add(SpriteFactory.Instance.CreateSprite("triforce"));
        }

    }

}
