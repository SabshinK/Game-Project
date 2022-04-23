using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class ItemScroller : IUI
    {
        public List<string> items;
        private int itemId;
        public string currItem;
        private ISprite sprite;
        public Vector2 Position { get; set; }
        public ItemScroller()
        {
            itemId = 0;
            items = new List<string>();
            //currItem = items[itemId];
            //sprite = SpriteFactory.Instance.CreateSprite(currItem);
        }

        public void AddItem(string itemName)
        {
            items.Add(itemName);
        }

        public void scrollRight()
        {
            if (items.Count > 0)
            {
                itemId = (items.IndexOf(currItem) + 1) % items.Count;
                currItem = items[itemId];
                sprite = SpriteFactory.Instance.CreateSprite(currItem);
            }

        }

        public void scrollLeft()
        {
            if (items.Count > 0)
            {
                if (items.IndexOf(currItem) == (0))
                {
                    itemId = items.Count - 1;
                }
                else
                {
                    itemId = items.IndexOf(currItem) - 1;
                }
                currItem = items[itemId];
                sprite = SpriteFactory.Instance.CreateSprite(currItem);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (items.Count > 0)
            {
                sprite.Draw(spriteBatch, new Vector2(Position.X + 550, Position.Y + 100));
            }
        }
    }
}
