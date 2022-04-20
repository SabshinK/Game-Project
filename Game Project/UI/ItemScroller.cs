using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ItemScroller : IDrawable
    {
        public List<String> items;
        private int numItems = 6;
        private int itemId;
        public string currItem;
        private ISprite sprite;
        public Vector2 Position { get; set; }
        public ItemScroller()
        {
            itemId = 0;
            items = new List<string>(numItems);
            items.Add("guitarGeneric");
            items.Add("accordianGeneric");
            items.Add("fluteGeneric");
            items.Add("drumGeneric");
            items.Add("harpGeneric");
            items.Add("triangleGeneric");
            currItem = items[itemId];
            sprite = SpriteFactory.Instance.CreateSprite(currItem);
        }

        public void scrollRight()
        {
           
            itemId = (items.IndexOf(currItem) + 1)%numItems;
            currItem = items[itemId];
            sprite = SpriteFactory.Instance.CreateSprite(currItem);

        }

        public void scrollLeft()
        {
            if (items.IndexOf(currItem) == (0))
            {
                itemId = numItems - 1;
            }
            else
            {
                itemId = items.IndexOf(currItem) - 1;
            }
            currItem = items[itemId];
            sprite = SpriteFactory.Instance.CreateSprite(currItem);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(Position.X + 100, Position.Y));
        }
    }
}
