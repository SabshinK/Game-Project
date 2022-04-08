using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ItemScroller : IDrawable
    {
        private List<String> items;
        private int numItems = 6;
        private int itemId;
        private string currItem;
        public ItemScroller()
        {
            itemId = 0;
            items = new List<string>(numItems);
            items.Add("Guitar");
            items.Add("Accordian");
            items.Add("Flute");
            items.Add("Drum");
            items.Add("Harp");
            items.Add("Triangle");
            currItem = items[itemId];

        }

        public void scrollRight()
        {
           
            itemId = (items.IndexOf(currItem) + 1)%numItems;
            currItem = items[itemId];
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
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //draw images of the items
        }
    }
}
