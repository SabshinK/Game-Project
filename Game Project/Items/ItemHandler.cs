using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class ItemHandler
    {
        private static ItemHandler instance = new ItemHandler();
        public static ItemHandler Instance => instance;

        public List<string> items;
        private int itemId;
        public string equipedItem;

        public int ammoCount;

        public void AddItem(string itemName)
        {
            items.Add(itemName);
        }

        public void ScrollRight()
        {
            if (items.Count > 0)
            {
                itemId = (itemId + 1) % items.Count;
                equipedItem = items[itemId];
            }
        }

        public void ScrollLeft()
        {
            if (items.Count > 0)
            {
                if (itemId == 0)
                    itemId = items.Count - 1;
                else
                    itemId--;

                equipedItem = items[itemId];
            }
        }

        public void DecideItem(IPlayer player)
        {
            // accordian is boomerang
            // harp is bow
            // drum is bomb
            // flute is candle
            // triangle is calling heal player up to 4 hearts
            // Order: accordian, flute, drum, harp, triangle
            switch (items[itemId])
            {
                case "accordianGeneric":
                    GameObjectManager.Instance.RegisterObject(new Boomerang(new UniversalParameterObject(player.Position, player.FacingRight)));
                    break ;
                case "fluteGeneric":
                    GameObjectManager.Instance.RegisterObject(new Candle(new UniversalParameterObject(player.Position, player.FacingRight)));
                    break;
                case "drumGeneric":
                    GameObjectManager.Instance.RegisterObject(new Bomb(new UniversalParameterObject(player.Position, player.FacingRight)));
                    break;
                case "harpGeneric":
                    GameObjectManager.Instance.RegisterObject(new Arrow(new UniversalParameterObject(player.Position, player.FacingRight)));
                    break;
                case "triangleGeneric":
                    player.Heal(4);
                    break;
                default:
                    break;
            }
        }
    }
}